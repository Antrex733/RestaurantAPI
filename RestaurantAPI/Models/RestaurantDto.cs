using RestaurantAPI.Entities;

namespace RestaurantAPI.Models
{
    public class RestaurantDto
    {
        //Pola od Restaurant (do których użżytkownik może mieć dostęp)
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }//dodałem
        public bool HasDelivery { get; set; }
        public string ContactEmail { get; set; }

        //Pola od Address (do których użżytkownik może mieć dostęp)
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        //Dish
        public List<DishDto> Dishes { get; set; }
    }
}
