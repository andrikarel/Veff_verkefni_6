using System;
using System.Collections.Generic;
using PizzaApi.Models.DTOModels;
using PizzaApi.Models.EntityModels;
using PizzaApi.Models.ViewModels;

namespace PizzaApi.Services
{
    public interface IPizzaService
    {
        IEnumerable<MenuItemDto> GetAllMenuItems();
        MenuItemDto GetMenuItemById(int menuId);
        void AddMenuItem(MenuItemViewModel menuItem);
        void DeleteMenuItem(int menuId);
        IEnumerable<OrderLiteDto> GetAllOrders();
        void AddOrder(OrderViewModel order);
        OrderDto GetOrderById(int orderId);

    }
}