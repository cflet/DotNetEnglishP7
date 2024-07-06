using Dot.Net.WebApi.Controllers;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using WebApi.Repositories;
using Xunit;


namespace WebApi.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var bidListRepoMock = new Mock<IBidListRepository>();
            bidListRepoMock.Setup(e => e.FindAll())
            .Returns(new BidList[]
            { 
                    new BidList{BidListId = 1, Account = "1234", Type = "Silver"},
                    new BidList{BidListId = 2, Account = "2345", Type = "Gold"},
                    new BidList{BidListId = 3, Account = "3456", Type = "Platinum"}
            });


            var bidListController = new BidListController(bidListRepoMock.Object);

            //Act
            var result = bidListController.GetAll();

            //Assert
                Assert.IsType<OkObjectResult>(result);
        }
    }
}
