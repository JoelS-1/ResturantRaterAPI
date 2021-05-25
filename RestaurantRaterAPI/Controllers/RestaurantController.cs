using RestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRaterAPI.Controllers
{
    public class RestaurantController : ApiController
    {
        private RestaurantDbContext _context = new RestaurantDbContext();
        public async Task<IHttpActionResult> PostRestaurant(Restaurant model)
        {
            if(model == null)
            {
                return BadRequest("Your request body cannot be empty");
            }

            if (ModelState.IsValid)
            {
                //adding model to db context
                _context.Restaurants.Add(model);
                //then updating the database with the new model included -- await will wait until the task is done before continuing
                await _context.SaveChangesAsync();

                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
