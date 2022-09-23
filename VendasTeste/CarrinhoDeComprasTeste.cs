using System;
using System.Collections.Generic;
using System.Text;
using Vendas;
using Xunit;

namespace VendasTeste
{
	public class CarrinhoDeComprasTeste
	{
		private CarrinhoDeCompras CarrinhoDeCompras;

		public CarrinhoDeComprasTeste()
		{
			CarrinhoDeCompras = new CarrinhoDeCompras();
		}

		[Fact]
		public void TesteDeveRetornarFalseSeCarrinhoEstiverVazio()
		{
			CarrinhoDeCompras.AdicionarNoCarrinho(new Produto { Nome = "Borracha", ValorUnitario = 4 });

			Assert.False(CarrinhoDeCompras.VerificarCarrinhoVazio());
		}

		[Fact]
		public void TesteRetornarZeroSeCarrinhoVazio()
		{
			Assert.Equal(0, CarrinhoDeCompras.CalcularValorCarrinho());
		}

		[Fact]
		public void TesteSomarOsItensDoCarrinho()
		{
			CarrinhoDeCompras.AdicionarNoCarrinho(new Produto { Nome = "Lapis", ValorUnitario = 5 });
			CarrinhoDeCompras.AdicionarNoCarrinho(new Produto { Nome = "Papel", ValorUnitario = 2, Quantidade = 20 });

			Assert.Equal(45, CarrinhoDeCompras.CalcularValorCarrinho());
		}

		[Fact]
		public void TesteDeveAdicionarItensNoCarrinho()
		{
			var lapis = new Produto { Nome = "Lápis", ValorUnitario = 5 };
			var prego = new Produto { Nome = "Prego", ValorUnitario = 3 };

			CarrinhoDeCompras.AdicionarNoCarrinho(lapis);
			CarrinhoDeCompras.AdicionarNoCarrinho(prego);

			var produtosNoCarrinho = CarrinhoDeCompras.ObterListaProdutos();

			Assert.Collection(produtosNoCarrinho, 
				produto => produto.Equals(lapis),
				produto => produto.Equals(prego)
			);
		}
	}
}
