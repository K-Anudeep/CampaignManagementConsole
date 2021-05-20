using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Leads
    {
        public int LeadID { get ; set ; }
        public int CampaignID { get ; set ; }
        public string ConsumerName { get ; set ; }
        public string EmailAddress { get ; set ; }
        public int PhoneNo { get ; set ; }
        public string PreferredMoC { get ; set ; }
        public DateTime DateApproached { get ; set ; }
        public int ProductID { get ; set ; }
        public string Status { get ; set ; }
    }
}
