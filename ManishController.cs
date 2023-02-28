using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mk_Core_Web_API.DB_Connection;
using System.Net;
using Table = Mk_Core_Web_API.DB_Connection.Table;

namespace Mk_Core_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManishController : ControllerBase
    {
        private readonly DB_Connection.Table _DB;
        public ManishController(Table DB)
        {
            _DB = DB;
        }

        [HttpGet]
        [Route("Api/GetAllData")]
        public List<Employee> GetData()
        {
            var obj = _DB.Employees.ToList();
            return obj;
        }

        [HttpGet]
        [Route("Api/DeleteData")]

        public HttpResponseMessage Delete(int id)
        {
            var resdelete = _DB.Employees.Where(a => a.Id == id).First();
            _DB.Employees.Remove(resdelete);
            _DB.SaveChanges();
            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
            return res;
        }

        [HttpPost]
        [Route("Api/AddData")]
        public HttpResponseMessage AddEmp(Employee obj)
        {
            if (obj.Id == 0)
            {
                _DB.Employees.Add(obj);
                _DB.SaveChanges();
            }
            else
            {
                _DB.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
                _DB.SaveChanges();
            }
            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
            return res;
        }

        [HttpGet]
        [Route("Api/EditData")]
        public Employee EditData(int id)
        {
            var resedit = _DB.Employees.Where(a => a.Id == id).First();
            return resedit;
        }

        [HttpPost]
        [Route("Api/Login")]
        public string Login(string Email,string password)
        {
            var userlog=_DB.Logins.Where(a=>a.Email == Email).FirstOrDefault();
            if (userlog == null)
            {
                string res = "no";
                return res;
            }
            else
            {
                if(Email==userlog.Email&& password == userlog.password)
                {
                    string res = "Yes";
                    return res;
                }
                else
                {
                    string res = "Not Login";
                    return res;
                }
            }
        }

    }
}
