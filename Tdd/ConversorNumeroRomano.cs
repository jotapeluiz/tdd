using System;
using System.Collections.Generic;

namespace Tdd
{
	public class ConversorNumeroRomano
	{
		private Dictionary<string, int> SimbolosRomanos;

		public ConversorNumeroRomano()
		{
			SimbolosRomanos = new Dictionary<string, int>
			{
				{ "I", 1 },
				{ "V", 5 },
				{ "X", 10 },
				{ "L", 50 },
				{ "C", 100 },
				{ "D", 500 },
				{ "M", 1000 }
			};
		}

		public int ConververParaInteiro(string simbolo)
		{
			if (string.IsNullOrEmpty(simbolo?.Trim()))
			{
				throw new ArgumentException("Simbolo invalido");
			}

			var algarismoRomano = simbolo.ToUpper();
			var acumulador = 0;
			var ultimoVizinhoDaDireita = 0;

			for (int indice = algarismoRomano.Length - 1; indice >= 0; indice--)
			{
				// pega o inteiro referente ao símbolo atual
				var atual = 0;
				var algarismoCorrente = algarismoRomano[indice].ToString();

				if (int.TryParse(algarismoCorrente, out int numero))
				{
					return -1;
				}

				if (SimbolosRomanos.ContainsKey(algarismoCorrente))
				{
					atual = SimbolosRomanos[algarismoCorrente];

					// se o da direita for menor, o multiplicamos por -1 para torná-lo negativo
					var multiplicador = 1;

					if (atual < ultimoVizinhoDaDireita)
					{
						multiplicador = -1;
					}

					acumulador += atual * multiplicador;
					// atualiza o vizinho da direita
					ultimoVizinhoDaDireita = atual;
				}
			}

			return acumulador;
		}
	}
}
