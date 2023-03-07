using Application.Features.Pizza;
using Application.Features.Pizza.Command;
using Application.Persistence;
using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test.Pizza
{
    [TestFixture]
    public class CreatePizzaCommandHandlerTests
    {
        private Mock<IPizzaRepository> _mockRepo;
        private Mock<IMapper> _mockMapper;
        private CreatePizzaCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IPizzaRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new CreatePizzaCommandHandler(_mockRepo.Object, _mockMapper.Object);
        }

        [Test]
        public async Task Handle_WhenPizzaIDIsNull_InsertsPizzaAndReturnsMappedDto()
        {
            // Arrange
            var pizzaDto = new PizzaDto { PizzaName = "Margherita" };
            var pizzaEntity = new  Domain.Entity.Pizza { PizzaID = 1, PizzaName = "Margherita" };
            _mockMapper.Setup(m => m.Map<Domain.Entity.Pizza>(pizzaDto)).Returns(pizzaEntity);
            _mockRepo.Setup(r => r.Insert(pizzaEntity)).ReturnsAsync(pizzaEntity);
            _mockMapper.Setup(m => m.Map<PizzaDto>(pizzaEntity)).Returns(pizzaDto);

            var command = new CreatePizzaCommand { Pizza = pizzaDto };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockMapper.Verify(m => m.Map<Domain.Entity.Pizza>(pizzaDto), Times.Once);
            _mockRepo.Verify(r => r.Insert(pizzaEntity), Times.Once);
            _mockMapper.Verify(m => m.Map<PizzaDto>(pizzaEntity), Times.Once);
            Assert.AreEqual(pizzaDto, result);
        }

        [Test]
        public async Task Handle_WhenPizzaIDIsNotNull_UpdatesPizzaAndReturnsMappedDto()
        {
            // Arrange
            var pizzaDto = new PizzaDto { PizzaID = 1, PizzaName = "Margherita" };
            var pizzaEntity = new Domain.Entity.Pizza { PizzaID = 1, PizzaName = "Margherita" };
            _mockMapper.Setup(m => m.Map<Domain.Entity.Pizza>(pizzaDto)).Returns(pizzaEntity);
            _mockRepo.Setup(r => r.Update(pizzaEntity)).ReturnsAsync(pizzaEntity);
            _mockMapper.Setup(m => m.Map<PizzaDto>(pizzaEntity)).Returns(pizzaDto);

            var command = new CreatePizzaCommand { Pizza = pizzaDto };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockMapper.Verify(m => m.Map<Domain.Entity.Pizza>(pizzaDto), Times.Once);
            _mockRepo.Verify(r => r.Update(pizzaEntity), Times.Once);
            _mockMapper.Verify(m => m.Map<PizzaDto>(pizzaEntity), Times.Once);
            Assert.AreEqual(pizzaDto, result);
        }
    }

}
