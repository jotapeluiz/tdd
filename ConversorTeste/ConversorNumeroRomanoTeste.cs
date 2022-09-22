using Tdd;
using Xunit;

namespace ConversorTeste
{
	public class ConversorNumeroRomanoTeste
	{
		[Fact]
		public void TesteDeveReconhecerSimboloI()
		{
			var conversorNumeroRomano = new ConversorNumeroRomano();
			var resultadoEsperado = 1;
			var simboloConvertido = conversorNumeroRomano.ConververParaInteiro("I");

			Assert.Equal(resultadoEsperado, simboloConvertido);
		}

		[Fact]
		public void TesteDeveReconhecerSimboloV()
		{
			var conversorNumeroRomano = new ConversorNumeroRomano();
			var resultadoEsperado = 5;
			var simboloConvertido = conversorNumeroRomano.ConververParaInteiro("V");

			Assert.Equal(resultadoEsperado, simboloConvertido);
		}
	}
}
