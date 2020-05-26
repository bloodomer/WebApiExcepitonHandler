using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiExcepitonHandler.Models;

namespace WebApiExcepitonHandler.Controllers
{
    public class LogonController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage Login([FromUri] string username, [FromUri] string password)
        {

            if (WebApiExcepitonHandler.Login.UserNameAndPassword(username, password))
            {
                var logonUser = new LogonUser()
                {
                    UserName = username,
                    Password = password
                };

                var jsonString = JsonConvert.SerializeObject(logonUser);

                var token = FTH.Extension.Encrypter.Encrypt(jsonString, WebApiExcepitonHandler.Login.Password);

                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized,"Kullanıcı Adı ve Şifre Geçersisizdir.");
            }

        }
    }
}
