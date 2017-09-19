using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.WebUtilities;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace MASActivationService.Controllers
{

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILogger _logger;
        Models.MAXSDBContext dbcontext;
        public ValuesController(Models.MAXSDBContext dbcontex, ILogger<ValuesController> logger)
        {
            dbcontext = dbcontex;
            _logger = logger;
           
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            _logger.LogInformation("started");
            string encr = Crypt.encrypt("aaahhhqqqq;1;nbnbnnnbnPCNO;omar.sirwan@korektel.com;9647507700138;omar.sirwan;10.10.92.143;1;");
            string decrp = Crypt.encrypt(encr);
            String output = WebUtility.UrlEncode(encr);
            return new string[] { decrp, encr };
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            string error = "";
            try
            {
                string text = id;
              
                error = "Decode";
                text = WebUtility.UrlDecode(text);
                //error = "Decryption";
                //string decrypted = Crypt.Decrypt(text, "E546C8DF278CD5931069B522E695D4F2");

                error = "Split";
                string[] decr = text.Split(';');
                string Key = decr[0];
                error = "Get SoftwareID";
                int SoftwareID = Convert.ToInt32(decr[1]);
                string PCNO = decr[2];
                string EMAIL = decr[3];
                string Phone = decr[4];
                string ActivationUser = decr[5];
                string IP = decr[6];
                string Type = decr[7];
                error = "HttpContext GetService";
                 dbcontext = HttpContext.RequestServices.GetService(typeof(Models.MAXSDBContext)) as Models.MAXSDBContext; ;
                
                bool a = false;
                if (Type == "1")
                {
                    error = "CheckLicense";
                    a = dbcontext.CheckLicense(Key, SoftwareID, PCNO, EMAIL, Phone, ActivationUser, IP);
                }
                if (Type == "2")
                {
                    error = "Register";
                    a = dbcontext.Register(Key, SoftwareID, PCNO, EMAIL, Phone, ActivationUser, IP);
                }
                return a.ToString();
            }
            catch (Exception ex)
            {
                return (error + " Error:" + ex.Message);
            }
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
