using System;

namespace LoanGames.Domain.Entities
{
    public class Loan : Entity
    {

        protected Loan() {}

        public Loan(Guid personId, Guid gameId)
        {
            Date = DateTime.Now;
            Person_Id = personId;
            Game_Id = gameId;
        }


        public DateTime Date { get; private set; }
        public DateTime? DateReturn { get; internal set; }
        public Guid Person_Id { get; private set; }
        public Guid Game_Id { get; private set; }

        public virtual Person Person { get; private set; }
        public virtual Game Game { get; private set; }

        internal void Devolver()
        {
            DateReturn = DateTime.Now;
        }
    }
}
