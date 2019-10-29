using Dapper;
using MeatAppBackend.Entidades;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Utils.BancoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace MeatAppBackend.Repositorios.Avaliacao
{
	public class AvaliacaoRepositorio : RepositorioBase, IAvaliacaoRepositorio
	{ 
		#region Constantes
		
		private const string SQL_BASE_AVALIACOES = @"
			SELECT 
				Nome,
				Data,
				Nota,
				Comentario,
				RestauranteId
			FROM dbo.Avaliacao
			{0}
		";

		private const string SQL_BASE_INSERT_AVALIACAO = @"
		INSERT INTO dbo.Avaliacao
			(
			Nome,
			Data,
			Nota,
			Comentario,
			RestauranteId
			)
		VALUES 
			(
			{0},
			{1},
			{2},
			{3},
			{4}
			)";

		private readonly static string SQL_LISTAR_AVALIACOES = String.Format(SQL_BASE_AVALIACOES, "");
		private readonly static string SQL_OBTER_AVALIACAO_RESTAURANTE = String.Format(SQL_BASE_AVALIACOES, "WHERE RestauranteId = @RestauranteId");
		private readonly static string SQL_INSERIR_AVALIACAO = String.Format(SQL_BASE_INSERT_AVALIACAO, "@Nome", "@Data", "@Nota", "@Comentario", "@RestauranteId");
		#endregion
		#region Metodos Publicos

		public AvaliacaoRepositorio() : base("")
		{
		}

		public void InserirAvaliacao(AvaliacaoEntidade avaliacao)
		{
			using (var conexao = ObterConexao())
			{
				DynamicParameters parametros = new DynamicParameters();
				parametros.Add("Nome", avaliacao.Nome, DbType.AnsiString);
				parametros.Add("Data", avaliacao.Data, DbType.Date);
				parametros.Add("Nota", avaliacao.Nota, DbType.Double);
				parametros.Add("Comentario", avaliacao.Comentario, DbType.AnsiString);
				parametros.Add("RestauranteId", avaliacao.RestauranteID, DbType.AnsiString);

				conexao.Query<AvaliacaoEntidade>(SQL_INSERIR_AVALIACAO, parametros);
			}
		}

		public IEnumerable<AvaliacaoEntidade> ListarAvaliacao()
		{
			using (var conexao = ObterConexao())
			{
				return conexao.Query<AvaliacaoEntidade>(SQL_LISTAR_AVALIACOES, null);
			}
		}

		public IEnumerable<AvaliacaoEntidade> ObterAvaliacao(string restaurantID)
		{
			using (var conexao = ObterConexao())
			{
				DynamicParameters parametros = new DynamicParameters();
				parametros.Add("RestauranteId", restaurantID, DbType.AnsiString);

				return conexao.Query<AvaliacaoEntidade>(SQL_OBTER_AVALIACAO_RESTAURANTE, parametros);
			}

		}
		#endregion
	}
}
