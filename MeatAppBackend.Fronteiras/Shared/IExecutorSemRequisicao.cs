namespace MeatAppBackend.Fronteiras.Shared
{
#pragma warning disable S3246 // Generic type parameters should be co/contravariant when possible
    public interface IExecutorSemRequisicao<TResultado>
#pragma warning restore S3246 // Generic type parameters should be co/contravariant when possible
    {
        TResultado Executar();
    }
}
