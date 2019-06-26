using System;
using Microsoft.Azure.WebJobs.Description;

namespace Bindings
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public class BlogPostAttribute : Attribute
    {
        [AutoResolve]
        public string Url { get; set; }

        private BlogPost Data { get; set; }
    }
}