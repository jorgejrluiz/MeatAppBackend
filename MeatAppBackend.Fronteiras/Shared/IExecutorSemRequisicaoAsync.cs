using System.Threading.Tasks;

namespace MeatAppBackend.Fronteiras.Shared
{
    public interface IExecutorSemRequisicaoAsync<TResultado>
    {
        Task<TResultado> Executar();
    }
}
