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
    public class CurveControllerUnitTest
    {
        [Fact]
        public void GetAll_ReturnsOk()
        {
            //Arrange
            Mock<ICurvePointRepository> curvePointRepoMock = new Mock<ICurvePointRepository>();

            curvePointRepoMock.Setup(e => e.FindAll())
            .Returns(new CurvePoint[]
            { 
                     new CurvePoint{CurveId = 1, AsOfDate = new DateTime(2015, 12, 25), Term = 1.5},
                     new CurvePoint{CurveId = 2, AsOfDate = new DateTime(2015, 12, 25), Term = 90.58},
                     new CurvePoint{CurveId = 3, AsOfDate = new DateTime(2015, 12, 25), Term = 99.3},
                     new CurvePoint{CurveId = 4, AsOfDate = new DateTime(2015, 12, 25), Term = 4.37864210}
            });

            var curvePointController = new CurveController(curvePointRepoMock.Object);

            //Act
            var result = curvePointController.GetAll();

            var okayResult = result as OkObjectResult;
            var curvePoint = ((CurvePoint[])okayResult.Value).Length;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(4, curvePoint);
        }


        [Fact]
        public void GetCurvePointById_OneCurvePoint()
        {
            //Arrange
            var curvePointRepoMock = new Mock<ICurvePointRepository>();

            curvePointRepoMock.Setup(e => e.FindByCurvePointId(3))
                .Returns(
                     new CurvePoint { Id = 1, CurveId = 1, AsOfDate = new DateTime(2015, 12, 25), Term = 1.539488 });

            var curvePointController = new CurveController(curvePointRepoMock.Object);

            //Act
            var result = curvePointController.GetACurvePoint(3);

            var okayResult = result as OkObjectResult;
            var curveCount = ((CurvePoint)okayResult.Value);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(1.539488, curveCount.Term);
        }



        [Fact]
        public void AddCurve_ValidCurve_ReturnsOk()
        {
            //Arrange
            var curvePointRepoMock = new Mock<ICurvePointRepository>();

            var curvePointController = new CurveController(curvePointRepoMock.Object);

            //Act
            CurvePoint curvePoint = new CurvePoint { CurveId = 1, AsOfDate = new DateTime(2015, 12, 25), Term = 1.539488 };

            var result = curvePointController.AddCurvePoint(curvePoint);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdateCurvePoint_ValidCurvePoint_ReturnsOk()
        {
            //Arrange
            var curvePointRepoMock = new Mock<ICurvePointRepository>();

            var curvePointController = new CurveController(curvePointRepoMock.Object);

            //Act
            var result = curvePointController.UpdateCurvePoint(new CurvePoint { Id = 1, CurveId = 1, AsOfDate = new DateTime(2015, 12, 25), Term = 1.539488 });

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void DeleteCurvePoint_ValidCurvePoint_ReturnsOk()
        {
            //Arrange
            var curvePointRepoMock = new Mock<ICurvePointRepository>();

            curvePointRepoMock.Setup(e => e.FindByCurvePointId(1))
                .Returns(
                    new CurvePoint { Id = 1, CurveId = 1, AsOfDate = new DateTime(2015, 12, 25), Term = 1.539488 }
                );

            var curvePointController = new CurveController(curvePointRepoMock.Object);

            //Act
            var result = curvePointController.DeleteCurvePoint(1);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void DeleteCurvePoint_InvalidCurvePoint_ReturnsBad()
        {
            //Arrange
            var curvePointRepoMock = new Mock<ICurvePointRepository>();

            curvePointRepoMock.Setup(e => e.FindByCurvePointId(1))
                .Returns(
                    new CurvePoint { Id = 1, CurveId = 1, AsOfDate = new DateTime(2015, 12, 25), Term = 1.539488 }
                );

            var curvePointController = new CurveController(curvePointRepoMock.Object);

            //Act
            var result = curvePointController.DeleteCurvePoint(3);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }






    }
}