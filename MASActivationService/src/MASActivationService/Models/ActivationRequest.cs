using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASActivationService.Models
{
    public class ActivationRequest
    {
         int ID { get; set; }
         string PCNO { get; set; }
         DateTime insertionDate { get; set; }
         string Email { get; set; }
         string PhoneNumber { get; set; }
         string ActivationUser { get; set; }
         int SoftwareID { get; set; }
         string  ActivationKey { get; set; }
         string IP { get; set; }
         DateTime ActivationDate { get; set; }
    }
}
