using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI.Authorization
{
    public enum ResourceOperation
    {
        Create,
        Read,
        Update,
        Delete
    }
    public class ResourceOperationRequirement : IAuthorizationRequirement
    {
        public ResourceOperation resourceOperation { get;}

        public ResourceOperationRequirement(ResourceOperation resourceOperation1)
        {
            resourceOperation = resourceOperation1;
        }
    }
}
