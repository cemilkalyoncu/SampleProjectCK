using SampleProjectCK.Northwind.Business.Abstract;
using SampleProjectCK.Northwind.Business.DependencyResolvers.Ninject;
using SampleProjectCK.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace SampleProjectCK.Northwind.WebApi.MessageHandlers
{
    public class AuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault();
                if (token != null)
                {
                    byte[] data = Convert.FromBase64String(token);
                    string decodedString = Encoding.UTF8.GetString(data);
                    string[] tokenValues = decodedString.Split(':');

                    IUserService userService = InstanceFactory.GetIstance<IUserService>();

                    User user = userService.GetByUserNameAndPassword(tokenValues[0], tokenValues[1]);
                    if (user != null)
                    {
                        IPrincipal principal = new GenericPrincipal(
                            new GenericIdentity(tokenValues[0]),
                            userService.GetUserRoles(user).
                            Select(u => u.RoleName).ToArray());
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal;
                    }
                }
            }
            catch
            {

            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}