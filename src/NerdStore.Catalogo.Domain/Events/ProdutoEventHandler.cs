using MediatR;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoEventHandler( IProdutoRepository produtoRepository )
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Handle( ProdutoAbaixoEstoqueEvent message, CancellationToken cancellationToken )
        {
            var produto = await _produtoRepository.ObterPorId(message.AggregateId);

            //aplicar possíveis regras para lidar com o evento, notificar por e-mail, etc.
        }
    }
}
