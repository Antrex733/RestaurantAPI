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
        public ResourceOperationRequirement(ResourceOperation ResourceOperation)
        {
            resourceOperation = ResourceOperation;
        }

        public ResourceOperation resourceOperation { get;}
    }
}
