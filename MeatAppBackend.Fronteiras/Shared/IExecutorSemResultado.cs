namespace MeatAppBackend.Fronteiras.Shared
{
    public interface IExecutorSemResultado<in TRequisicao>
    {
        void Executar(TRequisicao requisicao);
    }
}
