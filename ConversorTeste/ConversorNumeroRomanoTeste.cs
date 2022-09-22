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
	}
}
