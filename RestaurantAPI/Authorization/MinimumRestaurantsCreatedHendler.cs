using Microsoft.AspNetCore.Authorization;
using RestaurantAPI.Entities;
using System.Security.Claims;

namespace RestaurantAPI.Authorization
{
    public class MinimumRestaurantsCreatedHendler :
        AuthorizationHandler<MinimumRestaurantsCreatedRequirement>
    {
        private readonly RestaurantDBContext _restaurantDBContext;
        private readonly ILogger<MinimumRestaurantsCreatedHendler> _logger;
        public MinimumRestaurantsCreatedHendler(ILogger<MinimumRestaurantsCreatedHendler> logger, 
            RestaurantDBContext restaurantDBContext)
        {
            _logger = logger;
            _restaurantDBContext = restaurantDBContext;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            MinimumRestaurantsCreatedRequirement requirement)
        {
            var userId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var countRestaurants = _restaurantDBContext.Restaurants.Count(r => r.CreatedById == userId);

            if (countRestaurants >= requirement.MinCreatedRestaurant)
            {
                context.Succeed(requirement);
                _logger.LogInformation($"Authorization succedded");
            }
            else
            {
                _logger.LogInformation($"Authorization failed");
            }

            return Task.CompletedTask;
        }
    }
}
