﻿namespace Product.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message = "Entity not found") : base(message) { }
    }
}
