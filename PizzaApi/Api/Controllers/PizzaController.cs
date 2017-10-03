using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PizzaApi.Models.DTOModels;
using PizzaApi.Models.EntityModels;
using PizzaApi.Models.ViewModels;
using PizzaApi.Services;

namespace Api.Controllers
{
    [Route("api")]
    public class PizzaController : Controller
    {

        private readonly IPizzaService _pizzaService;


        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
      
        }
        // GET api/values
        [HttpGet]
        [Route("menu")]
        public IActionResult GetAllMenuItems()
        {

            IEnumerable<MenuItemDto> menuItems = _pizzaService.GetAllMenuItems();
            return Ok(menuItems);
        }
        [HttpGet]
        [Route("menu/{menuId:int}")]
        public IActionResult GetMenuItemById(int menuId)
        {
            try{
                var menuItem = _pizzaService.GetMenuItemById(menuId);
                return Ok(menuItem);
            }catch(NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Route("menu")]
        public IActionResult AddMenuItem([FromBody] MenuItemViewModel menuItem )
        {
            if(menuItem == null){
                return BadRequest();
            }
            if(!ModelState.IsValid){
                return StatusCode(412);
            }
            
           _pizzaService.AddMenuItem(menuItem);


            return StatusCode(201);
        }


        [HttpDelete]
        [Route("menu/{menuId:int}")]
        public IActionResult DeleteMenuItem(int menuId)
        {
            try{
                _pizzaService.DeleteMenuItem(menuId);
                return StatusCode(204);
            }catch(NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("orders")]
        public IActionResult GetAllOrders()
        {

            IEnumerable<OrderLiteDto> orders = _pizzaService.GetAllOrders();
            return Ok(orders);
        }
        [HttpPost]
        [Route("orders")]
        public IActionResult AddOrder([FromBody] OrderViewModel order )
        {
            if(order == null){
                return BadRequest();
            }
            if(!ModelState.IsValid){
                return StatusCode(412);
            }
            
           _pizzaService.AddOrder(order);


            return StatusCode(201);
        }

        [HttpGet]
        [Route("orders/{orderId:int}")]
        public IActionResult GetOrderById(int orderId)
        {
            try{
                var order = _pizzaService.GetOrderById(orderId);
                return Ok(order);
            }catch(NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }



        
    }
}
