using SUS.HTTP.GlobalConstants;
using SUS.MvcFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SUS.HTTP
{
    public class HttpServer : IHttpServer
    {
        //We will use Dictionary, giving key 'path' + action for each path
        List<Route> routeTable;

        public HttpServer(List<Route> routeTable)
        {
            this.routeTable = routeTable;
        }

        public async Task StartAsync(int port)
        {
            //We set the port, using it on our local host (IPAddress.Loopback).
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);

            //Without starting the listner, we cannot proceed with listening for a client. 
            tcpListener.Start();

            while (true)
            {
                //The connection stays open and we're listening for new client, using the async ready-to-use method AcceptTcpClientAsync();
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();

                //We don't need the result from ProcessClient to move on, so there's no need of "await";
                //We only await for the client, because we need the response from it, and then pass it to ProcessClientAsync();
                ProcessClientAsync(tcpClient);
            }
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            try
            {
                using (NetworkStream stream = tcpClient.GetStream())
                {
                    //we set the position of the red data (offset)
                    var position = 0;
                    //This is assumed to be the standard size of a buffer - 4kb
                    var buffer = new byte[HTTPConstants.BufferSize];

                    //TODO Check if there is faster way to proceed with array of bytes
                    var data = new List<byte>();

                    while (true)
                    {
                        var count = await stream.ReadAsync(buffer, position, buffer.Length);
                        position += count;

                        //We want to remove the empty bytes when adding to the data - if the last buffer is less than 4096b, then take only the non-empty data. 
                        //We could use LINQ (data.AddRange(buffer.Take(count));) but will be slower... 
                        if (count < buffer.Length)
                        {
                            var lastPartialBuffer = new byte[count];
                            Array.Copy(buffer, lastPartialBuffer, count);
                            data.AddRange(lastPartialBuffer);
                            break;
                        }
                        else
                        {
                            data.AddRange(buffer);
                        }
                    }

                    //Finally, byte[] => string(text)
                    var requestAsString = Encoding.UTF8.GetString(data.ToArray());
                    //Console.WriteLine(requestAsString);

                    var request = new HttpRequest(requestAsString);
                    //Console.WriteLine($"{request.Method} {request.Path} => ");

                    HttpResponse response;
                    var route = this.routeTable.FirstOrDefault(
                        x => string.Compare(x.Path, request.Path, true) == 0 && x.Method == request.Method);
                    var routePath = routeTable.FirstOrDefault(x => x.Path == request.Path);

                    if (route != null)
                    {
                        response = route.Action(request);
                    }
                    else
                    {
                        response = new HttpResponse("text/html", new byte[0], Enums.HttpStatusCode.NotFound);
                    }

                    //We add this headers/cookies to each response 

                    response.Headers.Add(new Header("Server", "SUS Server 1.69"));
                    //Set-Cookie: Gosho's Cookie=fc0c3724-c519-4722-abd6-d39eb5522536; Path=/;Max-Age=2073600; HttpOnly;
                    response.Cookies.Add(new ResponseCookie("Gosho's Cookie", Guid.NewGuid().ToString()) { HttpOnly = "true", MaxAge = 60 * 24 * 24 * 60 });

                    //HttpResponse .ToString() is overriden
                    var responseHeaderBytes = Encoding.UTF8.GetBytes(response.ToString());

                    await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);
                    await stream.WriteAsync(response.Body, 0, response.Body.Length);
                }

                //To make sure it's close after we finish working with the current client (we do not trust "using" :) )
                tcpClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.InnerException);
            }


        }

    }
}
