using System;

namespace MarsRover.Domain
{
    public class MarsRoverException : Exception
    {
        public int StatusCode { get; set; }
        public MarsRoverException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}