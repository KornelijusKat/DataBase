using DataBase;
using System;
using Xunit;

namespace TestingDB
{
    public class UnitTest1
    {
        [Fact]
        public void GuidValidationTest()
        {
            //Assign
            string RandomGuid = "479c364d-b792-444b-8613-1a45083d0610";
            //Act
            Guid Result = RandomGuid.GuidValidation();
            // Assert
            Assert.IsType<Guid>(Result);
        }
        [Fact]
        public void IntValidationTest()
        {
            //Assign 
            string number = "5";
            //Act
            int result = number.IntValidation();
            //Assert
            Assert.IsType<int>(result);
        }
        //Nesugalvojau Testu Duomenu bazes funckijoms
    }
}
