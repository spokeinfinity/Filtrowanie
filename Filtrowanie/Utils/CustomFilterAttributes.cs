using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace filters.Utils
{
    public class CustomFilterAttributes : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            IPAddress IP = context.HttpContext.Connection.LocalIpAddress;
            IPAddress IPv4 = IP.MapToIPv4();
           /* List<string> hosts = new List<string>();
            var temp = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var _ in temp)
            { hosts.Add(_.ToString()); }*/
            var result = context.Result;
              if (result is PageResult page)
            {
                page.ViewData["IP_Addressv4"] = IPv4;
            }
            await next();
        }
        

    }
}
