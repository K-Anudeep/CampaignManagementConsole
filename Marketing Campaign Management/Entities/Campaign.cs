using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Campaign
    {
        private int _campaignID;
        public int CampaignID
        {
            get { return _campaignID; }
            set { _campaignID = value; }
        }

        private string _venue;
        public string Venue
        {
            get { return _venue; }
            set { _venue = value; }
        }

        private int _assignedTo;
        public int AssignedTo
        {
            get { return _assignedTo;}
            set { _assignedTo = value; }
        }

        private DateTime _startedOn;
        public DateTime StartedOn
        {
            get { return _startedOn; }
            set { _startedOn = value;}
        }

        private DateTime _completedOn;
        public DateTime CompletedOn 
        {
            get { return _completedOn;}
            set { _completedOn = value;}
        }

        private bool _isOpen;
        public bool IsOpen
        {
            get { return _isOpen; }
            set { _isOpen = value; }
        }

    }
}
