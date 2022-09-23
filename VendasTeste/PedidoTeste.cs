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
			mockServicoFrete.Setup(x => x.CalcularFrete(It.IsAny<string>(), It.IsAny<string>())).Returns(100);

			Assert.Equal(103, pedido.CalcularValorTotal(It.IsAny<string>(), It.IsAny<string>(), carrinhoDeCompras));
		}
	}
}
