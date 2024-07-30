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
    public class UserControllerUnitTest
    {
        [Fact]
        public void GetAll_ReturnsOk()
        {
            //Arrange
            Mock<IUserRepository> userRepoMock = new Mock<IUserRepository>();

            userRepoMock.Setup(e => e.FindAll())
            .Returns(new User[]
            {
                     new User{UserName = "Batman", Password = "2345", FullName = "Gold"},
                     new User{UserName = "Superman", Password = "3456", FullName = "Platinum"},
                     new User{UserName = "Spiderman", Password = "4567", FullName = "Black"}
            });

            var UserController = new UserController(userRepoMock.Object);

            //Act
            var result = UserController.GetAll();

            var okayResult = result as OkObjectResult;
            var userCount = ((User[])okayResult.Value).Length;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(3, userCount);
        }


        [Fact]
        public void GetUserById_OneUser()
        {
            //Arrange
            var userRepoMock = new Mock<IUserRepository>();

            userRepoMock.Setup(e => e.FindByUserId(3))
                .Returns(
                     new User { UserName = "Batman", Password = "2345", FullName = "Gold" }
                     );

            var userController = new UserController(userRepoMock.Object);

            //Act
            //var result = UserController.GetUser(3);

            //var okayResult = result as OkObjectResult;
            //var userCount = ((User)okayResult.Value);

            //Assert
            //Assert.IsType<OkObjectResult>(result);
            //Assert.Equal("3456", userCount.Account);
        }



        [Fact]
        public void AddUser_ValidUser_ReturnsOk()
        {
            //Arrange
            var userRepoMock = new Mock<IUserRepository>();

            var userController = new UserController(userRepoMock.Object);

            //Act
            User user = new User { UserName = "Batman", Password = "2345", FullName = "Gold" };

            var result = userController.AddUser(user);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdateUser_ValidUser_ReturnsOk()
        {
            //Arrange
            var userRepoMock = new Mock<IUserRepository>();

            var userController = new UserController(userRepoMock.Object);

            //Act
            var result = userController.UpdateUser(new User { UserName = "Batman", Password = "2345", FullName = "Gold" });

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void DeleteUser_ValidUser_ReturnsOk()
        {
            //Arrange
            var userRepoMock = new Mock<IUserRepository>();

            userRepoMock.Setup(e => e.FindByUserId(2))
                .Returns(
                    new User { UserName = "Batman", Password = "2345", FullName = "Gold" }
                );

            var userController = new UserController(userRepoMock.Object);

            //Act
            var result = userController.DeleteUser(2);

            //Assert
            Assert.IsType<OkResult>(result);
        }


        [Fact]
        public void DeleteUser_InvalidUser_ReturnsBad()
        {
            //Arrange
            var userRepoMock = new Mock<IUserRepository>();

            userRepoMock.Setup(e => e.FindByUserId(1))
                .Returns(
                    new User { UserName = "Batman", Password = "2345", FullName = "Gold" }
                );

            var userController = new UserController(userRepoMock.Object);

            //Act
            var result = userController.DeleteUser(3);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }






    }
}
