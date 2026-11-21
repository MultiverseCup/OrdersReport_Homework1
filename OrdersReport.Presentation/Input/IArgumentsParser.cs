using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersReport.Presentation.Input
{
    public interface IArgumentsParser
    {
        AppArguments Parse(string[] args);
    }
}
