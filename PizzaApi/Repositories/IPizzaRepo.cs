using System;
using System.Collections.Generic;
using PizzaApi.Models.DTOModels;
using PizzaApi.Models.ViewModels;

namespace PizzaApi.Repositories
{
    public interface IPizzaRepo
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