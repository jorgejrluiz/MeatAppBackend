using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using MeatAppBackend.Entidades;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Utils.BancoDados;

namespace MeatAppBackend.Repositorios.Menu
{
	public class MenuRepositorio : RepositorioBase, IMenuRepositorio
	{
		#region Constantes
		
		private const string SQL_BASE_MENUS = @"
			   SELECT 
				Id,
				Imagem,
				Nome,
				Descricao,
				Preco,
				RestauranteId
			FROM dbo.Menu
			{0}
		";
		private const string SQL_INSERT_MENU = @"
			INSERT INTO dbo.Menu(
					Id,
					Imagem,
					Nome,
					Descricao,
					Preco,
					RestauranteId
					)
				VALUES 
					(
					{0},
					{1},
					{2},
					{3},
					{4},
					{5}
					)";

		private const string SQL_UPDATE_MENU = @"UPDATE dbo.Menu
			SET Imagem = {0},
			Nome = {1},
			Descricao = {2},
			Preco = {3},
			RestauranteId = {4}
			WHERE Id = {5}";
		private const string SQL_UPDATE_PRECO_MENU = @"UPDATE dbo.Menu
				SET preco = {0}
				WHERE Id = {1}";


		private const string SQL_DELETE_MENU = @"DELETE dbo.Menu FROM Menu WHERE Id = {0}";
		private readonly static string SQL_LISTAR_MENUS = String.Format(SQL_BASE_MENUS, "");
		private readonly static string SQL_OBTER_MENUS = String.Format(SQL_BASE_MENUS, "WHERE RestauranteId = @RestauranteId");
		private readonly static string SQL_OBTER_PRATOS = String.Format(SQL_BASE_MENUS, "WHERE Id = @Id");
		private readonly static string SQL_INSERIR_MENU = String.Format(SQL_INSERT_MENU, "@Id", "@Imagem", "@Nome", "@Descricao", "@Preco", "@RestauranteId");
		private readonly static string SQL_EXCLUIR_MENU = String.Format(SQL_DELETE_MENU, "@Id");
		private readonly static string SQL_ALTERAR_MENU = String.Format(SQL_UPDATE_MENU, "@Imagem", "@Nome", "@Descricao", "@Preco", "@RestauranteId", "@Id");
		private readonly static string SQL_ALTERAR_PRECO_MENU = String.Format(SQL_UPDATE_PRECO_MENU, "@Preco", "@Id");
		#endregion
		#region Metodos Publicos
		public MenuRepositorio() : base("")
		{
		}

		public void AlterarMenu(MenuEntidade Menu)
		{
			using (var conexao = ObterConexao())
			{
				DynamicParameters parametros = new DynamicParameters();
				parametros.Add("Id", Menu.Id, DbType.AnsiString);
				parametros.Add("Imagem", Menu.Imagem, DbType.AnsiString);
				parametros.Add("Nome", Menu.Nome, DbType.AnsiString);
				parametros.Add("Descricao", Menu.Descricao, DbType.AnsiString);
				parametros.Add("Preco", Menu.Preco, DbType.AnsiString);
				parametros.Add("RestauranteId", Menu.RestauranteID, DbType.AnsiString);
				conexao.Query<MenuEntidade>(SQL_ALTERAR_MENU, parametros);
			}
		}

		public void AlterarPrecoMenu(string Id, double preco)
		{
			using (var conexao = ObterConexao())
			{
				DynamicParameters parametros = new DynamicParameters();
				parametros.Add("Preco", preco, DbType.AnsiString);
				parametros.Add("Id", Id, DbType.AnsiString);
				conexao.Query<RestauranteEntidade>(SQL_ALTERAR_PRECO_MENU, parametros);
			}
		}

		public void ExcluirMenuRestaurante(string Id)
		{
			using (var conexao = ObterConexao())
			{
				DynamicParameters parametros = new DynamicParameters();
				parametros.Add("Id", Id, DbType.AnsiString);
				conexao.Query<RestauranteEntidade>(SQL_EXCLUIR_MENU, parametros);
			}
		}

		public void InserirMenuRestaurante(MenuEntidade Menu)
		{
			using (var conexao = ObterConexao())
			{
				DynamicParameters parametros = new DynamicParameters(); 
				parametros.Add("Id", Menu.Id, DbType.AnsiString);
				parametros.Add("Imagem", Menu.Imagem, DbType.AnsiString);
				parametros.Add("Nome", Menu.Nome, DbType.AnsiString);
				parametros.Add("Descricao", Menu.Descricao, DbType.AnsiString);
				parametros.Add("Preco", Menu.Preco, DbType.AnsiString);
				parametros.Add("RestauranteId", Menu.RestauranteID, DbType.AnsiString);
				conexao.Query<MenuEntidade>(SQL_INSERIR_MENU, parametros);
			}
		}

		public IEnumerable<MenuEntidade> ListarMenuRestaurante()
		{
			using (var conexao = ObterConexao())
			{
				return conexao.Query<MenuEntidade>(SQL_LISTAR_MENUS, null);
			}
		}

		public IEnumerable<MenuEntidade> ObterMenuRestaurante(string RestauranteId)
		{
			using (var conexao = ObterConexao())
			{
				DynamicParameters parametros = new DynamicParameters();
				parametros.Add("RestauranteId", RestauranteId, DbType.AnsiString);

				return conexao.Query<MenuEntidade>(SQL_OBTER_MENUS, parametros);
			}
		}

		public MenuEntidade ObterPratoMenu(string Id)
		{
			using (var conexao = ObterConexao())
			{
				DynamicParameters parametros = new DynamicParameters();
				parametros.Add("Id", Id, DbType.AnsiString);
				return conexao.Query<MenuEntidade>(SQL_OBTER_PRATOS, parametros).FirstOrDefault();
			}
		}


		#endregion
	}
}
