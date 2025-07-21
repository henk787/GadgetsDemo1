
using Mediator;

namespace Gadgets.BackOffice.UI.UiServices
{
    public interface IScopedMediator
    {
        ValueTask<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);
        ValueTask<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
    }

    internal class ScopedMediator(IServiceProvider ServiceProvider) : IScopedMediator
    {

        public async ValueTask<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
        {
            using var scope = ServiceProvider.CreateAsyncScope();
            var sender = scope.ServiceProvider.GetRequiredService<Mediator.Mediator>();
            return await sender.Send(command, cancellationToken);
        }


        public async ValueTask<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
        {
            using var scope = ServiceProvider.CreateAsyncScope();
            var sender = scope.ServiceProvider.GetRequiredService<Mediator.Mediator>();

            return await sender.Send(query, cancellationToken);
        }

    }
}
