using System;

namespace PizzaApi.Models.EntityModels
{
    public class Order
    {   
        public int Id { get; set; }
        public DateTime DateOfOrder { get; set; }
        public string CustomerName { get; set; }
        public bool IsPickup { get; set; }
        public string Address { get; set; }
        public bool IsCancelled { get; set; }
    }
}