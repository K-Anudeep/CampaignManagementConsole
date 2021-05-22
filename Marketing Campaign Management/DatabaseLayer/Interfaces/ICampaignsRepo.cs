using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DatabaseLayer.Interfaces
{
    public interface ICampaignsRepo
    {
        bool AddCampaign(Campaigns campaign);

        List<Campaigns> ViewCampaignsByExec();

        List<Campaigns> ViewCampaignsByAssigned(int uId);

        bool CloseCampaign(int cId);

        bool StatusCheck(int cId);
    }
}
