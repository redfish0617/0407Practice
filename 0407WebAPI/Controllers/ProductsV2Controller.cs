using _0407WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _0407WebAPI.Controllers
{
    [RoutePrefix("Api/v2/products")]
    public class ProductsV2Controller : ApiController
    {
        static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "(v2)Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "(V2)Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "(v2)Hammer", Category = "Hardware", Price = 16.99M }
        };
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }
        [HttpGet]
        [Route("(id:int)")]
        public Product Product(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            return product;
        }
        [HttpGet]
        [Route("(id:int)")]
        public Product FindProductProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            product.Name = "FindProduct";
            return product;
        }

        [HttpGet]
        [Route("id:int")]
        public Product FindProductProductByCache(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            product.Name = "FindProduct";
            return product;
        }
        [Route("Add")]
        public IHttpActionResult PostProduct([FromUri]Product product)
        {
            products.Add(product);

            return Created("", product);
        }
    }
}
