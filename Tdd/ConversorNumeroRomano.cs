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

			if (SimbolosRomanos.ContainsKey(algarismoRomano))
			{
				return SimbolosRomanos[algarismoRomano];
			}

			return 0;
		}
	}
}
