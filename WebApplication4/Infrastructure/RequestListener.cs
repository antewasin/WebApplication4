using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApplication4.Infrastructure.EF;
using WebApplication4.Models;

namespace WebApplication4.Infrastructure
{
    public class RequestListener : DelegatingHandler
    {
        private readonly ConvertAppContext context = new ConvertAppContext();

        protected async override Task<HttpResponseMessage> SendAsync(
       HttpRequestMessage request, CancellationToken cancellationToken)
        {
           
            var requestUriText = request.RequestUri.ToString();
          
            var response = await base.SendAsync(request, cancellationToken);
            
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(requestUriText);
                ClientRequest clientRequest = new ClientRequest() { Id=Guid.NewGuid(), Request=requestUriText};
                context.Requests.Add(clientRequest);
                context.SaveChanges();
                
            }
           
            return response;
        }
    }
}