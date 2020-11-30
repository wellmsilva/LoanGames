using LoanGames.Domain.Interfaces.Repositories;
using LoanGames.Infra.Data.Contexts;
using LoanGames.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoanGames.Domain.Commands.PersonCommands;
using System.Threading;
using System.Threading.Tasks;
using LoanGames.Domain.Entities;
using LoanGames.Domain.Commands.GameCommands;

namespace LoanGames.Test
{
    [TestClass]
    public class Game_Test
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
        public void GameAdd_Test()
        {
            using (var _repository = new GameRepository(new MainContext(_options)))
            {
                var addCommand = new NewGameCommand("Teste");
                var addCommandHadle = new GameCommandHandler(_repository);
                var result = addCommandHadle.Handle(addCommand, new CancellationToken()).Result;
                // Assert
                Assert.IsNotNull(result);
                Assert.IsTrue(result.IsValid);
            }
        }


        [TestMethod]
        public async Task GameUpdate_Test()
        {
            Game game = null;
            using (var _repository = new GameRepository(new MainContext(_options)))
            {
                // Adiciona 
                var addCommand = new NewGameCommand("Teste");
                var addCommandHadle = new GameCommandHandler(_repository);
                var result = await addCommandHadle.Handle(addCommand, new CancellationToken());
            }
            // Busca
            using (var _repository = new GameRepository(new MainContext(_options)))
            {
                game = await _repository.GetByName("Teste");
            }
            // Altera
            using (var _repository = new GameRepository(new MainContext(_options)))
            {
                var updateCommand = new UpdateGameCommand(game.Id, "Teste 1");
                var updateCommandHadle = new GameCommandHandler(_repository);
                var updateResult = await updateCommandHadle.Handle(updateCommand, new CancellationToken());
                Assert.IsNotNull(updateResult);
                Assert.IsTrue(updateResult.IsValid);
            }

            using (var _repository = new GameRepository(new MainContext(_options)))
            {
                var result = await _repository.GetByName("Teste 1");
                Assert.AreEqual(result.Name, "Teste 1");
            }

        }



        [TestMethod]
        public async Task GameDelete_Test()
        {
            using (var _repository = new GameRepository(new MainContext(_options)))
            {
                // Adiciona 
                var addCommand = new NewGameCommand("Teste");
                var addCommandHadle = new GameCommandHandler(_repository);
                var addResult = await addCommandHadle.Handle(addCommand, new CancellationToken());
                // Busca
                var selected = await _repository.GetByName("Teste");
                // Remove
                var removeCommand = new RemoveGameCommand(selected.Id);
                var removeCommandHadle = new GameCommandHandler(_repository);
                var removeResult = await removeCommandHadle.Handle(removeCommand, new CancellationToken());
                // Testa
                Assert.IsNotNull(removeResult);
                Assert.IsTrue(removeResult.IsValid);
            }
        }


    }
}
