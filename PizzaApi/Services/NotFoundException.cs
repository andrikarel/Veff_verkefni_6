using System;

namespace PizzaApi.Services
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
        : base(message)
        {
            
        }
    }

}