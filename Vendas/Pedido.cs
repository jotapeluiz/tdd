namespace Vendas
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
	}
}
