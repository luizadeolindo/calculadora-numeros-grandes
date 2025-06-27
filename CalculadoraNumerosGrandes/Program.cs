using System;
using System.IO;
using System.Linq;
using CalculadoraNumerosGrandes;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Calculadora de Números Grandes ===\n");

        Console.Write("Informe o caminho do primeiro arquivo: ");
        string caminho1 = Console.ReadLine()?.Trim();

        Console.Write("Informe o caminho do segundo arquivo: ");
        string caminho2 = Console.ReadLine()?.Trim();

        if (!File.Exists(caminho1) || !File.Exists(caminho2))
        {
            Console.WriteLine("\nErro: Um dos arquivos informados não foi encontrado.");
            return;
        }

        string numero1 = File.ReadAllText(caminho1).Trim();
        string numero2 = File.ReadAllText(caminho2).Trim();

        if (!numero1.All(char.IsDigit) || !numero2.All(char.IsDigit))
        {
            Console.WriteLine("\nErro: Um dos arquivos contém caracteres inválidos (apenas dígitos são permitidos).");
            return;
        }

        Console.Write("\nQual operação deseja realizar? (+ para soma, - para subtração, * para multiplicação, / para divisão): ");
        string operacao = Console.ReadLine();

        string resultado;

        try
        {
            resultado = operacao switch
            {
                "+" => Calculadora.Somar(numero1, numero2),
                "-" => Calculadora.Subtrair(numero1, numero2),
                "*" => Calculadora.Multiplicar(numero1, numero2),
                "/" => Calculadora.Dividir(numero1, numero2),
                _ => throw new InvalidOperationException("Operação inválida.")
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro ao realizar a operação: {ex.Message}");
            return;
        }

        File.WriteAllText("resultado.txt", resultado);

        Console.WriteLine($"\nOperação realizada com sucesso!");
        Console.WriteLine($"Resultado: {resultado}");
        Console.WriteLine("O resultado também foi salvo no arquivo resultado.txt");
    }
}
