using System;

namespace DevTestAPI.ViewModel
{
    public class OccupationViewModel
    {
        public int OccupationId { get; set; }
        public string Occupation { get; set; }
        public string Rating { get; set; }
        public int? RatingId { get; set; }
        public string Factor { get; set; }
    }
}