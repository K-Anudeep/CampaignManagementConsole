using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Campaign
    {
        public int CampaignID { get; set; }
        public string Name { get; set; }
        public string Venue { get; set; }
        public int AssignedTo { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime CompletedOn { get; set; }
        public bool IsOpen { get; set; } 
    }
}
