using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserServices.Database;
using UserServices.Database.Entities;

namespace UserServices.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DataContext db = new DataContext();
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.ToList();
        }
       
        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User model)
        {
            try {
                db.Users.Add(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }


        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, User model)
        {
            var data = db.Users.Find(id);
            if(data==null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, data);
            }
            else
            {
                data.Id = model.Id;
                data.name = model.name;
                data.email = model.email;
                db.SaveChanges();
                
            }
            return StatusCode(StatusCodes.Status201Created, model);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = db.Users.Find(id);
            if(data==null)
            {
                return StatusCode(500);
            }
            else
            {
                db.Users.Remove(data);
                db.SaveChanges();
            }
            return StatusCode(200);
        }
    }
}
