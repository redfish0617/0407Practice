using _0407WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _0407WebAPI.Controllers
{
    
    public class ProductsController : ApiController
    {
        static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            return Ok(product);
        }
        public IHttpActionResult PostProduct(Product product)
        {
            products.Add(product);
            return Created(Url.Link("DefaultApi",new { id =product.Id}),product);
        }
    }
}
