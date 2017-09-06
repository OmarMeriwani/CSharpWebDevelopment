using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace MASActivationService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"haha","hahaha" };
        }
        [HttpGet]
        public IEnumerable<string> Register(string encrypted)
        {
            try
            {

                string decrypted = Crypt.Decrypt(encrypted, "1pGSlwmWijRZmkTdVLLgc3sUs0YckDU46XrwPHszBYsjzdpxpNyIrTBFMwIvOzYs");
                string[] decr = decrypted.Split(';');
                string Key = decr[0];
                int SoftwareID = Convert.ToInt32(decr[1]);
                string PCNO = decr[2];
                string EMAIL = decr[3];
                string Phone = decr[4];
                string ActivationUser = decr[5];
                string IP = decr[6];
                Models.MAXSDBContext dbcontext = HttpContext.RequestServices.GetService(typeof(Models.MAXSDBContext)) as Models.MAXSDBContext; ;
                bool a = dbcontext.Register(Key, SoftwareID, PCNO,EMAIL, Phone, ActivationUser, IP);
                return new string[] { a.ToString() };
            }
            catch (Exception ex)
            {
                return new string[] { ex.Message };
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
