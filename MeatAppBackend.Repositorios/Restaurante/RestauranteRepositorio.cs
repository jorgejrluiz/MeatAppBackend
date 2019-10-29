using MeatAppBackend.Entidades;
using MeatAppBackend.Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
<<<<<<< Updated upstream
=======
using System.Linq;
using MeatAppBackend.Utils.Excecoes;
>>>>>>> Stashed changes

namespace MeatAppBackend.Repositorios.Restaurante
{
    public class RestauranteRepositorio : IRestauranteRepositorio
    {
        #region Constantes
        private static readonly RestauranteEntidade[] Restaurantes =
        {
            new RestauranteEntidade()
            {
                Id = "burger-house",
                Nome = "Burger House",
                Categoria = "Hamburgers",
                TempoEntrega = "100m",
                Avaliacao = 3.5,
                Imagem = "assets/img/restaurants/burgerhouse.png",
                Sobre = "40 anos se especializando em trash food.",
                Funcionamento = "Funciona todos os dias, de 10h às 22h"
            },
            new RestauranteEntidade()
            {
                Id = "coffee-corner",
                Nome = "Coffee Corner",
                Categoria = "Coffee Shop",
                TempoEntrega = "30-40m",
                Avaliacao = 4.8,
                Imagem = "assets/img/restaurants/coffeecorner.png",
                Sobre = "A Coffe Corner foi eleita a melhor cafeteria da cidade.",
                Funcionamento = "Funciona de segunda à sábado, de 6h às 22h"
            },
            new RestauranteEntidade()
            {
                Id = "green-food",
                Nome = "Green Food",
                Categoria = "Saudável",
                TempoEntrega = "75m",
                Avaliacao = 4.1,
                Imagem = "assets/img/restaurants/greenfood.png",
                Sobre = "Comida saudável é no Green Food. Compramos barato, vendemos caro. ;)",
                Funcionamento = "Somente em horário de almoço, das 11h às 15h"
            },
            new RestauranteEntidade()
            {
                Id = "ice-cream",
                Nome = "Ice Cream",
                Categoria = "Ice Creams",
                TempoEntrega = "40-65m",
                Avaliacao = 4.5,
                Imagem = "assets/img/restaurants/icy.png",
                Sobre = "A Ice Cream é uma sorveteria inovadora.",
                Funcionamento = "Funciona todos os dias, de 10h às 1h"
            },
            new RestauranteEntidade()
            {
                Id = "ice-cream",
                Nome = "Ice Cream",
                Categoria = "Ice Creams",
                TempoEntrega = "40-65m",
                Avaliacao = 4.5,
                Imagem = "assets/img/restaurants/icy.png",
                Sobre = "A Ice Cream é uma sorveteria inovadora.",
                Funcionamento = "Funciona todos os dias, de 10h às 1h"
            },
            new RestauranteEntidade()
            {
                Id = "tasty-treats",
                Nome = "Tasty Treats",
                Categoria = "Doces",
                TempoEntrega = "20m",
                Avaliacao = 4.4,
                Imagem = "assets/img/restaurants/tasty.png",
                Sobre = "A doceria com mais tradição da cidade",
                Funcionamento = "Funciona de segunda à sábado, de 8h às 23h"
            }
        };
        #endregion

<<<<<<< Updated upstream
        #region Metodos Publicos
        public IEnumerable<RestauranteEntidade> ListarRestaurantes()
        {
            return Restaurantes;
        }
        #endregion
    }
=======
		private const string SQL_BASE_RESTAURANTES = @"
			SELECT 
				Id,
				Nome,
				Categoria,
				TempoEntrega,
				Avaliacao,
				Imagem,
				Sobre,
				Funcionamento
			FROM dbo.Restaurante
			{0}
		";

		private const string SQL_BASE_INSERT = @"INSERT INTO dbo.Restaurante
				(
				Id,
				Nome,
				Categoria,
				TempoEntrega,
				Avaliacao,
				Imagem,
				Sobre,
				Funcionamento
				)
			VALUES 
				(
				{0},
				{1},
				{2},
				{3},
				{4},
				{5},
				{6},
				{7})";

		private const string SQL_BASE_UPDATE = @"UPDATE dbo.Restaurante
		SET Nome = {0},
			Categoria = {1},
			TempoEntrega = {2},
			Avaliacao = {3},
			Imagem = {4},
			Sobre = {5},
			Funcionamento = {6}
		WHERE Id = {7} ";

		private const string SQL_UPDATE_AVALIACAO = @"UPDATE dbo.Restaurante
		SET Avaliacao = {0}
		WHERE Id = {1} ";

		private const string SQL_DELETE_RESTAURANTE = @"DELETE dbo.Restaurante FROM Restaurante WHERE Id = {0}";
		private readonly static string SQL_LISTAR_RESTAURANTES = String.Format(SQL_BASE_RESTAURANTES, "");
		private readonly static string SQL_OBTER_RESTAURANTE = String.Format(SQL_BASE_RESTAURANTES, "WHERE Id = @Id");
		private readonly static string SQL_INSERIR_RESTAURANTE = String.Format(SQL_BASE_INSERT, "@Id", "@Nome", "@Categoria","@TempoEntrega","@Avaliacao","@Imagem","@Sobre", "@Funcionamento");
		private readonly static string SQL_EXCLUIR_RESTAURANTE = String.Format(SQL_DELETE_RESTAURANTE, "@Id");
		private readonly static string SQL_ALTERAR_RESTAURANTE = String.Format(SQL_BASE_UPDATE, "@Nome", "@Categoria", "@TempoEntrega", "@Avaliacao", "@Imagem", "@Sobre", "@Funcionamento", "@Id");
		private readonly static string SQL_ALTERAR_AVALIACAO = String.Format(SQL_UPDATE_AVALIACAO, "@Avaliacao", "@Id");
		
		#endregion

		#region Metodos Publicos
		public RestauranteRepositorio() : base("")
		{
		}

		public IEnumerable<RestauranteEntidade> ListarRestaurantes()
		{
			using (var conexao = ObterConexao())
			{
				return conexao.Query<RestauranteEntidade>(SQL_LISTAR_RESTAURANTES, null);
			}
			
		}

		public RestauranteEntidade ObterRestaurante(string restauranteId)
		{
			using (var conexao = ObterConexao())
			{
				DynamicParameters parametros = new DynamicParameters();
				parametros.Add("Id", restauranteId, DbType.AnsiString);

				return conexao.Query<RestauranteEntidade>(SQL_OBTER_RESTAURANTE, parametros).FirstOrDefault();
			}

		}

		public void InserirRestaurante(RestauranteEntidade restaurante)//string restauranteId, string Nome, string Categoria, string TempoEntrega, double Avaliacao, string Imagem, string Sobre, string Funcionamento)
		{
			using (var conexao = ObterConexao())
			{
				DynamicParameters parametros = new DynamicParameters();
				parametros.Add("Id", restaurante.Id, DbType.AnsiString);
				parametros.Add("Nome", restaurante.Nome, DbType.AnsiString);
				parametros.Add("Categoria", restaurante.Categoria, DbType.AnsiString);
				parametros.Add("TempoEntrega", restaurante.TempoEntrega, DbType.AnsiString);
				parametros.Add("Avaliacao", restaurante.Avaliacao, DbType.Double);
				parametros.Add("Imagem", restaurante.Imagem, DbType.AnsiString);
				parametros.Add("Sobre", restaurante.Sobre, DbType.AnsiString);
				parametros.Add("Funcionamento", restaurante.Funcionamento, DbType.AnsiString);
				

				conexao.Query<RestauranteEntidade>(SQL_INSERIR_RESTAURANTE, parametros);
			}
		}

		public void ExcluirRestaurante(string restauranteId)
		{
			using (var conexao = ObterConexao())
			{
				DynamicParameters parametros = new DynamicParameters();
				parametros.Add("Id", restauranteId, DbType.AnsiString);
				conexao.Query<RestauranteEntidade>(SQL_EXCLUIR_RESTAURANTE, parametros);
			}		
		}

		public void AlterarRestaurante(RestauranteEntidade restaurante)
		{
			using (var conexao = ObterConexao())
			{
				DynamicParameters parametros = new DynamicParameters();
				parametros.Add("Id", restaurante.Id, DbType.AnsiString);
				parametros.Add("Nome", restaurante.Nome, DbType.AnsiString);
				parametros.Add("Categoria", restaurante.Categoria, DbType.AnsiString);
				parametros.Add("TempoEntrega", restaurante.TempoEntrega, DbType.AnsiString);
				parametros.Add("Avaliacao", restaurante.Avaliacao, DbType.Double);
				parametros.Add("Imagem", restaurante.Imagem, DbType.AnsiString);
				parametros.Add("Sobre", restaurante.Sobre, DbType.AnsiString);
				parametros.Add("Funcionamento", restaurante.Funcionamento, DbType.AnsiString);


				conexao.Query<RestauranteEntidade>(SQL_ALTERAR_RESTAURANTE, parametros);
			}
		}

		public void AlterarAvaliacaoRestaurante(string restauranteId, double Avaliacao)
		{
			using (var conexao = ObterConexao())
			{
				DynamicParameters parametros = new DynamicParameters();
				parametros.Add("Id", restauranteId, DbType.AnsiString);
				parametros.Add("Avaliacao", Avaliacao, DbType.Double);

				conexao.Query<RestauranteEntidade>(SQL_ALTERAR_AVALIACAO, parametros);
			}
		}
		#endregion
	}
>>>>>>> Stashed changes
}
