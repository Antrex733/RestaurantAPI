using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System.Security.Claims;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    [Authorize]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        [Authorize(Policy = "Atleast20")]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurantsDtos = _restaurantService.GetAllRestaurants();

            return Ok(restaurantsDtos);
        }

        [HttpGet("{RestaurantId}")]
        [AllowAnonymous]
        public ActionResult<RestaurantDto> GetOne([FromRoute] int RestaurantId)
        {
            var restaurantsDtos = _restaurantService.GetById(RestaurantId);

            return Ok(restaurantsDtos);
        }
        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult<int> CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var Id = _restaurantService.Create(dto, userId);

            return Created($"/api/restaurant/{Id}", null);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _restaurantService.Delete(id, User);

            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, [FromBody] UpdateRestaurantDto dto)
        {
            _restaurantService.Put(id, dto, User);

            return Ok();
        }
    }
}
