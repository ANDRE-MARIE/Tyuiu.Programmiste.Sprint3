
using Tyuiu.Programmiste.Sprint3.Task5.V5.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        {
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* TASK: CALCUL DE DOUBLE SOMME DE SÉRIES                                 *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Fonction: GetSumSumSeries                                              *");
            Console.WriteLine("* Calcule la somme de deux séries mathématiques                          *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine();

            DataService ds = new DataService();

            // Paramètres d'exemple - à adapter selon vos besoins
            int x = 2;
            int startValue1 = 1;
            int startValue2 = 1;
            int stopValue1 = 3;
            int stopValue2 = 3;

            Console.WriteLine("PARAMÈTRES:");
            Console.WriteLine($"x = {x}");
            Console.WriteLine($"Première série: i de {startValue1} à {stopValue1}");
            Console.WriteLine($"Deuxième série: j de {startValue2} à {stopValue2}");
            Console.WriteLine();

            try
            {
                double result = ds.GetSumSumSeries(x, startValue1, startValue2, stopValue1, stopValue2);

                Console.WriteLine("***************************************************************************");
                Console.WriteLine("* RÉSULTAT:                                                              *");
                Console.WriteLine("***************************************************************************");
                Console.WriteLine($"Total des deux séries = {result:F10}");
                Console.WriteLine($"Valeur exacte = {result}");
                Console.WriteLine("***************************************************************************");

                // Affichage détaillé des calculs
                Console.WriteLine();
                Console.WriteLine("DÉTAIL DES CALCULS:");
                Console.WriteLine();

                // Première série
                Console.WriteLine("PREMIÈRE SÉRIE:");
                Console.WriteLine("i\t\tTerme = (x^i + 2) / i");
                Console.WriteLine("----------------------------------------");
                double sum1 = 0;
                for (int i = startValue1; i <= stopValue1; i++)
                {
                    double term = (Math.Pow(x, i) + 2) / i;
                    sum1 += term;
                    Console.WriteLine($"{i}\t\t{term:F10}");
                }
                Console.WriteLine($"SOMME PREMIÈRE SÉRIE = {sum1:F10}");
                Console.WriteLine();

                // Deuxième série
                Console.WriteLine("DEUXIÈME SÉRIE:");
                Console.WriteLine("j\t\tTerme = (x^j + 3) / j^2");
                Console.WriteLine("----------------------------------------");
                double sum2 = 0;
                for (int j = startValue2; j <= stopValue2; j++)
                {
                    double term = (Math.Pow(x, j) + 3) / Math.Pow(j, 2);
                    sum2 += term;
                    Console.WriteLine($"{j}\t\t{term:F10}");
                }
                Console.WriteLine($"SOMME DEUXIÈME SÉRIE = {sum2:F10}");
                Console.WriteLine();

                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"SOMME TOTALE = {sum1:F10} + {sum2:F10} = {result:F10}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERREUR: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche pour quitter...");
            Console.ReadKey();
        }
    }
}
    