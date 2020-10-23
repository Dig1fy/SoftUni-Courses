using System;
using System.Threading.Tasks;

namespace SUS.HTTP
{
    public interface IHttpServer
    {
        //async Task StartAsync is available in C# 8.0 or greater
        Task StartAsync(int port);
    }
}
