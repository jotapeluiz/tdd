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
	}
}
