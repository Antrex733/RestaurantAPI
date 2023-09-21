using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto);
        RestaurantDto GetById(int RestaurantId);
        PagedResult<RestaurantDto> GetAllRestaurants(RestaurantQuery query);
        void Delete(int id);
        void Put([FromRoute] int id, [FromBody] UpdateRestaurantDto dto);
    }
}