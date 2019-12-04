using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;

namespace ChanceQuest.Filters
{
    public class LogResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Debug.WriteLine("LogResource Filter Executed");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Debug.WriteLine("LogResource Filter Executing");
        }
    }
}
