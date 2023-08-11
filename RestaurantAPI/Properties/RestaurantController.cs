using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Properties
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurantsDtos = _restaurantService.GetAllRestaurants();

            return Ok(restaurantsDtos);
        }

        [HttpGet("{RestaurantId}")]
        public ActionResult<RestaurantDto> GetOne([FromRoute] int RestaurantId)
        {
            var restaurantsDtos = _restaurantService.GetById(RestaurantId);

            if (restaurantsDtos is null)
            {
                return null;
            }

            return Ok(restaurantsDtos);
        }
        [HttpPost]
        public ActionResult<int> CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Id = _restaurantService.Create(dto);

            return Created($"/api/restaurant/{Id}", null);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var idDeleted = _restaurantService.Delete(id);
            if (idDeleted)
                return NoContent();

            return NotFound();
        }
        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, [FromBody] UpdateRestaurantDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var isUpdated = _restaurantService.Put(id, dto);

            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
