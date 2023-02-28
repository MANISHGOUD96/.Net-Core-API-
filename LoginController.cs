using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mk_Core_Web_API.DB_Connection;
using System.Net;

namespace Mk_Core_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DB_Connection.Table _DB;
        public LoginController(Table DB)
        {
            _DB = DB;
        }

        [HttpGet]
        [Route("Api/GetloginData")]
        public List<Login> logindata()
        {
            var obj = _DB.Logins.ToList();
            return obj;
        }

        [HttpGet]
        [Route("Api/DeleteData")]

        public HttpResponseMessage Delete(int id)
        {
            var resdelete = _DB.Logins.Where(a => a.Id == id).First();
            _DB.Logins.Remove(resdelete);
            _DB.SaveChanges();
            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
            return res;
        }

        [HttpPost]
        [Route("Api/EditLoginData")]
        public string LoginData(Login obj)
        {
            var log = _DB.Logins.Where(a => a.Email == obj.Email).FirstOrDefault();

            if (log != null)
            {
                var oldpass = log.password;
                log.password = obj.password;

                if (log.Email == obj.Email && oldpass == obj.password)
                {
                    return "no";
                }
           
                else
                {
                    _DB.Entry(log).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _DB.SaveChanges();
                    return "Nopass";

                }
            }
            else
            {
                var yes = _DB.Logins.Add(obj).ToString();
                _DB.SaveChanges();
                return yes;
            }

        }
    }
}
