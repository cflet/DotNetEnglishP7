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
    public class TradeControllerUnitTest
    {
        [Fact]
        public void GetAll_ReturnsOk()
        {
            //Arrange
            Mock<ITradeRepository> tradeRepoMock = new Mock<ITradeRepository>();

            tradeRepoMock.Setup(e => e.FindAll())
            .Returns(new Trade[]
            { 
                     new Trade{TradeId = 1, Account = "Platinum"},
                     new Trade{TradeId = 2, Account = "Gold"},
                     new Trade{TradeId = 3, Account = "Silver"},
                     new Trade{TradeId = 4, Account = "Black"}
            });

            var tradeController = new TradeController(tradeRepoMock.Object);

            //Act
            var result = tradeController.GetAll();

            var okayResult = result as OkObjectResult;
            var trade = ((Trade[])okayResult.Value).Length;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(4, trade);
        }


        [Fact]
        public void GetTradeById_OneTrade()
        {
            //Arrange
            var tradeRepoMock = new Mock<ITradeRepository>();

            tradeRepoMock.Setup(e => e.FindByTradeId(3))
                .Returns(
                     new Trade { TradeId = 1, Account = "Platinum" });

            var tradeController = new TradeController(tradeRepoMock.Object);

            //Act
            var result = tradeController.GetTrade(3);

            var okayResult = result as OkObjectResult;
            var tradeCount = ((Trade)okayResult.Value);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(1, tradeCount.TradeId);
        }



        [Fact]
        public void AddTrade_ValidTrade_ReturnsOk()
        {
            //Arrange
            var tradeRepoMock = new Mock<ITradeRepository>();

            var tradeController = new TradeController(tradeRepoMock.Object);

            //Act
            Trade trade = new Trade { TradeId = 1, Account = "Platinum" };

            var result = tradeController.AddTrade(trade);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdateTrade_ValidTrade_ReturnsOk()
        {
            //Arrange
            var tradeRepoMock = new Mock<ITradeRepository>();

            var tradeController = new TradeController(tradeRepoMock.Object);

            //Act
            var result = tradeController.UpdateTrade(new Trade { TradeId = 1, Account = "Platinum" });

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void DeleteTrade_ValidTrade_ReturnsOk()
        {
            //Arrange
            var tradeRepoMock = new Mock<ITradeRepository>();

            tradeRepoMock.Setup(e => e.FindByTradeId(1))
                .Returns(
                    new Trade { TradeId = 1, Account = "Platinum" }
                );

            var tradeController = new TradeController(tradeRepoMock.Object);

            //Act
            var result = tradeController.DeleteTrade(1);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void DeleteTrade_InvalidTrade_ReturnsBad()
        {
            //Arrange
            var tradeRepoMock = new Mock<ITradeRepository>();

            tradeRepoMock.Setup(e => e.FindByTradeId(1))
                .Returns(
                    new Trade { TradeId = 1, Account = "Platinum" }
                );

            var tradeController = new TradeController(tradeRepoMock.Object);

            //Act
            var result = tradeController.DeleteTrade(3);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }






    }
}