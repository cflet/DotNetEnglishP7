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
    public class BidControllerUnitTest
    {
        [Fact]
        public void GetAll_ReturnsOk()
        {
            //Arrange
            Mock<IBidListRepository> bidListRepoMock = new Mock<IBidListRepository>();

            bidListRepoMock.Setup(e => e.FindAll())
            .Returns(new BidList[]
            { 
                     new BidList{BidListId = 1, Account = "1234", Type = "Silver"},
                     new BidList{BidListId = 2, Account = "2345", Type = "Gold"},
                     new BidList{BidListId = 3, Account = "3456", Type = "Platinum"},
                     new BidList{BidListId = 4, Account = "4567", Type = "Black"}
            });

            var bidListController = new BidListController(bidListRepoMock.Object);

            //Act
            var result = bidListController.GetAll();

            var okayResult = result as OkObjectResult;
            var bidCount = ((BidList[])okayResult.Value).Length;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(4, bidCount);
        }


        [Fact]
        public void GetBidById_OneBid()
        {
            //Arrange
            var bidListRepoMock = new Mock<IBidListRepository>();

            bidListRepoMock.Setup(e => e.FindByBidListId(3))
                .Returns(
                     new BidList{BidListId = 3, Account = "3456", Type = "Platinum"});

            var bidListController = new BidListController(bidListRepoMock.Object);

            //Act
            var result = bidListController.GetBid(3);

            var okayResult = result as OkObjectResult;
            var bidCount = ((BidList)okayResult.Value);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal("3456", bidCount.Account);
        }



        [Fact]
        public void AddBid_ValidBid_ReturnsOk()
        {
            //Arrange
            var bidListRepoMock = new Mock<IBidListRepository>();

            var bidListController = new BidListController(bidListRepoMock.Object);

            //Act
            BidList bid = new BidList { BidListId = 4, Account = null, Type = "Black" };

            var result = bidListController.AddBid(bid);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdateBid_ValidBid_ReturnsOk()
        {
            //Arrange
            var bidListRepoMock = new Mock<IBidListRepository>();

            var bidListController = new BidListController(bidListRepoMock.Object);

            //Act
            var result = bidListController.UpdateBid(new BidList { BidListId = 4, Account = "4567", Type = "Black" });

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void DeleteBid_ValidBid_ReturnsOk()
        {
            //Arrange
            var bidListRepoMock = new Mock<IBidListRepository>();

            bidListRepoMock.Setup(e => e.FindByBidListId(2))
                .Returns(
                    new BidList { BidListId = 2, Account = "2345", Type = "Silver" }
                );

            var bidListController = new BidListController(bidListRepoMock.Object);

            //Act
            var result = bidListController.DeleteBid(2);

            //Assert
            Assert.IsType<OkResult>(result);
        }


        [Fact]
        public void DeleteBid_InvalidBid_ReturnsBad()
        {
            //Arrange
            var bidListRepoMock = new Mock<IBidListRepository>();

            bidListRepoMock.Setup(e => e.FindByBidListId(1))
                .Returns(
                    new BidList{BidListId = 2, Account = "2345", Type = "Silver"}
                );

            var bidListController = new BidListController(bidListRepoMock.Object);

            //Act
            var result = bidListController.DeleteBid(3);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }






    }
}




//bidListRepoMock.Setup(e => e.FindAll())
//.Returns(new BidList[]
//{ 
//         new BidList{BidListId = 1, Account = "1234", Type = "Silver"},
//         new BidList{BidListId = 2, Account = "2345", Type = "Gold"},
//         new BidList{BidListId = 3, Account = "3456", Type = "Platinum"},
//         new BidList{BidListId = 4, Account = "4567", Type = "Black"}
//});