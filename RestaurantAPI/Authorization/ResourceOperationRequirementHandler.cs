﻿using Microsoft.AspNetCore.Authorization;
using RestaurantAPI.Entities;
using System.Security.Claims;

namespace RestaurantAPI.Authorization
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Restaurant>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            ResourceOperationRequirement requirement, Restaurant restaurant)
        {
            if (requirement.resourceOperation == ResourceOperation.Read ||
                requirement.resourceOperation == ResourceOperation.Create)
            {
                context.Succeed(requirement);
            }
            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (int.Parse(userId) == restaurant.CreatedById)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
