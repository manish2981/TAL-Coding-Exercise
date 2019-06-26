using DevTestAPI.Models;
using DevTestAPI.Repository;
using DevTestAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTestAPI.Repository
{
    public class OccupationRepository: IOccupationRepository
    {
        TALTestDBContext db;
        public OccupationRepository(TALTestDBContext _db)
        {
            db = _db;
        }

        public async Task<List<OccupationViewModel>> GetOccupations()
        {
            if (db != null)
            {
                return await (from o in db.TblOccupation
                              from r in db.TblRatings
                              where o.RatingId == r.RatingId
                              select new OccupationViewModel
                              {
                                  OccupationId = o.OccupationId,
                                  Occupation = o.Occupation,
                                  RatingId = r.RatingId,
                                  Rating=r.Rating,
                                  Factor=r.Factor
                              }).ToListAsync();
            }

            return null;
        }
    }
}
