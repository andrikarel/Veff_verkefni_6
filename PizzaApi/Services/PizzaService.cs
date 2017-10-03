using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using PizzaApi.Models.DTOModels;
using PizzaApi.Models.EntityModels;
using PizzaApi.Models.ViewModels;
using PizzaApi.Repositories;

namespace PizzaApi.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepo _repo;
        private IMemoryCache _cache;

        public PizzaService(IPizzaRepo repo,IMemoryCache cache){
            _repo = repo;
            _cache = cache;
        }
        public IEnumerable<MenuItemDto> GetAllMenuItems()
        {
            IEnumerable<MenuItemDto> menuItems;
            if(!_cache.TryGetValue("MenuItems", out menuItems)){
                Console.WriteLine("HEY EG ER EKKI MEÐ ÞETTA Boi");
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(8));
                menuItems = _repo.GetAllMenuItems();
                _cache.Set("MenuItems",menuItems,cacheEntryOptions);
            }
            return menuItems;
            
        }
        public MenuItemDto GetMenuItemById(int menuId){
            IEnumerable<MenuItemDto> menuItems;
        
            if(_cache.TryGetValue("MenuItems", out menuItems)){
                foreach(MenuItemDto item in menuItems){
                    if(item.Id == menuId){
                Console.WriteLine("IM HERE BOAH");
                        return item;
                    }
                }

            }

            var menuItem = _repo.GetMenuItemById(menuId);
            if(menuItem == null){
                throw new NotFoundException("Not found");
            }
            return menuItem;
        }

        public void AddMenuItem(MenuItemViewModel menuItem){
            
            _cache.Remove("MenuItems");
            _repo.AddMenuItem(menuItem);
        }

        public void DeleteMenuItem(int menuId){
            if(GetMenuItemById(menuId) == null){
                throw new NotFoundException("Menu item not found");
            }
            else{
                _cache.Remove("MenuItems");
                _repo.DeleteMenuItem(menuId);
            }
        }
        public IEnumerable<OrderLiteDto> GetAllOrders(){
            IEnumerable<OrderLiteDto> orders;
            if(!_cache.TryGetValue("Orders", out orders)){
                Console.WriteLine("HEY EG ER EKKI MEÐ ÞETTA Boi");
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(8));
                orders = _repo.GetAllOrders();
                _cache.Set("Orders",orders,cacheEntryOptions);
            }
            return orders;           
        }
        public OrderDto GetOrderById(int orderId){

            var order = _repo.GetOrderById(orderId);
            if(order == null){
                throw new NotFoundException("Not found");
            }
            return order;
        }


        public void AddOrder(OrderViewModel order){
            foreach(int i in order.OrderItemsIds){
                if(GetOrderById(i) == null){
                    throw new ArgumentException();
                }
            }
            _cache.Remove("Orders");
            _repo.AddOrder(order);
        }

    }
}