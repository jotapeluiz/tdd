using System;
using System.Collections.Generic;
using System.Text;

namespace Vendas
{
	public class Pedido
	{
		private ServicoCep ServicoCep;
		private ServicoFrete ServicoFrete;
		public Endereco EnderecoEntrega;

		public Pedido()
		{
			ServicoCep = new ServicoCep();
			ServicoFrete = new ServicoFrete();
		}
	}
}
