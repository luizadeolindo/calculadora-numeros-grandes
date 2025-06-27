namespace CalculadoraNumerosGrandes.Tests;

public class CalculadoraNumerosGrandesTests
{
    [Fact]
    public void Somar_ComNumerosGrandes_DeveRetornarSomaCorreta()
    {
        string resultado = Calculadora.Somar("30", "70");

        Assert.Equal("100", resultado);
    }

    [Fact]
    public void Somar_NumerosDeTamanhosDiferentes_DeveRetornarSomaCorreta()
    {
        string resultado = Calculadora.Somar("1", "999");
        Assert.Equal("1000", resultado);
    }

    [Fact]
    public void Somar_ComZero_DeveRetornarOutroNumero()
    {
        string resultado = Calculadora.Somar("12345", "0");
        Assert.Equal("12345", resultado);
    }

    [Fact]
    public void Somar_ComNumerosGigantes_DeveRetornarSomaCorreta()
    {
        string numeroGigante1 = new string('9', 10000);
        string numeroGigante2 = "1";

        string resultado = Calculadora.Somar(numeroGigante1, numeroGigante2);

        string esperado = "1" + new string('0', 10000);

        Assert.Equal(esperado, resultado);
    }

    [Fact]
    public void Somar_ComNumerosMuitoGigantes_DeveRetornarSomaCorreta()
    {
        string numeroGigante1 = new string('9', 1000000); // 1 milhão de dígitos
        string numeroGigante2 = "1";

        string resultado = Calculadora.Somar(numeroGigante1, numeroGigante2);

        string esperado = "1" + new string('0', 1000000);

        Assert.Equal(esperado, resultado);
    }




    [Fact]
    public void Subtrair_ComNumerosGrandes_DeveRetornarSubtracaoCorreta()
    {
        string numero1 = "1000";
        string numero2 = "1";

        string resultado = Calculadora.Subtrair(numero1, numero2);

        Assert.Equal("999", resultado);
    }

    [Fact]
    public void Subtrair_NumerosIguais_DeveRetornarZero()
    {
        string resultado = Calculadora.Subtrair("5000", "5000");
        Assert.Equal("0", resultado);
    }

    [Fact]
    public void Subtrair_ComZero_DeveRetornarOutroNumero()
    {
        string resultado = Calculadora.Subtrair("789", "0");
        Assert.Equal("789", resultado);
    }


    [Fact]
    public void Multiplicar_ComNumerosGrandes_DeveRetornarMultiplicacaoCorreta()
    {
        string numero1 = "1234";
        string numero2 = "56";

        string resultado = Calculadora.Multiplicar(numero1, numero2);

        Assert.Equal("69104", resultado);
    }

    [Fact]
    public void Multiplicar_PorZero_DeveRetornarZero()
    {
        string resultado = Calculadora.Multiplicar("123456789", "0");
        Assert.Equal("0", resultado);
    }

    [Fact]
    public void Multiplicar_PorUm_DeveRetornarMesmoNumero()
    {
        string resultado = Calculadora.Multiplicar("98765", "1");
        Assert.Equal("98765", resultado);
    }

    [Fact]
    public void Multiplicar_NumerosDeTamanhosDiferentes_DeveRetornarCorreto()
    {
        string resultado = Calculadora.Multiplicar("123", "45");
        Assert.Equal("5535", resultado);
    }


    [Fact]
    public void Dividir_ComNumerosGrandes_DeveRetornarDivisaoCorreta()
    {
        string numero1 = "100";
        string numero2 = "4";

        string resultado = Calculadora.Dividir(numero1, numero2);

        Assert.Equal("25", resultado);
    }

    [Fact]
    public void Dividir_ComTruncamento_DeveRetornarParteInteira()
    {
        string resultado = Calculadora.Dividir("10", "3");
        Assert.Equal("3", resultado);
    }

    [Fact]
    public void Dividir_PorUm_DeveRetornarMesmoNumero()
    {
        string resultado = Calculadora.Dividir("99999", "1");
        Assert.Equal("99999", resultado);
    }

    [Fact]
    public void Dividir_NumeroMenorPeloMaior_DeveRetornarZero()
    {
        string resultado = Calculadora.Dividir("5", "10");
        Assert.Equal("0", resultado);
    }

    [Fact]
    public void Dividir_PorZero_DeveLancarExcecao()
    {
        Assert.Throws<DivideByZeroException>(() => Calculadora.Dividir("100", "0"));
    }


}