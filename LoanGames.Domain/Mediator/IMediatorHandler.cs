﻿using System.Threading.Tasks;
using FluentValidation.Results;
using LoanGames.Domain.Commands;

namespace LoanGames.Domain.Mediator
{
    public interface IMediatorHandler
    {
       // Task PublishEvent<T>(T @event) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
