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
    public class RatingControllerUnitTest
    {
        [Fact]
        public void GetAll_ReturnsOk()
        {
            //Arrange
            Mock<IRatingRepository> ratingRepoMock = new Mock<IRatingRepository>();

            ratingRepoMock.Setup(e => e.FindAll())
            .Returns(new Rating[]
            { 
                     new Rating{RatingId = 1, FitchRating = "Awsome"},
                     new Rating{RatingId = 2, FitchRating = "Good"},
                     new Rating{RatingId = 3, FitchRating = "Great"},
                     new Rating{RatingId = 4, FitchRating = "Awsome"}
            });

            var ratingController = new RatingController(ratingRepoMock.Object);

            //Act
            var result = ratingController.GetAll();

            var okayResult = result as OkObjectResult;
            var rating = ((Rating[])okayResult.Value).Length;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(4, rating);
        }


        [Fact]
        public void GetRatingById_OneRating()
        {
            //Arrange
            var ratingRepoMock = new Mock<IRatingRepository>();

            ratingRepoMock.Setup(e => e.FindByRatingId(3))
                .Returns(
                     new Rating { RatingId = 1, FitchRating = "Awsome" });

            var ratingController = new RatingController(ratingRepoMock.Object);

            //Act
            var result = ratingController.GetARating(3);

            var okayResult = result as OkObjectResult;
            var ratingCount = ((Rating)okayResult.Value);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(1, ratingCount.RatingId);
        }



        [Fact]
        public void AddRating_ValidRating_ReturnsOk()
        {
            //Arrange
            var ratingRepoMock = new Mock<IRatingRepository>();

            var ratingController = new RatingController(ratingRepoMock.Object);

            //Act
            Rating rating = new Rating { RatingId = 1, FitchRating = "Awsome" };

            var result = ratingController.AddRating(rating);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdateRating_ValidRating_ReturnsOk()
        {
            //Arrange
            var ratingRepoMock = new Mock<IRatingRepository>();

            var ratingController = new RatingController(ratingRepoMock.Object);

            //Act
            var result = ratingController.UpdateRating(new Rating { RatingId = 1, FitchRating = "Awsome" });

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void DeleteRating_ValidRating_ReturnsOk()
        {
            //Arrange
            var ratingRepoMock = new Mock<IRatingRepository>();

            ratingRepoMock.Setup(e => e.FindByRatingId(1))
                .Returns(
                    new Rating { RatingId = 1, FitchRating = "Awsome" }
                );

            var ratingController = new RatingController(ratingRepoMock.Object);

            //Act
            var result = ratingController.DeleteRating(1);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void DeleteRating_InvalidRating_ReturnsBad()
        {
            //Arrange
            var ratingRepoMock = new Mock<IRatingRepository>();

            ratingRepoMock.Setup(e => e.FindByRatingId(1))
                .Returns(
                    new Rating { RatingId = 1, FitchRating = "Awsome" }
                );

            var ratingController = new RatingController(ratingRepoMock.Object);

            //Act
            var result = ratingController.DeleteRating(3);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }






    }
}