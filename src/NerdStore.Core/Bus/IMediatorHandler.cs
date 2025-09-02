using NerdStore.Core.Messages;

namespace NerdStore.Core.Bus
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>( T evento ) where T : Event;
        Task<bool> EnviarComando<T>( T command ) where T : Command;
    }
}
