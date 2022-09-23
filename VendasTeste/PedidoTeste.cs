using System;
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

		[Fact]
		public void TesteDeveSetarEnderecoEntregaComCepValido()
		{
			var mockServicoFrete = new Mock<IServicoFrete>();
			var mockServicoCep = new Mock<IServicoCep>();

			var enderecoEntrega = new Endereco
			{
				Cep = "123456",
				Estado = "MG",
				Cidade = "Pocos de Caldas",
				Bairro = "Centro",
				Rua = "Assis Figueredo"
			};

			var pedido = new Pedido(mockServicoCep.Object, mockServicoFrete.Object);
			mockServicoCep.Setup(x => x.PesquisarEndereco("123456")).Returns(enderecoEntrega);

			pedido.SetarEnderecoEntrega("123456");

			Assert.Equal(enderecoEntrega, pedido.EnderecoEntrega);
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void TesteNaoDeveSetarEnderecoEntregaComCepInValido(string cepInvalido)
		{
			var mockServicoFrete = new Mock<IServicoFrete>();
			var mockServicoCep = new Mock<IServicoCep>();

			var pedido = new Pedido(mockServicoCep.Object, mockServicoFrete.Object);
			mockServicoCep.Setup(x => x.PesquisarEndereco(cepInvalido)).Throws<InvalidOperationException>();

			Assert.Throws<InvalidOperationException>(() => pedido.SetarEnderecoEntrega(cepInvalido));
		}
	}
}
