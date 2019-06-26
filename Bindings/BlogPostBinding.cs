using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using Newtonsoft.Json;

namespace Bindings
{
    [Extension("BlogPostBinding")]
    public class BlogPostBinding : IExtensionConfigProvider
    {
        private readonly HttpClient _client;

        public BlogPostBinding(HttpClient client)
        {
            _client = client;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<BlogPostAttribute>().BindToInput(GetDataFromAttribute);
        }

        private async Task<BlogPost> GetDataFromAttribute(BlogPostAttribute attribute, CancellationToken token)
        {
            var httpResponse = await _client.GetAsync(attribute.Url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var blogPost = JsonConvert.DeserializeObject<BlogPost>(content);

            return blogPost;
        }
    }
}