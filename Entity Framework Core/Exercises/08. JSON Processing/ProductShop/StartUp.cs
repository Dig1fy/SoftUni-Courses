using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTO.Products;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static string ResultDirectoryPath = "../../../Datasets/";
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            //ResetDataBase(db);

            // ************** Problem 1 - Import Users **************
            //This is how we read the entire JSON file. We need the relative path to the file which is 
            //three directories backward and the go to the file we want. In our case is Datasets/users.json



            // ************** Problem 1 - Import Users **************   
            //var inputJSON = File.ReadAllText("../../../Datasets/users.json");
            //We need to pass the context +all users(json)
            //Console.WriteLine(ImportUsers(db, inputJSON));


            // ************** Problem 2 - Import Products **************   
            //var inputJson = File.ReadAllText("../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(db, inputJson));

            // ************** Problem 3 - Import Categories **************  
            //var inputJson = File.ReadAllText("../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(db, inputJson));

            // ************** Problem 4 - Import Categories and Products **************  
            //var inputJson = File.ReadAllText("../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(db, inputJson));

            // ************** Problem 5 - Export Products In Range **************  
            //var json = GetProductsInRange(db);

            //if (!Directory.Exists(ResultDirectoryPath))
            //{
            //    Directory.CreateDirectory(ResultDirectoryPath);
            //}

            //File.WriteAllText(ResultDirectoryPath + "/products-in-range.json", json);
            //Console.WriteLine(GetProductsInRange(db));


            // ************** Problem 5 - Export Products In Range **************  
            // SECOND WAY - USING DTO INSTEAD OF ANNONYMOUS CLASS



            //**************Problem 6 - Export Sold Products********************  
            //Console.WriteLine(GetSoldProducts(db));

            //************** Problem 7 - Export Categories By Products Count **************
            //Console.WriteLine(GetCategoriesByProductsCount(db));

            //************** Problem 8 - Export Users and Products **************
            Console.WriteLine(GetUsersWithProducts(db));


        }

        private static void ResetDataBase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted! ");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        // ************** Problem 1 - Import Users **************
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert
                .DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        // ************** Problem 2 - Import Products **************       
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert
            .DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }


        // ************** Problem 3 - Import Categories **************       
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            Category[] categories = JsonConvert
                .DeserializeObject<Category[]>(inputJson)
                .Where(x => x.Name != null)
                .ToArray();


            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        // ************** Problem 4 - Import Categories and Products **************   
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            CategoryProduct[] categoryProducts = JsonConvert
                .DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        //************** Problem 5 - Export Products in Range**************
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .OrderBy(x => x.price)
                .ToArray();

            var result = JsonConvert
                .SerializeObject(products, Formatting.Indented);

            return result;
        }

        // ************** Problem 5 - Export Products in Range ************** 
        // SECOND WAY - USING DTO INSTEAD OF ANNONYMOUS CLASS
        //public static string GetProductsInRange(ProductShopContext context)
        //{
        //    //We create ListOfproductsInRangeDTO. Then we need to serialize array of these classes and return the JSON. 
        //    var products = context
        //        .Products
        //        .Where(x => x.Price >= 500 && x.Price <= 1000)
        //        .Select(x => new ListOfProductsInRangeDTO
        //        {
        //            Name = x.Name,
        //            Price = decimal.Parse(x.Price.ToString("F2")),
        //            SellerName = x.Seller.FirstName + x.Seller.LastName
        //        })
        //        .OrderBy(x => x.Price)
        //        .ToArray();

        //    var result = JsonConvert
        //        .SerializeObject(products, Formatting.Indented);

        //    return result;
        //}


        //**************Problem 6 - Export Sold Products ******************** 
        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context
                .Users
                .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                    .Where(c => c.Buyer != null)
                    .Select(c => new
                    {
                        name = c.Name,
                        price = c.Price,
                        buyerFirstName = c.Buyer.FirstName,
                        buyerLastName = c.Buyer.LastName
                    })
                })
                .OrderBy(z => z.lastName)
                .ThenBy(z => z.firstName)
                .ToArray();

            var result = JsonConvert
                .SerializeObject(soldProducts, Formatting.Indented);

            return result;


        }


        //************** Problem 7 - Export Categories By Products Count **************
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(y => new
                {
                    category = y.Name,
                    productsCount = y.CategoryProducts
                                   .Select(x => x.Product)
                                   .Count(),
                    averagePrice = y.CategoryProducts
                                   .Average(g => g.Product.Price)
                                   .ToString("F2"),
                    totalRevenue = ((y.CategoryProducts
                                   .Select(z => z.Product)
                                   .Count())
                                 * (y.CategoryProducts
                                   .Average(h => h.Product.Price)))
                                   .ToString("F2")
                                 
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var categoriesToJson = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return categoriesToJson;
        }

        //************** Problem 8 - Export Users and Products **************
        public static string GetUsersWithProducts(ProductShopContext context)
        {

            var allUsers = context
                .Users
                .AsEnumerable()
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(o => o.ProductsSold.Count(a => a.Buyer != null))
                .Select(b => new
                {
                    firstName = b.FirstName,
                    lastName = b.LastName,
                    age = b.Age,
                    soldProducts = new
                    {
                        count = b.ProductsSold.Count(l=>l.Buyer != null),
                        products = b.ProductsSold
                        .Where(s => s.Buyer != null)
                        .Select(n => new
                        {
                            name = n.Name,
                            price = n.Price
                        }).ToList()
                    }
                })
                .ToList();

            var finalUsers = new
            {
                usersCount = allUsers.Count,
                users = allUsers
            };

            var jsonSettings = new JsonSerializerSettings { 
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore
            };

            var jsonOutput = JsonConvert.SerializeObject(finalUsers, jsonSettings);

            return jsonOutput;
        }
    }
}