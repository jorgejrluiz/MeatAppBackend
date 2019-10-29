using System.Threading.Tasks;

namespace MeatAppBackend.Fronteiras.Fronteiras.Shared
{
    public interface IExecutorAsync<TRequisicao, TResultado>
    {
        Task<TResultado> Executar(TRequisicao requisicao);
    }
}
