using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASActivationService.Models
{
    public class ActivationRequest
    {
        public string PCNO { get; set; }
        public int SoftwareID { get; set; }
        public string  licenseKey { get; set; }
        public string IP { get; set; }
    }
}
