using System.Collections.Generic;

namespace Vendas
{
	public class CarrinhoDeCompras
	{
		private List<Produto> Produtos;

		public CarrinhoDeCompras()
		{
			Produtos = new List<Produto>();
		}

		public void AdicionarNoCarrinho(Produto produto)
		{
			
		}

		public bool VerificarCarrinhoVazio()
		{
			return true;
		}

		public int CalcularValorCarrinho()
		{
			return 0;
		}
	}
}
