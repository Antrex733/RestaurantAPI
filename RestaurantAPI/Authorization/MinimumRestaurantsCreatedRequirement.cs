using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI.Authorization
{
    public class MinimumRestaurantsCreatedRequirement:IAuthorizationRequirement
    {
        public int MinCreatedRestaurant { get; }
        public MinimumRestaurantsCreatedRequirement(int minCreatedRestaurant)
        {
            MinCreatedRestaurant = minCreatedRestaurant;
        }   
    }
}
