using _0407WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _0407WebAPI.Controllers
{
    [Route("Api/v1/products")]
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
        [HttpGet]
        public Product Product(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            //if (product == null)
            //{
            //    return NotFound();
            //}
            return product;
        }
        [HttpGet]
        [Route("Products/FindProductByCache/{id:int}")]
        public IHttpActionResult FindProductByCache([FromBody]int id)
        {
            if (id > 5)
            {
                throw new Exception("error");
            }
            var product = products.FirstOrDefault((p) => p.Id == id);
            product.Name = "FindProduct";
            return Json<Product>(product);
        }
        [Route("Add")]
        public HttpResponseMessage PostProduct([FromUri]Product product)
        {
            products.Add(product);
            CustHttpResponseMessage custHttpResponseMessage = new CustHttpResponseMessage();
            return custHttpResponseMessage.GetSuccessMessage("成功", $"Productid={product.Id}");

        }
    }
}
