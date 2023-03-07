using Application.Features.Pizza;
using Application.Features.Pizza.Queries;
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
    public class GetAllPizzaHandlerTests
    {
        private Mock<IPizzaRepository> _mockRepo;
        private Mock<IMapper> _mockMapper;
        private GetAllPizzaHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IPizzaRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new GetAllPizzaHandler(_mockRepo.Object, _mockMapper.Object);
        }

        [Test]
        public async Task Handle_ReturnsListOfPizzas()
        {
            // Arrange
            var pizzas = new List<Domain.Entity.Pizza> { new Domain.Entity.Pizza { PizzaID = 1, PizzaName = "Margherita" } };
            var pizzaDtos = new List<PizzaDto> { new PizzaDto { PizzaID = 1, PizzaName = "Margherita" } };
            _mockRepo.Setup(r => r.GetAll()).ReturnsAsync(pizzas);
            _mockMapper.Setup(m => m.Map<List<PizzaDto>>(pizzas)).Returns(pizzaDtos);

            // Act
            var result = await _handler.Handle(new GetAllPizzaQuery(), CancellationToken.None);

            // Assert
            Assert.AreEqual(pizzaDtos, result);
        }
    }

}
