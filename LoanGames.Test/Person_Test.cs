using LoanGames.Domain.Interfaces.Repositories;
using LoanGames.Infra.Data.Contexts;
using LoanGames.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoanGames.Domain.Commands.PersonCommands;
using System.Threading;
using System.Threading.Tasks;
using LoanGames.Domain.Entities;

namespace LoanGames.Test
{
    [TestClass]
    public class Person_Test
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
        public void PersonAdd_Test()
        {
            using (var _repository = new PersonRepository(new MainContext(_options)))
            {
                var addPersonCommand = new NewPersonCommand("Wellington", null);
                var addPersonCommandHadle = new PersonCommandHandler(_repository);
                var personResult = addPersonCommandHadle.Handle(addPersonCommand, new CancellationToken()).Result;
                // Assert
                Assert.IsNotNull(personResult);
                Assert.IsTrue(personResult.IsValid);
            }
        }


        [TestMethod]
        public async Task PersonUpdate_Test()
        {
            Person person = null; 
            using (var _repository = new PersonRepository(new MainContext(_options)))
            {
                // Adiciona 
                var addPersonCommand = new NewPersonCommand("Wellington", null);
                var addPersonCommandHadle = new PersonCommandHandler(_repository);
                var personResult = await addPersonCommandHadle.Handle(addPersonCommand, new CancellationToken());
            }
            // Busca
            using (var _repository = new PersonRepository(new MainContext(_options)))
            {
                 person = await _repository.GetByName("Wellington");
            }
            // Altera
            using (var _repository = new PersonRepository(new MainContext(_options)))
            {
                var updatePersonCommand = new UpdatePersonCommand(person.Id, "Wellington Melo", null);
                var updatePersonCommandHadle = new PersonCommandHandler(_repository);
                var personUpdateResult = await updatePersonCommandHadle.Handle(updatePersonCommand, new CancellationToken());
                Assert.IsNotNull(personUpdateResult);
                Assert.IsTrue(personUpdateResult.IsValid);
            }

            using (var _repository = new PersonRepository(new MainContext(_options)))
            {
                var personAlt = await _repository.GetByName("Wellington Melo");
                Assert.AreEqual(personAlt.Name, "Wellington Melo");
            }
           
        }



        [TestMethod]
        public void PersonDelete_Test()
        {
            using (var _repository = new PersonRepository(new MainContext(_options)))
            {
                // Adiciona 
                var addPersonCommand = new NewPersonCommand("Wellington", null);
                var addPersonCommandHadle = new PersonCommandHandler(_repository);
                var personResult = addPersonCommandHadle.Handle(addPersonCommand, new CancellationToken()).Result;
                // Busca
                var person = _repository.GetByName("Wellington").Result;
                // Remove
                var removePersonCommand = new RemovePersonCommand(person.Id);
                var removePersonCommandHadle = new PersonCommandHandler(_repository);
                var removeResult = removePersonCommandHadle.Handle(removePersonCommand, new CancellationToken()).Result;
                // Testa
                Assert.IsNotNull(removeResult);
                Assert.IsTrue(removeResult.IsValid);
            }
        }


    }
}
