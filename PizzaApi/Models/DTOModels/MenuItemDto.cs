using System;
using System.Collections.Generic;

namespace PizzaApi.Models.DTOModels
{
    public class MenuItemDto
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

    }
}