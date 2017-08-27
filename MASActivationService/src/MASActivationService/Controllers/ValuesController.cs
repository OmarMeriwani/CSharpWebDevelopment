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
            try
            {
                Models.MAXSDBContext dbcontext = HttpContext.RequestServices.GetService(typeof(Models.MAXSDBContext)) as Models.MAXSDBContext; ;
                bool a = dbcontext.Register("TESTKey", 1, "77777", "77777", "77777", "Omar.Sirwan", "15.15.15.15");
                return new string[] { a.ToString(), "value32" };
            }
            catch (Exception ex)
            {
                return new string[] { ex.Message, "value32" };
            }

        }
        [HttpGet]
        public string Omar()
        {

            return "";
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
