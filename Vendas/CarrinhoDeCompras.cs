using System.Collections.Generic;
using System.Linq;

namespace Vendas
{
	public class CarrinhoDeCompras
	{
		private List<Produto> Produtos;

		public CarrinhoDeCompras()
		{
			Produtos = new List<Produto>();
		}

		public List<Produto> ObterListaProdutos()
		{
			return Produtos;
		}

		public void AdicionarNoCarrinho(Produto produto)
		{
			Produtos.Add(produto);
		}

		public bool VerificarCarrinhoVazio()
		{
			return Produtos.Count == 0;
		}

		public int CalcularValorCarrinho()
		{
			return Produtos.Select(x => x.CalcularValorTotal()).Sum();
		}
	}
}
