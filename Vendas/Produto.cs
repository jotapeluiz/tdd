using System;
using System.Collections.Generic;
using System.Text;

namespace Vendas
{
	public class Produto
	{
		public string Nome { get; set; }
		public int ValorUnitario { get; set; }
		public int Quantidade { get; set; } = 1;

		public int CalcularValorTotal()
		{
			if (ValorUnitario < 0 || Quantidade < 0)
			{
				throw new InvalidOperationException();
			}

			return ValorUnitario * Quantidade;
		}
	}
}
