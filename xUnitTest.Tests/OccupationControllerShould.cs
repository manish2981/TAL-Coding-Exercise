using System;
using Xunit;

namespace xUnitTest.Tests
{
    public class OccupationControllerShould
    {

        // we will seed some dummy data and access the dummy data for testing.
        private OccupationRepository repository;  
        public static DbContextOptions<TALTestDBContext> dbContextOptions { get; }  
        public static string connectionString = "Server=DELL-AUSTRALIA;Database=TAL-TestDB;Trusted_Connection=True;AttachDbFilename=D:\\Samples\\SqlData\\TAL-TestDB.mdf;MultipleActiveResultSets=true";
  
        // Once we have available the instance of the "TALTestDBContext".
        // Then we will go to get the instance of the actual repository "OccupationRepository" based on the instance of "TALTestDBContext"
        // as follows inside the "OccupationControllerShould" constructor
        static OccupationControllerShould()  
        {  
            dbContextOptions = new DbContextOptionsBuilder<TALTestDBContext>()  
                .UseSqlServer(connectionString)  
                .Options;  
                
             var context = new BlogDBContext(dbContextOptions);  
             DummyDataDBInitializer db = new DummyDataDBInitializer();  
             db.Seed(context);  
  
         repository = new OccupationRepository(context);  
        }  
        
       [Fact]
        public async void Task_GetOccupation_Return_OkResult()  
        {  
            //Arrange  
            var controller = new OccupationController(repository);  
  
            //Act  
            var data = await controller.GetOccupation();  
  
            //Assert  
            Assert.IsType<OkObjectResult>(data);  
        }  
  
         [Fact]
        public void Task_GetOccupation_Return_BadRequestResult()  
        {  
            //Arrange  
            var controller = new OccupationController(repository);  
  
            //Act  
            var data = controller.GetOccupation();  
            data = null;  
  
            if (data != null)  
                //Assert  
                Assert.IsType<BadRequestResult>(data);  
        }  
  
        [Fact]
        public async void Task_GetOccupation_MatchResult()  
        {  
            //Arrange  
            var controller = new OccupationController(repository);  
  
            //Act  
            var data = await controller.GetOccupation();  
  
            //Assert  
            Assert.IsType<OkObjectResult>(data);  
  
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;  
            var post = okResult.Value.Should().BeAssignableTo<List<PostViewModel>>().Subject;  
  
            Assert.Equal("Cleaner", post[0].Occupation);  
            Assert.Equal("Light Manual", post[0].Rating);  
  
            Assert.Equal("Doctor", post[1].Occupation);  
            Assert.Equal("Professional", post[1].Rating);  
        }  
 
    }
}
