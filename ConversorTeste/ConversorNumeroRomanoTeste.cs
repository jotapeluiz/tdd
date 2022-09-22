using Tdd;
using Xunit;

namespace ConversorTeste
{
	public class ConversorNumeroRomanoTeste
	{
		[Theory]
		[InlineData("I", 1)]
		[InlineData("V", 5)]
		[InlineData("X", 10)]
		[InlineData("L", 50)]
		[InlineData("C", 100)]
		[InlineData("D", 500)]
		[InlineData("M", 1000)]
		public void TesteDeveReconhecerUmSimbolo(string simboloTestado, int numeroEsperado)
		{
			var conversorNumeroRomano = new ConversorNumeroRomano();
			var numeroConvertido = conversorNumeroRomano.ConververParaInteiro(simboloTestado);

			Assert.Equal(numeroEsperado, numeroConvertido);
		}
	}
}
