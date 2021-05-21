using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Campaign
    {
        private int _CampaignID;
        public int CampaignID
        {
            get { return _CampaignID; }
            set { _CampaignID = value; }
        }

        private string _Venue;
        public string Venue
        {
            get { return _Venue; }
            set { _Venue = value; }
        }

        private int _AssignedTo;
        public int AssignedTo
        {
            get { return _AssignedTo;}
            set { _AssignedTo = value; }
        }

        private DateTime _StartedOn;
        public DateTime StartedOn
        {
            get { return _StartedOn; }
            set { _StartedOn = value;}
        }

        private DateTime _CompletedOn;
        public DateTime CompletedOn 
        {
            get { return _CompletedOn;}
            set { _CompletedOn = value;}
        }

        private bool _IsOpen;
        public bool IsOpen
        {
            get { return _IsOpen; }
            set { _IsOpen = value; }
        }

    }
}
