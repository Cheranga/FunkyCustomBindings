using System.Threading.Tasks;
using Bindings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace FunkyApi
{
    public class GetBlogPostFunction
    {
        [FunctionName("GetBlogPostFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "blogs/post/{id}")] HttpRequest req,
            [BlogPost(Url = "%blogposturl%/{id}")]BlogPost blogPost,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult(blogPost);
        }
    }
}