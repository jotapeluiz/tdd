using System;
using Tdd;
using Xunit;

namespace ConversorTeste
{
	public class ConversorNumeroRomanoTeste
	{
		private ConversorNumeroRomano ConversorNumeroRomano;

		public ConversorNumeroRomanoTeste()
		{
			ConversorNumeroRomano = new ConversorNumeroRomano();
		}

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
			var numeroConvertido = ConversorNumeroRomano.ConververParaInteiro(simboloTestado);

			Assert.Equal(numeroEsperado, numeroConvertido);
		}

		[Theory]
		[InlineData("II", 2)]
		[InlineData("IiI", 3)]
		[InlineData("IX", 9)]
		[InlineData("Iv", 4)]
		[InlineData("xv", 15)]
		[InlineData("XXII", 22)]
		public void TesteDeveReconhecerDoisOuMaisSimbolos(string simboloTestado, int numeroEsperado)
		{
			var numeroConvertido = ConversorNumeroRomano.ConververParaInteiro(simboloTestado);

			Assert.Equal(numeroEsperado, numeroConvertido);
		}

		[Theory]
		[InlineData("")]
		[InlineData("  ")]
		[InlineData(null)]
		public void TesteDeveDispararExcecaoComValoresNulosOuVazios(string simboloTestado)
		{
			Action acao = () => ConversorNumeroRomano.ConververParaInteiro(simboloTestado);
			var exception = Assert.Throws<ArgumentException>(acao);

			Assert.Equal("Simbolo invalido", exception.Message);
		}

		[Theory]
		[InlineData("15")]
		[InlineData("-5")]
		[InlineData("33")]
		[InlineData("1v")]
		[InlineData("X2")]
		[InlineData("i2I")]
		public void TesteDeveFalharComNumeros(string simboloTestado)
		{
			var numeroConvertido = ConversorNumeroRomano.ConververParaInteiro(simboloTestado);

			Assert.Equal(-1, numeroConvertido);
		}

		[Fact(Skip = "Teste aguardando um impedimento qualquer")]
		public void TesteDevePularSuaExecucao()
		{
			/*
				Este teste não será executado porém não significa
				que está funcionando. Está apenas aguardando a sua
				conclusão.
			 */
			Assert.True(false);
		}
	}
}
