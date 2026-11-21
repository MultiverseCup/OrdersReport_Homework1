using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersReport.Presentation.Input
{
    public class InvalidArgumentsException : Exception
    {
        public InvalidArgumentsException(string message) : base(message)
        {
        }
    }
}
