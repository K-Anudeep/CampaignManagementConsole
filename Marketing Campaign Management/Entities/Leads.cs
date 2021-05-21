using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Leads
    {
        private int _LeadID;
        public int LeadID
        {
            get { return _LeadID; }
            set { _LeadID = value; }
        }


        private int _CampaignID;
        public int CampaignID
        {
            get { return _CampaignID; }
            set { _CampaignID = value; }
        }


        private string _ConsumerName;
        public string ConsumerName
        {
            get { return _ConsumerName; }
            set { _ConsumerName = value; }
        }



        private string _EmailAddress;
        public string EmailAddress
        {
            get { return _EmailAddress; }
            set { _EmailAddress = value; }
        }



        private int _PhoneNo;
        public int PhoneNo
        {
            get { return _PhoneNo; }
            set { _PhoneNo = value; }
        }



        private string _PreferredMoC;
        public string PreferredMoC
        {
            get { return _PreferredMoC; }
            set { _PreferredMoC = value; }
        }



        private DateTime _DateApproached;
        public DateTime DateApproached
        {
            get { return _DateApproached; }
            set { _DateApproached = value; }
        }



        private int _ProductID;
        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }



        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
      
 
     
  


    }
}
