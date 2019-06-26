using System;
using System.Collections.Generic;
using System.Text;
using Bindings;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(CustomBindingsStartup))]
namespace Bindings
{
    public class CustomBindingsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.AddExtension<BlogPostBinding>();
        }
    }
}
