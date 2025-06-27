using System;
using System.Text;

namespace CalculadoraNumerosGrandes;

public class Calculadora
{
    public static string Somar(string a, string b)
    {
        if (a.Length > b.Length)
            b = b.PadLeft(a.Length, '0');
        else
            a = a.PadLeft(b.Length, '0');

        StringBuilder resultado = new();
        int carry = 0;

        for (int i = a.Length - 1; i >= 0; i--)
        {
            int digitoA = a[i] - '0';
            int digitoB = b[i] - '0';

            int soma = digitoA + digitoB + carry;
            carry = soma / 10;
            resultado.Append(soma % 10);
        }

        if (carry > 0)
            resultado.Append(carry);

        char[] array = resultado.ToString().ToCharArray();
        Array.Reverse(array);

        return new string(array);
    }

    public static string Subtrair(string a, string b)
    {
        if (a.Length > b.Length)
            b = b.PadLeft(a.Length, '0');
        else
            a = a.PadLeft(b.Length, '0');

        StringBuilder resultado = new();
        int emprestimo = 0;

        for (int i = a.Length - 1; i >= 0; i--)
        {
            int digitoA = a[i] - '0';
            int digitoB = b[i] - '0';

            int subtracao = digitoA - digitoB - emprestimo;

            if (subtracao < 0)
            {
                subtracao += 10;
                emprestimo = 1;
            }
            else
            {
                emprestimo = 0;
            }

            resultado.Append(subtracao);
        }

        char[] array = resultado.ToString().ToCharArray();
        Array.Reverse(array);
        string final = new string(array).TrimStart('0');

        return final == "" ? "0" : final;
    }

    public static string Multiplicar(string x, string y)
    {
        if (x == "0" || y == "0")
            return "0";

        if (x.Length == 1 && y.Length == 1)
            return (int.Parse(x) * int.Parse(y)).ToString();

        int maxLength = Math.Max(x.Length, y.Length);
        if (maxLength % 2 != 0) maxLength++;

        x = x.PadLeft(maxLength, '0');
        y = y.PadLeft(maxLength, '0');
        int meio = maxLength / 2;

        string a = x.Substring(0, meio);
        string b = x.Substring(meio);
        string c = y.Substring(0, meio);
        string d = y.Substring(meio);

        string ac = Multiplicar(a, c);
        string bd = Multiplicar(b, d);
        string abMais = Somar(a, b);
        string cdMais = Somar(c, d);
        string abcd = Multiplicar(abMais, cdMais);

        string z1 = Subtrair(Subtrair(abcd, ac), bd);

        string resultado = Somar(
            Somar(
                ac + new string('0', 2 * meio),
                z1 + new string('0', meio)
            ),
            bd
        );

        return resultado.TrimStart('0');
    }

    public static string Dividir(string dividendo, string divisor)
    {
        if (divisor == "0")
            throw new DivideByZeroException("Divisor não pode ser zero.");
        if (dividendo == "0")
            return "0";

        StringBuilder resultado = new();
        string resto = "0";

        for (int i = 0; i < dividendo.Length; i++)
        {
            resto += dividendo[i];
            resto = resto.TrimStart('0');
            if (resto == "") resto = "0";

            int quocienteParcial = 0;
            while (Comparar(Multiplicar(divisor, quocienteParcial.ToString()), resto) <= 0)
                quocienteParcial++;

            quocienteParcial--;
            string subtrai = Multiplicar(divisor, quocienteParcial.ToString());
            resto = Subtrair(resto, subtrai);

            resultado.Append(quocienteParcial);
        }

        string final = resultado.ToString().TrimStart('0');
        return final == "" ? "0" : final;
    }

    private static int Comparar(string a, string b)
    {
        a = a.TrimStart('0');
        b = b.TrimStart('0');

        if (a.Length < b.Length) return -1;
        if (a.Length > b.Length) return 1;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] < b[i]) return -1;
            if (a[i] > b[i]) return 1;
        }

        return 0;
    }
}
