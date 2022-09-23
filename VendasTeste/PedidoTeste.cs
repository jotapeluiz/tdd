using System;
using Moq;
using Vendas;
using Xunit;

namespace VendasTeste
{
	public class PedidoTeste
	{
		private Pedido Pedido;
		private CarrinhoDeCompras CarrinhoDeCompras;
		private Mock<IServicoCep> MockServicoCep;
		private Mock<IServicoFrete> MockServicoFrete;

		public PedidoTeste()
		{
			CarrinhoDeCompras = new CarrinhoDeCompras();
			MockServicoCep = new Mock<IServicoCep>();
			MockServicoFrete = new Mock<IServicoFrete>();
			Pedido = new Pedido(MockServicoCep.Object, MockServicoFrete.Object);
		}

		[Fact]
		public void TesteDeveCalcularOValorDoPedido()
		{
			CarrinhoDeCompras.AdicionarNoCarrinho(new Produto { Nome = "Lapis", ValorUnitario = 3 });
			MockServicoFrete.Setup(x => x.CalcularFrete("1234", "4567")).Returns(100);

			Assert.Equal(103, Pedido.CalcularValorTotal("1234", "4567", CarrinhoDeCompras));
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void TesteNaoDeveCalcularOValorDoPedido(string cepInvalido)
		{
			CarrinhoDeCompras.AdicionarNoCarrinho(new Produto { Nome = "Lapis", ValorUnitario = 3 });
			Pedido.CalcularValorTotal(cepInvalido, It.IsAny<string>(), CarrinhoDeCompras);
			MockServicoFrete.Verify(x => x.CalcularFrete(cepInvalido, It.IsAny<string>()), Times.Never());
		}

		[Fact]
		public void TesteDeveSetarEnderecoEntregaComCepValido()
		{
			var enderecoEntrega = new Endereco
			{
				Cep = "123456",
				Estado = "MG",
				Cidade = "Pocos de Caldas",
				Bairro = "Centro",
				Rua = "Assis Figueredo"
			};

			MockServicoCep.Setup(x => x.PesquisarEndereco("123456")).Returns(enderecoEntrega);
			Pedido.SetarEnderecoEntrega("123456");

			Assert.Equal(enderecoEntrega, Pedido.EnderecoEntrega);
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void TesteNaoDeveSetarEnderecoEntregaComCepInValido(string cepInvalido)
		{
			MockServicoCep.Setup(x => x.PesquisarEndereco(cepInvalido)).Throws<InvalidOperationException>();

			Assert.Throws<InvalidOperationException>(() => Pedido.SetarEnderecoEntrega(cepInvalido));
		}
	}
}
