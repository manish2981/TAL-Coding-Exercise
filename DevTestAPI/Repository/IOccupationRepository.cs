using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTestAPI.Models;
using DevTestAPI.ViewModel;

namespace DevTestAPI.Repository
{
    public interface IOccupationRepository
    {
        Task<List<OccupationViewModel>> GetOccupations();
    }
}
