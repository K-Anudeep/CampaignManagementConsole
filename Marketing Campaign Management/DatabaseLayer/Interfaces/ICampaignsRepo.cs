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
        bool AddCampaign();

        List<Campaign> ViewCampaigns();

        bool CloseCampaign(int cId);
    }
}
