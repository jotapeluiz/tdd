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
		[InlineData("c", 100)]
		[InlineData("D", 500)]
		[InlineData("M", 1000)]
		public void TesteDeveReconhecerUmSimbolo(string simboloTestado, int numeroEsperado)
		{
			var conversorNumeroRomano = new ConversorNumeroRomano();
			var numeroConvertido = conversorNumeroRomano.ConververParaInteiro(simboloTestado);

			Assert.Equal(numeroEsperado, numeroConvertido);
		}

		[Fact]
		public void TesteDeveReconhecerDoisSimbolosIguais()
		{
			var conversorNumeroRomano = new ConversorNumeroRomano();
			var numeroConvertido = conversorNumeroRomano.ConververParaInteiro("II");

			Assert.Equal(2, numeroConvertido);
		}

		[Fact(Skip = "Teste aguardando um impedimento qualquer")]
		public void TesteDevePularSuaExecucao()
		{
			/*
				Este teste n�o ser� executado por�m n�o significa
				que est� funcionando. Est� apenas aguardando a sua
				conclus�o.
			 */
			Assert.True(false);
		}
	}
}
