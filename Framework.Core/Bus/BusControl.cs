﻿using Framework.Core.IOC;
using System;

namespace Framework.Core.Bus
{
    public class BusControl : ICommandBus
    {
        private readonly IContainer _container;

        public BusControl( IContainer container)
        {
            _container = container;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            try
            {
                var commandValidationResult = command.Validate();
                if (commandValidationResult.HasError())
                    throw new CommandNotValidException(string.Join(",", commandValidationResult.ValidationErrors));

                var handler = _container.Resolve<ICommandHandler<TCommand>>();

                handler.Handle(command);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
