using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApiExcepitonHandler.Models;

namespace WebApiExcepitonHandler.MyFilter
{
    public class MyAuthorizationAttribute:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
           else
            {
                LogonUser logonUser = null;
                try
                {
                    var tokenKey = actionContext.Request.Headers.Authorization.Parameter;
                    var jsonString = FTH.Extension.Encrypter.Decrypt(tokenKey,Login.Password);
                    logonUser = JsonConvert.DeserializeObject<LogonUser>(jsonString);
                }
                catch
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                    return;
                }
               

                #region "Eski Basic Authentication"
                //var usernameAndPassword = Encoding.UTF8.GetString(Convert.FromBase64String(tokenKey));
                //var userInfoArray = usernameAndPassword.Split(':');
                //var username = userInfoArray[0];
                //var password = userInfoArray[1];
                #endregion
                

                if (Login.UserNameAndPassword(logonUser.UserName, logonUser.Password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(logonUser.UserName), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }

            }

        }

    }
}