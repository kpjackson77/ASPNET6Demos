using FlightMVC.Controllers;
using FlightMVC.Models;
using FlightMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightMVCTestProject.Controllers
{
  internal class PassengersRepControllerTest
  {
    [Test]
    public void IndexReturnsPassengers()
    {
      // Arrange
      Mock<IPassengersRepository> mock = new Mock<IPassengersRepository>();
      mock.Setup(o => o.GetPassengers()).Returns(new PassengerDetails[]
      {
        new PassengerDetails(){  Name="Fred", Weight= 12}
      });
      PassengersRepController controller = new PassengersRepController(mock.Object);

      // Act
      var result = controller.Index() as ViewResult;

      // Assert
      Assert.NotNull(result);
      Assert.IsInstanceOf<IEnumerable<PassengerDetails>>(result.Model);
    }

  }
}
