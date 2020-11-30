using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using LoanGames.Infra.Data.Contexts;
using LoanGames.Infra.Data.Repositories;
using LoanGames.Domain.Commands.LoanCommands;
using LoanGames.Domain.Entities;
using System;

namespace LoanLoans.Test
{
    [TestClass]
    public class Loan_Test
    {
        private DbContextOptions<MainContext> _options;

        [TestInitialize]
        public void Setup()
        {

            _options = new DbContextOptionsBuilder<MainContext>()
                            .UseInMemoryDatabase(databaseName: "BaseContext_Test")
                            .Options;
        }


        [TestMethod]
        public async Task RegisterLoan_Test()
        {
            Person person =  null;
            using (var _repository = new PersonRepository(new MainContext(_options)))
            {
                person = new Person(Guid.NewGuid(), "Wellington", null);
                _repository.Add(person);
               await _repository.UnitOfWork.Commit();
            }

            Game game =  null;
            using (var _repository = new GameRepository(new MainContext(_options)))
            {
                game = new Game(Guid.NewGuid(), "Teste");
                _repository.Add(game);
                await _repository.UnitOfWork.Commit();
            }

            using (var _repository = new LoanRepository(new MainContext(_options)))
            {
                var addCommand = new RegisterLoanCommand(person.Id, game.Id);
                var addCommandHadle = new LoanCommandHandler(_repository);
                var result = await addCommandHadle.Handle(addCommand, new CancellationToken());
                // Assert
                Assert.IsNotNull(result);
                Assert.IsTrue(result.IsValid);
            }
        }


        [TestMethod]
        public async Task GiveBack_Test()
        {
            Person person = null;
            using (var _repository = new PersonRepository(new MainContext(_options)))
            {
                person = new Person(Guid.NewGuid(), "Wellington", null);
                _repository.Add(person);
                await _repository.UnitOfWork.Commit();
            }

            Game game = null;
            using (var _repository = new GameRepository(new MainContext(_options)))
            {
                game = new Game(Guid.NewGuid(), "Teste");
                _repository.Add(game);
                await _repository.UnitOfWork.Commit();
            }

            using (var _repository = new LoanRepository(new MainContext(_options)))
            {
                var addCommand = new RegisterLoanCommand(person.Id, game.Id);
                var addCommandHadle = new LoanCommandHandler(_repository);
                var result = await addCommandHadle.Handle(addCommand, new CancellationToken());
                // Assert
                Assert.IsNotNull(result);
                Assert.IsTrue(result.IsValid);
            }

            using (var _repository = new LoanRepository(new MainContext(_options)))
            {
                var addCommand = new GiveBackLoanCommand(person.Id, game.Id);
                var addCommandHadle = new LoanCommandHandler(_repository);
                var result = await addCommandHadle.Handle(addCommand, new CancellationToken());
                // Assert
                Assert.IsNotNull(result);
                Assert.IsTrue(result.IsValid);
            }



        }



        //[TestMethod]
        //public async Task LoanDelete_Test()
        //{
        //    using (var _repository = new LoanRepository(new MainContext(_options)))
        //    {
        //        // Adiciona 
        //        var addCommand = new NewLoanCommand("Teste");
        //        var addCommandHadle = new LoanCommandHandler(_repository);
        //        var addResult = await addCommandHadle.Handle(addCommand, new CancellationToken());
        //        // Busca
        //        var selected = await _repository.GetByName("Teste");
        //        // Remove
        //        var removeCommand = new RemoveLoanCommand(selected.Id);
        //        var removeCommandHadle = new LoanCommandHandler(_repository);
        //        var removeResult = await removeCommandHadle.Handle(removeCommand, new CancellationToken());
        //        // Testa
        //        Assert.IsNotNull(removeResult);
        //        Assert.IsTrue(removeResult.IsValid);
        //    }
        //}


    }
}
