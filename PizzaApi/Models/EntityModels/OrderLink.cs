using System;

namespace PizzaApi.Models.EntityModels
{
    public class OrderLink
    {   
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
       
    }
}