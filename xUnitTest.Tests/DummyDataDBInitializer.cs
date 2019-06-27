using CoreServices.Models;  
using System;  
  
namespace CoreServices.Test  
{  
    public class DummyDataDBInitializer  
    {  
        public DummyDataDBInitializer()  
        {  
        }  
  
        public void Seed(TALTestDBContext context)  
        {  
            context.Database.EnsureDeleted();  
            context.Database.EnsureCreated();  
  
            context.TblOccupation.AddRange(  
                new TblOccupation() { OccupationId = "1", Occupation = "Cleaner", RatingId = 3 },  
                new TblOccupation() { OccupationId = "2", Occupation = "Doctor" , RatingId = 1},  
                new TblOccupation() { OccupationId = "3", Occupation = "Author" , RatingId = 2}, 
                new TblOccupation() { OccupationId = "4", Occupation = "Farmer" , RatingId = 4}
            );  
              
            context.TblRating.AddRange(  
                new TblRating() { RatingId = "1", Description = "Professional"},  
                new TblRating() { RatingId = "2", Description = "White Collar" }  
            );  
            context.SaveChanges();  
        }  
    }  
}  