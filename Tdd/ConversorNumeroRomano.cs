using System;

namespace Tdd
{
	public class ConversorNumeroRomano
	{
		public int ConververParaInteiro(string simbolo)
		{
			if (simbolo == "I")
			{
				return 1;
			}

			if (simbolo == "V")
			{
				return 5;
			}

			return 0;
		}
	}
}
