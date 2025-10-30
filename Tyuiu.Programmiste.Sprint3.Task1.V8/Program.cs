
using Tyuiu.Programmiste.Sprint3.Task1.V8.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* TASK: CALCUL DU PRODUIT DE SÉRIE                                       *");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* Formule: S = ∏[k=1 à 7] (1 / (cos(k) + x^k))^k                        *");
        Console.WriteLine("* avec x = 0,25                                                          *");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine();

        DataService ds = new DataService();
        double x = 0.25;
        int startValue = 1;
        int stopValue = 7;

        Console.WriteLine($"Paramètres:");
        Console.WriteLine($"- x = {x}");
        Console.WriteLine($"- startValue = {startValue}");
        Console.WriteLine($"- stopValue = {stopValue}");
        Console.WriteLine();

        try
        {
            double result = ds.GetSumSeries(x, startValue, stopValue);

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* RÉSULTAT:                                                              *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine($"Produit de la série S = {result:F15}");
            Console.WriteLine($"Format scientifique = {result:E10}");
            Console.WriteLine("***************************************************************************");

            // Affichage détaillé du calcul
            Console.WriteLine();
            Console.WriteLine("DÉTAIL DU CALCUL:");
            Console.WriteLine("k | cos(k) | x^k | dénominateur | terme | terme^k");
            Console.WriteLine("--------------------------------------------------");

            double detailedProduct = 1.0;
            int k = startValue;
            while (k <= stopValue)
            {
                double cosK = Math.Cos(k);
                double xPowK = Math.Pow(x, k);
                double denominator = cosK + xPowK;
                double term = 1.0 / denominator;
                double poweredTerm = Math.Pow(term, k);
                detailedProduct *= poweredTerm;

                Console.WriteLine($"{k} | {cosK:F4} | {xPowK:F6} | {denominator:F6} | {term:F6} | {poweredTerm:E6}");
                k++;
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Produit final: {detailedProduct:E10}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("Appuyez sur une touche pour fermer cette fenêtre...");
        Console.ReadKey();
    }
}
