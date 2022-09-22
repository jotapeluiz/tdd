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
			var algarismoRomano = simbolo.ToUpper();
			var acumulador = 0;

			foreach (var algarismo in algarismoRomano)
			{
				if (SimbolosRomanos.ContainsKey(algarismo.ToString()))
				{
					acumulador += SimbolosRomanos[algarismo.ToString()];
				}
			}

			return acumulador;
		}
	}
}
