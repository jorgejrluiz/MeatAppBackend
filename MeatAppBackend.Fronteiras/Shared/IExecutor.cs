using System.Threading.Tasks;

namespace MeatAppBackend.Fronteiras.Shared
{
    public interface IExecutor<in TRequisicao, out TResultado>
    {
        TResultado Executar(TRequisicao requisicao);
    }
}
