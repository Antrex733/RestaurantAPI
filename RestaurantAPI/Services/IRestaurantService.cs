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
        bool Delete(int id);
        public bool Put([FromRoute] int id, [FromBody] UpdateRestaurantDto dto);
    }
}