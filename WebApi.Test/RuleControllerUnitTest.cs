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
    public class RuleControllerUnitTest
    {
        [Fact]
        public void GetAll_ReturnsOk()
        {
            //Arrange
            Mock<IRuleNameRepository> ruleNameRepoMock = new Mock<IRuleNameRepository>();

            ruleNameRepoMock.Setup(e => e.FindAll())
            .Returns(new RuleName[]
            { 
                     new RuleName{Name = "Red"},
                     new RuleName{Name = "Yellow"},
                     new RuleName{Name = "Blue"},
                     new RuleName{Name = "Green"}
            });

            var ruleNameController = new RuleNameController(ruleNameRepoMock.Object);

            //Act
            var result = ruleNameController.GetAll();

            var okayResult = result as OkObjectResult;
            var ruleNameCount = ((RuleName[])okayResult.Value).Length;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(4, ruleNameCount);
        }


        [Fact]
        public void GetRuleNameById_OneRuleName()
        {
            //Arrange
            var ruleNameRepoMock = new Mock<IRuleNameRepository>();

            ruleNameRepoMock.Setup(e => e.FindByRuleNameId(3))
                .Returns(
                     new RuleName { Name = "Red" });

            var ruleNameController = new RuleNameController(ruleNameRepoMock.Object);

            //Act
            var result = ruleNameController.GetRuleName(3);

            var okayResult = result as OkObjectResult;
            var ruleNameCount = ((RuleName)okayResult.Value);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Red", ruleNameCount.Name);
        }



        [Fact]
        public void AddRuleName_ValidRuleName_ReturnsOk()
        {
            //Arrange
            var ruleNameRepoMock = new Mock<IRuleNameRepository>();

            var ruleNameController = new RuleNameController(ruleNameRepoMock.Object);

            //Act
            RuleName ruleName = new RuleName { Name = "Red" };

            var result = ruleNameController.AddRuleName(ruleName);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdateRuleName_ValidRuleName_ReturnsOk()
        {
            //Arrange
            var ruleNameRepoMock = new Mock<IRuleNameRepository>();

            var ruleNameController = new RuleNameController(ruleNameRepoMock.Object);

            //Act
            var result = ruleNameController.UpdateRuleName(new RuleName { Name = "Red" });

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void DeleteRuleName_ValidRuleName_ReturnsOk()
        {
            //Arrange
            var ruleNameRepoMock = new Mock<IRuleNameRepository>();

            ruleNameRepoMock.Setup(e => e.FindByRuleNameId(1))
                .Returns(
                    new RuleName { Name = "Red" }
                );

            var ruleNameController = new RuleNameController(ruleNameRepoMock.Object);

            //Act
            var result = ruleNameController.DeleteRuleName(1);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void DeleteRuleName_InvalidRuleName_ReturnsBad()
        {
            //Arrange
            var ruleNameRepoMock = new Mock<IRuleNameRepository>();

            ruleNameRepoMock.Setup(e => e.FindByRuleNameId(1))
                .Returns(
                    new RuleName { Name = "Red" }
                );

            var ruleNameController = new RuleNameController(ruleNameRepoMock.Object);

            //Act
            var result = ruleNameController.DeleteRuleName(3);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }






    }
}