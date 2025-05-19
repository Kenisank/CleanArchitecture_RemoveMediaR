using MediatR;
using SharedKernel;

namespace Application.Abstractions.Messaging;

public interface ICommand : IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;
