
using Tyuiu.Programmiste.Sprint3.Task2.V30.Lib;
internal class Program
{
    private static void Main(string[] args)
    {

        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* TASK: CALCUL DU PRODUIT DE SÉRIE                                       *");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* Formule: p = ∏[i=1 à 11] ((x² * i) + 2)                               *");
        Console.WriteLine("* avec x = 0,25                                                          *");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine();

        DataService ds = new DataService();
        double x = 0.25;
        int startValue = 1;
        int stopValue = 11;

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
            Console.WriteLine($"Produit de la série p = {result:F3}");
            Console.WriteLine($"Format scientifique = {result:E6}");
            Console.WriteLine("***************************************************************************");

            // Affichage détaillé du calcul
            Console.WriteLine();
            Console.WriteLine("DÉTAIL DU CALCUL:");
            Console.WriteLine("i | x² | x² * i | terme ((x² * i) + 2) | produit partiel");
            Console.WriteLine("----------------------------------------------------------------");

            double detailedProduct = 1.0;
            int i = startValue;
            double xSquared = Math.Pow(x, 2);

            do
            {
                double xSquaredTimesI = xSquared * i;
                double term = xSquaredTimesI + 2;
                detailedProduct *= term;

                Console.WriteLine($"{i,2} | {xSquared:F4} | {xSquaredTimesI,7:F4} | {term,19:F4} | {detailedProduct,15:E6}");
                i++;
            }
            while (i <= stopValue);

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"Produit final arrondi: {Math.Round(detailedProduct, 3)}");
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

   