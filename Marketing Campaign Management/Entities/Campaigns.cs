using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Campaigns
    {
        public int CampaignID { get; set; }

        public string Name { get; set; }

        public string Venue { get; set; }

        public int AssignedTo { get; set; }

        public DateTime StartedOn { get; set; }

        public DateTime CompletedOn { get; set; }

        public bool IsOpen { get; set; }

        public int Leads { get; set; }
    }
}
