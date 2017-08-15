using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASActivationService.Models
{
    public class ActivationRequest
    {
        private string PCNO { get; set; }
        private int SoftwareID { get; set; }
        private string  licenseKey { get; set; }
        private string IP { get; set; }
    }
}
