using Moq;
using Vendas;
using Xunit;

namespace VendasTeste
{
	public class PedidoTeste
	{
		[Fact]
		public void TesteDeveCalcularOValorDoPedido()
		{
			var carrinhoDeCompras = new CarrinhoDeCompras();
			carrinhoDeCompras.AdicionarNoCarrinho(new Produto { Nome = "Lapis", ValorUnitario = 3 });

			var mockServicoFrete = new Mock<IServicoFrete>();
			var mockServicoCep = new Mock<IServicoCep>();

			var pedido = new Pedido(mockServicoCep.Object, mockServicoFrete.Object);
			mockServicoFrete.Setup(x => x.CalcularFrete("1234", "4567")).Returns(100);

			Assert.Equal(103, pedido.CalcularValorTotal("1234", "4567", carrinhoDeCompras));
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void TesteNaoDeveCalcularOValorDoPedido(string cepInvalido)
		{
			var carrinhoDeCompras = new CarrinhoDeCompras();
			carrinhoDeCompras.AdicionarNoCarrinho(new Produto { Nome = "Lapis", ValorUnitario = 3 });

			var mockServicoFrete = new Mock<IServicoFrete>();
			var mockServicoCep = new Mock<IServicoCep>();

			var pedido = new Pedido(mockServicoCep.Object, mockServicoFrete.Object);

			pedido.CalcularValorTotal(cepInvalido, It.IsAny<string>(), carrinhoDeCompras);
			mockServicoFrete.Verify(x => x.CalcularFrete(cepInvalido, It.IsAny<string>()), Times.Never());
		}
	}
}
