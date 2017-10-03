using System;
using System.Collections.Generic;

namespace PizzaApi.Models.DTOModels
{
    public class OrderDto
    {   
        public int Id { get; set; }
        public DateTime DateOfOrder { get; set; }
        public string CustomerName { get; set; }
        public bool IsPickup { get; set; }
        public string Address { get; set; }

        public List<MenuItemDto> OrderedItems { get; set; }
    }
}