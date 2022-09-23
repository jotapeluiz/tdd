using System;
using Vendas;
using Xunit;

namespace VendasTeste
{
	public class ProdutoTeste
	{
		[Fact]
		public void TesteDeveCalcularValorTotal()
		{
			var produto = new Produto
			{
				Nome = "Tesoura",
				ValorUnitario = 10,
				Quantidade = 5
			};

			Assert.Equal(50, produto.CalcularValorTotal());
		}

		[Theory]
		[InlineData(10, -10)]
		[InlineData(-10, 10)]
		[InlineData(-10, -10)]
		public void TesteDeveDispararExcecaoComValoresNegativos(int valorNegativo, int quantidadeNegativa)
		{
			var produto = new Produto
			{
				Nome = "Tesoura",
				ValorUnitario = valorNegativo,
				Quantidade = quantidadeNegativa
			};

			Assert.Throws<InvalidOperationException>(() => produto.CalcularValorTotal());
		}
	}
}
