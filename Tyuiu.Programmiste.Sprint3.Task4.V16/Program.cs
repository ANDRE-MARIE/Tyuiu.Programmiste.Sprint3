using Tyuiu.Programmiste.Sprint3.Task4.V16.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        {
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* TASK: CALCUL DU PRODUIT DE LA FONCTION                                 *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Fonction: y = ((cos(x) + x) / x) + 0.25                                *");
            Console.WriteLine("* Segment: x de -5 à 5                                                   *");
            Console.WriteLine("* Lorsque x = 0, la valeur est ignorée                                   *");
            Console.WriteLine("* Multiplier les valeurs obtenues                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine();

            DataService ds = new DataService();
            int startValue = -5;
            int stopValue = 5;

            Console.WriteLine($"Paramètres:");
            Console.WriteLine($"- startValue = {startValue}");
            Console.WriteLine($"- stopValue = {stopValue}");
            Console.WriteLine();

            try
            {
                double result = ds.Calculate(startValue, stopValue);

                Console.WriteLine("***************************************************************************");
                Console.WriteLine("* RÉSULTAT:                                                              *");
                Console.WriteLine("***************************************************************************");
                Console.WriteLine($"Produit des valeurs de la fonction = {result:F0}"); // Format sans décimales
                Console.WriteLine($"Valeur exacte = {result}");
                Console.WriteLine("***************************************************************************");

                // Affichage détaillé des calculs
                Console.WriteLine();
                Console.WriteLine("DÉTAIL DES CALCULS:");
                Console.WriteLine("x\t\ty = ((cos(x) + x) / x) + 0.25");
                Console.WriteLine("------------------------------------------------");

                double detailProduct = 1.0;
                for (int x = startValue; x <= stopValue; x++)
                {
                    if (x == 0)
                    {
                        Console.WriteLine($"0\t\tIGNORÉ (division par zéro)");
                        continue;
                    }

                    double numerator = Math.Cos(x) + x;
                    double term = (numerator / x) + 0.25;
                    detailProduct *= term;
                    Console.WriteLine($"{x}\t\t{term:F10}");
                }

                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"Produit avant multiplication par 1000: {detailProduct:F10}");
                Console.WriteLine($"Produit après multiplication par 1000: {detailProduct * 1000:F0}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche pour quitter...");
            Console.ReadKey();
        }
    }
}
