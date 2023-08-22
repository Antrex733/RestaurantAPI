using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using System.Security.Claims;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto, int userId);
        RestaurantDto GetById(int RestaurantId);
        IEnumerable<RestaurantDto> GetAllRestaurants();
        void Delete(int id, ClaimsPrincipal user);
        void Put([FromRoute] int id, [FromBody] UpdateRestaurantDto dto, ClaimsPrincipal user);
    }
}