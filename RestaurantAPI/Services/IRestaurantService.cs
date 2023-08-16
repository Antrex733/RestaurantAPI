using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto);
        RestaurantDto GetById(int RestaurantId);
        IEnumerable<RestaurantDto> GetAllRestaurants();
        void Delete(int id);
        void Put([FromRoute] int id, [FromBody] UpdateRestaurantDto dto);
    }
}