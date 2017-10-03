using System;

namespace PizzaApi.Models.EntityModels
{
    public class MenuItem
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpicyLevel { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool isDeleted { get; set; }
    }
}