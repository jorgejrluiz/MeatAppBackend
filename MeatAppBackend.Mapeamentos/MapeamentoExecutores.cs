using MeatAppBackend.Executores.Restaurante;
using MeatAppBackend.Fronteiras.Executores.Restaurante.ListarRestaurantesExecutor;
<<<<<<< Updated upstream
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;
using Microsoft.Extensions.DependencyInjection;
using System;
=======
using MeatAppBackend.Fronteiras.Executores.Menu.ListarMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Menu.ObterMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Restaurante.ObterRestauranteExecutor;
using MeatAppBackend.Executores.Avaliacao;
using MeatAppBackend.Repositorios.Menu;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;
using Microsoft.Extensions.DependencyInjection;
using MeatAppBackend.Fronteiras.Executores.Pedido.ListarPedidosExecutor;
using MeatAppBackend.Executores.Pedido;
using MeatAppBackend.Fronteiras.Executores.Menu.ObterRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Avaliacao.ObterAvaliacaoExecutor;
using MeatAppBackend.Fronteiras.Executores.Pedido.ObterPedidosExecutor;
using MeatAppBackend.Fronteiras.Executores.Restaurante.InserirRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Restaurante.ExcluirRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Restaurante.AlterarRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Restaurante.AlterarAvaliacaoRestauranteRequisicao;
using MeatAppBackend.Fronteiras.Executores.Pedido.InserirPedidoExecutor;
using MeatAppBackend.Fronteiras.Executores.Pedido.InserirPedidoRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Menu;
using MeatAppBackend.Fronteiras.Executores.Avaliacao.InserirAvaliacaoExecutor;
using MeatAppBackend.Fronteiras.Executores.Menu.InserirMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Menu.ExcluirMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Menu.AlterarMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Menu.AlterarPrecoMenuExecutor;

>>>>>>> Stashed changes

namespace MeatAppBackend.Mapeamentos
{
    public static class MapeamentoExecutores
    {
        public static void ConfigureServices(IServiceCollection services)
        {   
            /*Restaurantes*/
            services.AddScoped<IExecutorSemRequisicao<ListarRestaurantesResultado>>(provider =>
            {
                return new ListarRestaurantesExecutor(provider.GetService<IRestauranteRepositorio>());
            });
<<<<<<< Updated upstream
=======
            services.AddScoped<IExecutorSemRequisicao<ListarMenuRestauranteResultado>>(provider =>
            {
                return new ListarMenuRestauranteExecutor(provider.GetService<IMenuRepositorio>());
            });

            services.AddScoped<IExecutorSemRequisicao<ListarAvaliacaoResultado>>(provider =>
            {
                return new ListarAvaliacaoExecutor(provider.GetService<IAvaliacaoRepositorio>());
            });
            services.AddScoped<IExecutorSemRequisicao<ListarPedidosResultado>>(provider =>
            {
                return new ListarPedidoExecutor(provider.GetService<IPedidoRepositorio>());
            });
            services.AddScoped<IExecutor<ObterRestauranteRequisicao, ObterRestauranteResultado>>(provider =>
            {
                return new ObterRestauranteExecutor(provider.GetService<IRestauranteRepositorio>());
            });

            services.AddScoped<IExecutor<ObterMenuRestauranteRequisicao, ObterMenuRestauranteResultado>>(provider =>
            {
                return new ObterMenuRestauranteExecutor(provider.GetService<IMenuRepositorio>());
            });
            
            services.AddScoped<IExecutor<ObterAvaliacaoRequisicao, ObterAvaliacaoResultado>>(provider =>
            {
                return new ObterAvaliacaoExecutor(provider.GetService<IAvaliacaoRepositorio>());
            });
            services.AddScoped<IExecutor<ObterPedidosRequisicao, ObterPedidosResultado>>(provider =>
            {
                return new ObterPedidoExecutor(provider.GetService<IPedidoRepositorio>());
            });
            services.AddScoped<IExecutorSemResultado<InserirRestauranteRequisicao>>(provider =>
            {
                return new InserirRestauranteExecutor(provider.GetService<IRestauranteRepositorio>());
            });
            services.AddScoped<IExecutorSemResultado<ExcluirRestauranteRequisicao>>(provider =>
            {
                return new ExcluirRestauranteExecutor(provider.GetService<IRestauranteRepositorio>());
            });
            services.AddScoped<IExecutorSemResultado<AlterarRestauranteRequisicao>>(provider =>
            {
                return new AlterarRestauranteExecutor(provider.GetService<IRestauranteRepositorio>());
            });
            services.AddScoped<IExecutorSemResultado<AlterarAvaliacaoRestauranteRequisicao>>(provider =>
            {
                return new AlterarAvaliacaoRestauranteExecutor(provider.GetService<IRestauranteRepositorio>());
            });
            services.AddScoped<IExecutorSemResultado<InserirPedidoRequisicao>>(provider =>
            {
                return new InserirPedidoExecutor(provider.GetService<IPedidoRepositorio>());
            });
            services.AddScoped<IExecutorSemResultado<InserirPedidoRestauranteRequisicao>>(provider =>
            {
                return new InserirPedidoRestauranteExecutor(provider.GetService<IPedidoRepositorio>() , provider.GetService<IMenuRepositorio>());
            });
            services.AddScoped<IExecutor<ObterPedidoIdRequisicao, ObterPedidoIdResultado>>(provider =>
            {
                return new ObterPedidoIdExecutor(provider.GetService<IPedidoRepositorio>());
            });
            services.AddScoped<IExecutor<ObterPratoMenuRequisicao, ObterPratoMenuResultado>>(provider =>
            {
                return new ObterPratoMenuExecutor(provider.GetService<IMenuRepositorio>());
            });
            services.AddScoped<IExecutorSemResultado<InserirAvaliacaoRequisicao>>(provider =>
            {
                return new InserirAvaliacaoExecutor(provider.GetService<IAvaliacaoRepositorio>(), provider.GetService<IRestauranteRepositorio>());
            });
            services.AddScoped<IExecutorSemResultado<InserirMenuRestauranteRequisicao>>(provider =>
            {
                return new InserirMenuRestauranteExecutor(provider.GetService<IMenuRepositorio>(), provider.GetService<IRestauranteRepositorio>());
            });
            services.AddScoped<IExecutorSemResultado<ExcluirMenuRestauranteRequisicao>>(provider =>
            {
                return new ExcluirMenuRestauranteExecutor(provider.GetService<IMenuRepositorio>());
            });
            services.AddScoped<IExecutorSemResultado<AlterarMenuRestauranteRequisicao>>(provider =>
            {
                return new AlterarMenuRestauranteExecutor(provider.GetService<IMenuRepositorio>());
            });
            services.AddScoped<IExecutorSemResultado<AlterarPrecoMenuRequisicao>>(provider =>
            {
                return new AlterarPrecoMenuRestauranteExecutor(provider.GetService<IMenuRepositorio>());
            });
>>>>>>> Stashed changes
        }
    }
}
