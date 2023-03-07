using API.Controllers;
using Application.Features.Pizza;
using Application.Features.Pizza.Command;
using Application.Features.Pizza.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Test
{
    [TestFixture]
    public class PizzaControllerTests
    {
        private Mock<IMediator> _mediatorMock;
        private PizzaController _controller;

        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new PizzaController(_mediatorMock.Object);
        }

        [Test]
        public async Task GetAllPizzas_ReturnsOkObjectResult()
        {
            // Arrange
            var expectedPizzas = new List<PizzaDto> { new PizzaDto { PizzaName = "Pepperoni" } };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllPizzaQuery>(), default))
                         .ReturnsAsync(expectedPizzas);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(expectedPizzas, okResult.Value);
        }

        [Test]
        public async Task GetById_WithExistingId_ReturnsOkObjectResult()
        {
            // Arrange
            var expectedPizza = new PizzaDto { PizzaID = 1, PizzaName = "Pepperoni" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPizzaByIdQuery>(), default))
                         .ReturnsAsync(expectedPizza);

            // Act
            var result = await _controller.GetById(expectedPizza.PizzaID);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(expectedPizza, okResult.Value);
        }

        [Test]
        public async Task Create_WithValidPizza_ReturnsOkObjectResult()
        {
            // Arrange
            var pizzaToCreate = new PizzaDto { PizzaName = "Pepperoni" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreatePizzaCommand>(), default))
                         .ReturnsAsync(new PizzaDto { PizzaID = 1, PizzaName = pizzaToCreate.PizzaName });

            // Act
            var result = await _controller.Create(pizzaToCreate);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            var createdPizza = (PizzaDto)okResult.Value;
            Assert.AreEqual(pizzaToCreate.PizzaName, createdPizza.PizzaName);
            Assert.IsNotNull(createdPizza.PizzaID);
        }

        [Test]
        public async Task Update_WithValidPizza_ReturnsOkObjectResult()
        {
            // Arrange
            var pizzaToUpdate = new PizzaDto { PizzaID = 1, PizzaName = "Pepperoni" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreatePizzaCommand>(), default))
                         .ReturnsAsync(pizzaToUpdate);

            // Act
            var result = await _controller.Update(pizzaToUpdate);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            var updatedPizza = (PizzaDto)okResult.Value;
            Assert.AreEqual(pizzaToUpdate, updatedPizza);
        }
    }

}
