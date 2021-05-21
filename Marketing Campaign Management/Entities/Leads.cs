using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Leads
    {
        private int _leadID;
        public int LeadID
        {
            get { return _leadID; }
            set { _leadID = value; }
        }


        private int _campaignID;
        public int CampaignID
        {
            get { return _campaignID; }
            set { _campaignID = value; }
        }


        private string _consumerName;
        public string ConsumerName
        {
            get { return _consumerName; }
            set { _consumerName = value; }
        }



        private string _emailAddress;
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }



        private string _phoneNo;
        public string PhoneNo
        {
            get { return _phoneNo; }
            set { _phoneNo = value; }
        }



        private string _preferredMoC;
        public string PreferredMoC
        {
            get { return _preferredMoC; }
            set { _preferredMoC = value; }
        }



        private DateTime _dateApproached;
        public DateTime DateApproached
        {
            get { return _dateApproached; }
            set { _dateApproached = value; }
        }



        private int _productID;
        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }



        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
      
 
     
  


    }
}
