
using Tyuiu.Programmiste.Sprint3.Task0.V10.Lib;
internal class Program
{
    private static void Main(string[] args)
    {

        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* TASK: CALCUL DU PRODUIT DE SÉRIE                                       *");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* Formule: p = ∏[i=1 à 5] (300 / (i + x^i))^i                           *");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine();

        DataService ds = new DataService();
        int x = 5;
        int startValue = 1;
        int stopValue = 5;

        Console.WriteLine($"Paramètres:");
        Console.WriteLine($"- x = {x}");
        Console.WriteLine($"- startValue = {startValue}");
        Console.WriteLine($"- stopValue = {stopValue}");
        Console.WriteLine();

        try
        {
            double result = ds.GetMultiplySeries(x, startValue, stopValue);

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* RÉSULTAT:                                                              *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine($"Produit de la série = {result:F10}");
            Console.WriteLine($"Format scientifique = {result:E6}");
            Console.WriteLine("***************************************************************************");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur: {ex.Message}");
        }

        Console.ReadKey();
    }
}

