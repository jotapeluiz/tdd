﻿namespace Vendas
{
	public class Pedido
	{
		private IServicoCep ServicoCep;
		private IServicoFrete ServicoFrete;
		public Endereco EnderecoEntrega;

		public Pedido(IServicoCep servicoCep, IServicoFrete servicoFrete)
		{
			ServicoCep = servicoCep;
			ServicoFrete = servicoFrete;
		}

		public int CalcularValorTotal(string cepLoja, string cepCliente, CarrinhoDeCompras carrinhoDeCompras)
		{
			var valorCarrinho = carrinhoDeCompras.CalcularValorCarrinho();
			var valorFrete = ServicoFrete.CalcularFrete(cepLoja, cepCliente);

			return valorCarrinho + valorFrete;
		}
	}
}
