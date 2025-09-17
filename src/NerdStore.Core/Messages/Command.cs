﻿using FluentValidation.Results;
using MediatR;

namespace NerdStore.Core.Messages
{
    public class Command : Message, IRequest<bool>
    {
        public DateTime TimeStamp { get; private set; }

        public ValidationResult ValidationResult { get; protected set; }

        protected Command()
        {
            TimeStamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
