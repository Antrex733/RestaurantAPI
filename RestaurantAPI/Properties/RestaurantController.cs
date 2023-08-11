using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Entities;

namespace RestaurantAPI.Properties
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDBContext _dbContext;
        public RestaurantController(RestaurantDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetAll() 
        {
            var restaurants = _dbContext
                .Restaurants
                .ToList();
            
            return Ok(restaurants);
        }
    }
}
