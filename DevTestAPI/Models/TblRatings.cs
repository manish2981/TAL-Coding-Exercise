using System;
using System.Collections.Generic;

namespace DevTestAPI.Models
{
    public partial class TblRatings
    {
        public TblRatings()
        {
            TblOccupation = new HashSet<TblOccupation>();
        }

        public int RatingId { get; set; }
        public string Rating { get; set; }
        public string Factor { get; set; }

        public virtual ICollection<TblOccupation> TblOccupation { get; set; }
    }
}
