using System;
using System.Collections.Generic;
using System.Text;

namespace Vendas
{
	public class ServicoCep	: IServicoCep
	{
		/*
			Método que simula a consulta a uma API
			que retorna um endereço baseado no CEP
		 */
		public Endereco PesquisarEndereco(string cep)
		{
			if (string.IsNullOrEmpty(cep))
			{
				throw new InvalidOperationException();
			}

			return new Endereco
			{
				Cep = cep,
				Estado = "MG",
				Cidade = "Poços de Caldas",
				Bairro = "Centro",
				Rua = "Assis Figueiredo"
			};
		}
	}
}
