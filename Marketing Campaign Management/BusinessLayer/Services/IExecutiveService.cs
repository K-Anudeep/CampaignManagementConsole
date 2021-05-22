using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DatabaseLayer.Repositories;

namespace BusinessLayer.Services
{
    public interface IExecutiveService
    {
        bool CheckLeadStatus(int leadID);

        bool CampaignStatusCheck(int cID);
    }
}
