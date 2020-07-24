using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new CarDealerContext())
            {
                //DeleteAndCreateDatabase(context);


                // ******** Task 1 - Import Suppliers ******** //
                //var data = File.ReadAllText("../../../Datasets/suppliers.json");
                //Console.WriteLine(ImportSuppliers(context, data));

                // ******** Task 2 - Import Parts ******** //
                //var dataParts = File.ReadAllText("../../../Datasets/parts.json");
                //Console.WriteLine(ImportParts(context, dataParts));

                // ******** Task 3 - Import Cars ******** //
                //var data = File.ReadAllText("../../../Datasets/cars.json");
                //Console.WriteLine(ImportCars(context, data));

                // ******** Task 4 - Import Customers ******** //
                //var data = File.ReadAllText("../../../Datasets/customers.json");
                //Console.WriteLine(ImportCustomers(context,data));

                // ******** Task 5 - Import Sales ******** //
                //var data = File.ReadAllText("../../../Datasets/sales.json");
                //Console.WriteLine(ImportSales(context, data));

                // ******** Task 6 - Export Ordered Customers ******** //
                //Console.WriteLine(GetOrderedCustomers(context));

                // ******** Task 7 - Export Cars from Make Toyota ******** //
                //Console.WriteLine(GetCarsFromMakeToyota(context));

                // ******** Task 8 - Export Local Suppliers ******** //
                //Console.WriteLine(GetLocalSuppliers(context));

                // ******** Task 9 - Export Cars With Their List Of Parts ******** //
                //Console.WriteLine(GetCarsWithTheirListOfParts(context));

                // ******** Task 10 - Export Total Sales By Customer ******** //
                //Console.WriteLine(GetTotalSalesByCustomer(context));

                // ******** Task 11 - Export Sales With Applied Discount ******** //
                //Console.WriteLine(GetSalesWithAppliedDiscount(context));
            }
        }

        private static void DeleteAndCreateDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            context.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        // ******** Task 1 - Import Suppliers ******** //
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context
                .Suppliers
                .AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        // ******** Task 2 - Import Parts ******** //
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var allSuppliers = context.Suppliers.Select(x => x.Id).ToList();
            var partsFromJson = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(x => allSuppliers.Contains(x.SupplierId))
                .ToArray();

            context
                .Parts
                .AddRange(partsFromJson);

            context.SaveChanges();

            return $"Successfully imported {partsFromJson.Length}.";
        }

        // ******** Task 3 - Import Cars ******** //
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<List<CarImportDTO>>(inputJson);

            foreach (var carDto in json)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                context.Cars.Add(car);

                foreach (var partId in carDto.PartsId)
                {
                    PartCar partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    if (car.PartCars.FirstOrDefault(p => p.PartId == partId) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();

            return $"Successfully imported {json.Count()}.";
        }

        // ******** Task 4 - Import Customers ******** //
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        // ******** Task 5 - Import Sales ******** //
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        // ******** Task 6 - Export Ordered Customers ******** //
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(d => new
                {
                    Name = d.Name,
                    BirthDate = d.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = d.IsYoungDriver
                })
                .ToList();

            var jsonFormat = JsonConvert.SerializeObject(customers, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            });

            return jsonFormat;
        }

        // ******** Task 7 - Export Cars from Make Toyota ******** //
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(g => g.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(y => y.TravelledDistance)
                .Select(z => new
                {
                    Id = z.Id,
                    Make = z.Make,
                    Model = z.Model,
                    TravelledDistance = z.TravelledDistance
                })
                .ToList();

            var jsonOutput = JsonConvert.SerializeObject(cars);

            return jsonOutput;
        }

        // ******** Task 8 - Export Local Suppliers ******** //
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(x => x.IsImporter == false)
                .Select(y => new
                {
                    Id = y.Id,
                    Name = y.Name,
                    PartsCount = y.Parts.Count
                })
                .ToList();

            var jsonOutput = JsonConvert.SerializeObject(suppliers, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            });
            return jsonOutput;
        }

        // ******** Task 9 - Export Cars With Their List Of Parts ******** //
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance
                    },

                    parts = x.PartCars.Select(y => new
                    {
                        Name = y.Part.Name,
                        Price = y.Part.Price.ToString("F2")
                    })
                    .ToList()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

            return json;
        }

        // ******** Task 10 - Export Total Sales By Customer ******** //
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(x => x.Sales.Count >= 1)
                .Select(y => new
                {
                    fullName = y.Name,
                    boughtCars = y.Sales.Count,
                    spentMoney = y.Sales.Sum(s => s.Car.PartCars.Sum(ss => ss.Part.Price))
                })
                .OrderByDescending(a => a.spentMoney)
                .ThenByDescending(b => b.boughtCars)
                .ToList();

            var json = JsonConvert.SerializeObject(customers);
            return json;
        }

        // ******** Task 11 - Export Sales With Applied Discount ******** //
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var cars = context
                .Sales
                .Select(x => new
                {
                    car = new 
                    {
                       Make = x.Car.Make, 
                       Model = x.Car.Model, 
                       TravelledDistance = x.Car.TravelledDistance 
                    },

                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    price = x.Car.PartCars.Sum(ss => ss.Part.Price).ToString("F2"),
                    priceWithDiscount = (x.Car.PartCars.Sum(b => b.Part.Price) * (1 - x.Discount / 100)).ToString("F2")
                })
                .Take(10)
                .ToList();

            var jsonOutput = JsonConvert.SerializeObject(cars);
            return jsonOutput;
        }
    }
}