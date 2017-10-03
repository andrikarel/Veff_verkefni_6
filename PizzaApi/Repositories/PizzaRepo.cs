using System;
using System.Collections.Generic;
using PizzaApi.Models.DTOModels;
using System.Linq;
using PizzaApi.Models.ViewModels;
using PizzaApi.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace PizzaApi.Repositories
{
    public class PizzaRepo : IPizzaRepo
    {
        private readonly AppDataContext _db;

        public PizzaRepo(AppDataContext db){
            _db = db;
        }

        public IEnumerable<MenuItemDto> GetAllMenuItems(){
            var menuItems = (from m in _db.MenuItems
                            where m.isDeleted == false
                            select new MenuItemDto{
                                Id = m.Id,
                                Name = m.Name,
                                Price = m.Price
                            }).ToList();
            return menuItems;
        }

        public MenuItemDto GetMenuItemById(int menuId){
            var menuItem = (from m in _db.MenuItems
                            where m.Id == menuId && m.isDeleted == false
                            select new MenuItemDto{
                                Id = m.Id,
                                Name = m.Name,
                                Price = m.Price
                            }).SingleOrDefault();
            return menuItem;
        }

        public void AddMenuItem(MenuItemViewModel menuItem){
            _db.MenuItems.Add(new MenuItem{
                Name = menuItem.Name,
                SpicyLevel = menuItem.SpicyLevel,
                Description = menuItem.Description,
                Price = menuItem.Price});
                
            _db.SaveChanges();
        }

        public void DeleteMenuItem(int menuId){
            var toDelete = (from m  in _db.MenuItems
                            where m.Id == menuId && m.isDeleted == false
                            select m).SingleOrDefault();
            if(toDelete != null){
                toDelete.isDeleted = true;
            }
            _db.SaveChanges();            
        }

        public IEnumerable<OrderLiteDto> GetAllOrders(){
            var orders = (from o in _db.Order
                            select new OrderLiteDto{
                                Id = o.Id,
                                DateOfOrder = o.DateOfOrder,
                                CustomerName = o.CustomerName,
                                IsPickup = o.IsPickup,
                                Address = o.Address
                            }).ToList();
            return orders;
        }
        public void AddOrder(OrderViewModel order){
            _db.Order.Add(new Order{
                DateOfOrder = order.DateOfOrder,
                CustomerName = order.CustomerName,
                IsPickup = order.IsPickup,
                Address = order.Address,
                
                });
                
            _db.SaveChanges();            
        }

        public OrderDto GetOrderById(int orderId){
            var order = (from o in _db.Order
                            where o.Id == orderId && o.IsCancelled == false
                            select new OrderDto{
                                Id = o.Id,
                                DateOfOrder = o.DateOfOrder,
                                CustomerName = o.CustomerName,
                                IsPickup = o.IsPickup,
                                Address = o.Address,

                            }).SingleOrDefault();
            return order;

        }


  

    }
}