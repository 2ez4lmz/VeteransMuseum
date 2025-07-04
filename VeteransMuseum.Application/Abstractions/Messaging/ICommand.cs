﻿using MediatR;
using VeteransMuseum.Domain.Abstractions;

namespace VeteransMuseum.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}

public interface IBaseCommand
{
}