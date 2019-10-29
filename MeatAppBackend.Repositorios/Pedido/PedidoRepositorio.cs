using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using MeatAppBackend.Entidades;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Utils.BancoDados;

namespace MeatAppBackend.Repositorios.Pedido
{
	public class PedidoRepositorio : RepositorioBase, IPedidoRepositorio
	{
		#region Constantes
		
		private const string SQL_BASE_PEDIDOS = @"
			SELECT
				Endereco,
				Numero,
				EnderecoOpcional,
				FormaPagamento,
				Id
			FROM dbo.Pedido
			{0}
		";

		private readonly static string SQL_OBTER_PEDIDOS_RESTAURANTE_BASE = @"
		SELECT
		NOME,
		ItensPedidos.IdPedido,
		ItensPedidos.quantidade
		FROM Menu,ItensPedidos
		WHERE Id = ItensPedidos.IdMenu
		AND RestauranteId = {0}";

		private readonly static string SQL_INSERT_PEDIDO = @"INSERT INTO dbo.Pedido
			(
			Endereco,
			Numero,
			EnderecoOpcional,
			FormaPagamento,
			Id
			)
		VALUES 
			(
			{0},
			{1},
			{2},
			{3},
			{4}
			)";

		private readonly static string SQL_INSERT_PEDIDO_ITEM = @"INSERT INTO dbo.ItensPedidos
			(
			IdItensPedidos,
			IdPedido,
			IdMenu,
			quantidade
			)
		VALUES 
			(
			{0},
			{1},
			{2},
			{3}
			)";


		private readonly static string SQL_INSERIR_PEDIDO = String.Format(SQL_INSERT_PEDIDO, "@Endereco", "@Numero", "@EnderecoOpcional", "@FormaPagamento","@Id");
		private readonly static string SQL_INSERIR_PEDIDO_ITEM = String.Format(SQL_INSERT_PEDIDO_ITEM, "@IdItensPedidos", "@IdPedido", "@IdMenu", "@quantidade");
		private readonly static string SQL_LISTAR_PEDIDOS = String.Format(SQL_BASE_PEDIDOS, "");
		private readonly static string SQL_OBTER_PEDIDOS_RESTAURANTE = String.Format(SQL_OBTER_PEDIDOS_RESTAURANTE_BASE, "@RestauranteId");
		private readonly static string SQL_OBTER_PEDIDO = String.Format(SQL_BASE_PEDIDOS, "Where id = @Id");
		#endregion
		#region Metodos Publicos

		public PedidoRepositorio() : base("")
		{
		}

		public void InserirPedidoEntrega(PedidoEntidade pedido)
		{
			using (var conexao = ObterConexao())
			{
				DynamicParameters parametros = new DynamicParameters();

				parametros.Add("Endereco", pedido.Endereco, DbType.AnsiString);
				parametros.Add("Numero", pedido.Numero, DbType.AnsiString);
				parametros.Add("EnderecoOpcional", pedido.EnderecoOpcional, DbType.AnsiString);
				parametros.Add("FormaPagamento", pedido.FormaPagamento, DbType.AnsiString);
				parametros.Add("Id", pedido.Id, DbType.Int16);
				conexao.Query<PedidoRestauranteEntidade>(SQL_INSERIR_PEDIDO, parametros);
			}
		}

		public void InserirPedidoRestaurante(PedidoRestauranteEntidade pedidoItens)
		{
			using (var conexao = ObterConexao())
			{
				DynamicParameters parametros = new DynamicParameters();

				parametros.Add("IdItensPedidos", pedidoItens.Id, DbType.AnsiString);
				parametros.Add("IdPedido", pedidoItens.IdPedido, DbType.AnsiString);
				parametros.Add("IdMenu", pedidoItens.Nome, DbType.AnsiString);
				parametros.Add("quantidade", pedidoItens.Quantidade, DbType.AnsiString);
				conexao.Query<PedidoRestauranteEntidade>(SQL_INSERIR_PEDIDO_ITEM, parametros);
			}
		}

		public IEnumerable<PedidoEntidade> ListarPedidos()
		{
			using (var conexao = ObterConexao())
			{
				return conexao.Query<PedidoEntidade>(SQL_LISTAR_PEDIDOS, null);
			}
		}

		public PedidoEntidade ObterPedido(int id)
		{
			using (var conexao = ObterConexao())
			{
				DynamicParameters parametros = new DynamicParameters();
				parametros.Add("Id", id, DbType.AnsiString);

				return conexao.Query<PedidoEntidade>(SQL_OBTER_PEDIDO, parametros).FirstOrDefault();
			}
		}

		public IEnumerable<PedidoRestauranteEntidade> ObterPedidos(string restauranteId)
		{
			using (var conexao = ObterConexao())
			{
				DynamicParameters parametros = new DynamicParameters();
				parametros.Add("RestauranteId", restauranteId, DbType.AnsiString);

				return conexao.Query<PedidoRestauranteEntidade>(SQL_OBTER_PEDIDOS_RESTAURANTE, parametros);
			}
		}

		
		#endregion
	}
}
