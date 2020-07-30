using ProductShop.Data;
using System.IO;
using ProductShop.XMLHelper;
using ProductShop.Dtos.Import;
using System.Collections.Generic;
using ProductShop.Models;
using System.Linq;
using System;
using ProductShop.Dtos.Export;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new ProductShopContext())
            {

                //DeleteAndCreateDatabase(context);

                ////Task 1 - Import Users
                //var users = File.ReadAllText("../../../Datasets/users.xml");
                //System.Console.WriteLine(ImportUsers(context, users));

                ////Task 2 - Import Products
                //var products = File.ReadAllText("../../../Datasets/products.xml");
                //Console.WriteLine(ImportProducts(context, products));

                ////Task 3 - Import Categories
                //var categoriesFromXml = File.ReadAllText("../../../Datasets/categories.xml");
                //Console.WriteLine(ImportCategories(context, categoriesFromXml));

                ////Task 4 - Import Categories and Products
                //var inputCategoryProducts = File.ReadAllText("../../../Datasets/categories-products.xml");
                //Console.WriteLine(ImportCategoryProducts(context, inputCategoryProducts));

                // ******* Task 5 - Export Products In Range *******
                //var productsInRange = GetProductsInRange(context);
                //ImportToXml(productsInRange, "products-in-range.xml");

                // ******* Task 6 - Export Sold Products *******
                //var soldProducts = GetSoldProducts(context);
                //ImportToXml(soldProducts, "users-sold-products.xml");

                // ******* Task 7 - Export Categories By Products Count *******
                //var categories = GetCategoriesByProductsCount(context);
                //ImportToXml(categories, "categories-by-products.xml");

                // ******* Task 8 - Export Users and Products *******
                //var result = GetUsersWithProducts(context);
                //ImportToXml(result, "users-and-products.xml");
            }
        }

        private static void ImportToXml(string productsInRange, string pathToDatasets)
        {
            File.WriteAllText("../../../Datasets/ExportsFromDatabase/" + pathToDatasets, productsInRange);
        }

        private static void DeleteAndCreateDatabase(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        // ******* Task 1 - Import Users *******
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            //XML is kinda stupid so we need to pass 3 things in order to deserialize: dtoObject, fileWithXmlData, rootElement
            const string rootElement = "Users"; //we can see it in the users.xml file

            var users = XMLConverter.Deserializer<ImportUserDto>(inputXml, rootElement);

            //We need to import these users in the DB via the context. 
            //FIRST WAY TO DO IT:

            //var listOfUsers = new List<User>();

            //foreach (var u in users)
            //{
            //    var currentUser = new User()
            //    {
            //        FirstName = u.Firstname,
            //        LastName = u.LastName,
            //        Age = u.Age
            //    };

            //    listOfUsers.Add(currentUser);               
            //}

            //SECOND (BETTER) WAY TO DO IT: 
            var listOfUsers = users
                .Select(x => new User
                {
                    FirstName = x.Firstname,
                    LastName = x.LastName,
                    Age = x.Age
                })
                .ToList();

            context.Users.AddRange(listOfUsers);
            context.SaveChanges();

            return $"Successfully imported {listOfUsers.Count}";
        }

        // ******* Task 2 - Import Products *******
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Products";

            var productsFromXml = XMLConverter.Deserializer<ImportProductsDto>(inputXml, rootElement);

            var productsResult = productsFromXml
                .Select(x => new Product
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerId = x.BuyerId,
                    SellerId = x.SellerId
                })
                .ToList();

            context.Products.AddRange(productsResult);
            context.SaveChanges();

            return $"Successfully imported {productsResult.Count}";
        }

        // ******* Task 3 - Import Categories *******
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Categories";

            var categoriesFromXml = XMLConverter.Deserializer<ImportCategoriesDto>(inputXml, rootElement);

            var categoriesResult = categoriesFromXml
                .Select(x => new Category
                {
                    Name = x.Name
                })
                .ToList();

            context.Categories.AddRange(categoriesResult);
            context.SaveChanges();

            return $"Successfully imported {categoriesResult.Count}";
        }

        // ******* Task 4 - Import Categories and Products *******
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var catProFromXML = XMLConverter.Deserializer<ImportCategoriesProductsDto>(inputXml, "CategoryProducts");

            var productsId = context.Products.Select(i => i.Id).ToList();
            var categoiesId = context.Categories.Select(c => c.Id).ToList();

            var categoryProducts = new List<CategoryProduct>();

            foreach (var item in catProFromXML)
            {
                if (productsId.Contains(item.ProductId) && categoiesId.Contains(item.CategoryId))
                {
                    var newCatPro = new CategoryProduct
                    {
                        CategoryId = item.CategoryId,
                        ProductId = item.ProductId
                    };

                    categoryProducts.Add(newCatPro);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        // ******* Task 5 - Export Products In Range *******
        public static string GetProductsInRange(ProductShopContext context)
        {
            //When we use XML, we always need DTOs + root element !!!!!

            const string rootElement = "Products";

            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(z => z.Price)
                .Select(x => new ExportProductDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .Take(10)
                .ToList();

            var result = XMLConverter.Serialize(products, rootElement);
            return result;

        }

        // ******* Task 6 - Export Sold Products *******
        public static string GetSoldProducts(ProductShopContext context)
        {
            const string rootElement = "Users";

            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(x => new ExportUserSoldProductsDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                        .Select(p => new SoldProduct
                        {
                            Name = p.Name,
                            Price = p.Price
                        }).ToArray()
                })
                .OrderBy(l => l.LastName)
                .ThenBy(f => f.FirstName)
                .Take(5)
                .ToArray();

            string result = XMLConverter.Serialize(users, rootElement);

            return result;
        }

        // ******* Task 7 - Export Categories By Products Count *******
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string rootElement = "Categories";

            var categories = context.Categories
                .Select(x => new ExportCategoriesDto
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(y => y.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(y => y.Product.Price)
                })
                .OrderByDescending(q => q.Count)
                .ThenBy(a => a.TotalRevenue)
                .ToList();

            var result = XMLConverter.Serialize(categories, rootElement);
            return result;
        }

        // ******* Task 8 - Export Users and Products *******
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersProduct = context.Users
                               .ToList() // We need to materialize ALL users because Judge requires that "smart" move
                               .Where(u => u.ProductsSold.Any())
                               .OrderByDescending(p => p.ProductsSold.Count)
                               .Select(u => new ExportUserDto
                               {
                                   FirstName = u.FirstName,
                                   LastName = u.LastName,
                                   Age = u.Age,
                                   SoldProducts = new ProductsWithCountDTO
                                   {
                                       Count = u.ProductsSold.Count,
                                       Products = u.ProductsSold
                                                  .Select(x => new ProductToDTO
                                                  {
                                                      Name = x.Name,
                                                      Price = x.Price
                                                  })
                                                  .OrderByDescending(y => y.Price)
                                                  .ToList()
                                   }
                               })
                               .Take(10)
                               .ToList();

            var userProductWithCount = new UserProductWithCount
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = usersProduct

            };

            var userProductsExport = XMLConverter.Serialize(userProductWithCount, "Users");

            return userProductsExport;
        }
    }
}