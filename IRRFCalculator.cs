using System;

class IRRFCalculator
{
    public static double CalcularINSS(double salarioBruto)
    {
        // Simulação do cálculo do INSS (valores hipotéticos)
        if (salarioBruto <= 1412.00)
            return salarioBruto * 0.075;
        else if (salarioBruto <= 2666.68)
            return salarioBruto * 0.09;
        else if (salarioBruto <= 4000.03)
            return salarioBruto * 0.12;
        else
            return salarioBruto * 0.14;
    }

    public static double CalcularIRRF(double salarioBruto)
    {
        double inss = CalcularINSS(salarioBruto);
        double salarioBase = salarioBruto - inss;
        double aliquota = 0;
        double deducao = 0;

        // Tabela IRRF (valores simulados)
        if (salarioBase <= 2259.20)
        {
            aliquota = 0;
            deducao = 0;
        }
        else if (salarioBase <= 2826.65)
        {
            aliquota = 0.075;
            deducao = 169.44;
        }
        else if (salarioBase <= 3751.05)
        {
            aliquota = 0.15;
            deducao = 381.44;
        }
        else if (salarioBase <= 4664.68)
        {
            aliquota = 0.225;
            deducao = 662.67;
        }
        else
        {
            aliquota = 0.275;
            deducao = 896.00;
        }

        double irrf = (salarioBase * aliquota) - deducao;
        return irrf > 0 ? irrf : 0; // Garante que IRRF não seja negativo
    }

    static void Main(string[] args)
    {
        Console.Write("Digite o salário bruto: ");
        double salarioBruto = Convert.ToDouble(Console.ReadLine());

        double inss = CalcularINSS(salarioBruto);
        double irrf = CalcularIRRF(salarioBruto);

        Console.WriteLine($"\nSalário Bruto: R$ {salarioBruto:F2}");
        Console.WriteLine($"Desconto INSS: R$ {inss:F2}");
        Console.WriteLine($"Desconto IRRF: R$ {irrf:F2}");
    }
}
