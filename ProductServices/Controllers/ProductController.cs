using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductServices.Database;
using ProductServices.Database.Entities;

namespace ProductServices.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        DataContext db = new DataContext();
        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return db.Products.ToList();
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post(Product model)
        {
            try
            {
                db.Products.Add(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created,model);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Product model)
        {
            var data = db.Products.Find(id);
            if (data == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, data);
            }
            else
            {
                data.Id = model.Id;
                data.productname = model.productname;
                data.productprice = model.productprice;
                db.SaveChanges();

            }
            return StatusCode(StatusCodes.Status201Created, model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = db.Products.Find(id);
            if (data == null)
            {
                return StatusCode(500);
            }
            else
            {
                db.Products.Remove(data);
                db.SaveChanges();
            }
            return StatusCode(200);
        }
    }
}
