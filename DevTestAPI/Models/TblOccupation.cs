using System;
using System.Collections.Generic;

namespace DevTestAPI.Models
{
    public partial class TblOccupation
    {
        public int OccupationId { get; set; }
        public string Occupation { get; set; }
        public int? RatingId { get; set; }

        public virtual TblRatings Rating { get; set; }
    }
}
