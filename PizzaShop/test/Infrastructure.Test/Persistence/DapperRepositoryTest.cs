using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Test.Persistence
{
    [TestFixture]
    public class DapperRepositoryTests
    {
        private IDbConnection _dbConnection;
        private IDbTransaction _transaction;
        private DapperRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _dbConnection = new SqlConnection("SERVER=DURGA\\SQLEXPRESS;DATABASE=PizzaOrderingSystem;trusted_connection=true;");
            _dbConnection.Open();
            _transaction = _dbConnection.BeginTransaction();
            var logger = new Mock<ILogger<DapperRepository>>();
            var configuration = new Mock<IConfiguration>();
             configuration.Setup(x => x.GetConnectionString("PizzaDb"))
                .Returns(_dbConnection.ConnectionString);
            _repository = new DapperRepository(logger.Object, configuration.Object);
            _repository.StartTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            _transaction.Rollback();
            _transaction.Dispose();
            _dbConnection.Close();
            _repository.Dispose();
        }

        [Test]
        public void ExecuteQueryWithTransaction_WhenQueryIsValid_ShouldReturnResult()
        {
            // Arrange
            var query = "SELECT TOP 1 * FROM Pizzas";
            var parameters = new { };

            // Act
            var result = _repository.ExecuteQueryWithTransaction<Pizza>(query, parameters);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void ExecuteQueryWithTransaction_WhenQueryIsInvalid_ShouldThrowException()
        {
            // Arrange
            var query = "SELECT * FROM NonExistentTable";
            var parameters = new { };

            // Act & Assert
            Assert.Throws<SqlException>(() => _repository.ExecuteQueryWithTransaction<Pizza>(query, parameters));
        }

        [Test]
        public void ExecuteQuery_WhenQueryIsValid_ShouldReturnResult()
        {
            // Arrange
            var query = "SELECT TOP 1 * FROM Pizzas";
            var parameters = new { };

            // Act
            var result = _repository.ExecuteQuery<Pizza>(query, parameters);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void ExecuteQuery_WhenQueryIsInvalid_ShouldThrowException()
        {
            // Arrange
            var query = "SELECT * FROM NonExistentTable";
            var parameters = new { };

            // Act & Assert
            Assert.Throws<SqlException>(() => _repository.ExecuteQuery<Pizza>(query, parameters));
        }

        [Test]
        public void StartTransaction_ShouldOpenConnectionAndBeginTransaction()
        {
            // Act
            _repository.StartTransaction();

            // Assert
            Assert.That(_dbConnection.State, Is.EqualTo(ConnectionState.Open));
            Assert.That(_transaction, Is.Not.Null);
        }

        [Test]
        public void CommitTransaction_ShouldCommitTransactionAndCloseConnection()
        {
            // Act
            _repository.CommitTransaction();

            // Assert
            Assert.That(_transaction.Connection, Is.Null);
            Assert.That(_dbConnection.State, Is.EqualTo(ConnectionState.Closed));
        }

        [Test]
        public void RollbackTransaction_ShouldRollbackTransactionAndCloseConnection()
        {
            // Act
            _repository.RollbackTransaction();

            // Assert
            Assert.That(_transaction.Connection, Is.Null);
            Assert.That(_dbConnection.State, Is.EqualTo(ConnectionState.Closed));
        }
    }

}
