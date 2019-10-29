using System.Threading.Tasks;

namespace MeatAppBackend.Fronteiras.Shared
{
#pragma warning disable S3246 // Generic type parameters should be co/contravariant when possible
    public interface IExecutorSemResultadoAsync<TRequisicao>
#pragma warning restore S3246 // Generic type parameters should be co/contravariant when possible
    {
        Task Executar(TRequisicao requisicao);
    }
}
