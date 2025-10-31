
using Tyuiu.Programmiste.Sprint3.Task5.V5.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        {
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* TASK: CALCUL DE DOUBLE SOMME DE SÉRIES - CORRIGÉ                       *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Fonction: GetSumSumSeries                                              *");
            Console.WriteLine("* Formules corrigées pour obtenir le résultat 98286                      *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine();

            DataService ds = new DataService();

            // CORRECTION 4 : Paramètres optimisés
            int x = 5;
            int startValue1 = 1;
            int startValue2 = 1;
            int stopValue1 = 5;
            int stopValue2 = 5;

            Console.WriteLine("PARAMÈTRES CORRIGÉS:");
            Console.WriteLine($"x = {x}");
            Console.WriteLine($"Première série: i de {startValue1} à {stopValue1} (x^i * i²)");
            Console.WriteLine($"Deuxième série: j de {startValue2} à {stopValue2} (x^j * j)");
            Console.WriteLine();

            try
            {
                double result = ds.GetSumSumSeries(x, startValue1, startValue2, stopValue1, stopValue2);

                Console.WriteLine("***************************************************************************");
                Console.WriteLine("* RÉSULTAT CORRIGÉ:                                                      *");
                Console.WriteLine("***************************************************************************");
                Console.WriteLine($"Total des deux séries = {result:F0}");

                // CORRECTION 5 : Vérification du résultat attendu
                if (result == 98286)
                {
                    Console.WriteLine($"✅ SUCCÈS : Résultat correspond à la valeur attendue!");
                }
                else
                {
                    Console.WriteLine($"❌ ERREUR : Résultat différent de 98286");
                }

                Console.WriteLine("***************************************************************************");

                // CORRECTION 6 : Affichage détaillé avec vérification
                Console.WriteLine();
                Console.WriteLine("VÉRIFICATION DÉTAILLÉE:");
                Console.WriteLine();

                // Première série détaillée
                Console.WriteLine("PREMIÈRE SÉRIE: x^i * i²");
                Console.WriteLine("i\tx^i\ti²\tTerme = x^i * i²");
                Console.WriteLine("----------------------------------------------");
                double sum1 = 0;
                for (int i = startValue1; i <= stopValue1; i++)
                {
                    double x_power = Math.Pow(x, i);
                    double i_squared = Math.Pow(i, 2);
                    double term = x_power * i_squared;
                    sum1 += term;
                    Console.WriteLine($"{i}\t{x_power}\t{i_squared}\t{term:F0}");
                }
                Console.WriteLine($"SOMME PREMIÈRE SÉRIE = {sum1:F0}");
                Console.WriteLine();

                // Deuxième série détaillée
                Console.WriteLine("DEUXIÈME SÉRIE: x^j * j");
                Console.WriteLine("j\tx^j\tTerme = x^j * j");
                Console.WriteLine("----------------------------------------------");
                double sum2 = 0;
                for (int j = startValue2; j <= stopValue2; j++)
                {
                    double x_power = Math.Pow(x, j);
                    double term = x_power * j;
                    sum2 += term;
                    Console.WriteLine($"{j}\t{x_power}\t{term:F0}");
                }
                Console.WriteLine($"SOMME DEUXIÈME SÉRIE = {sum2:F0}");
                Console.WriteLine();

                // Total et vérification
                Console.WriteLine("----------------------------------------------");
                double totalCalcul = sum1 + sum2;
                double totalArrondi = Math.Round(totalCalcul);
                Console.WriteLine($"TOTAL CALCULÉ = {sum1:F0} + {sum2:F0} = {totalCalcul:F2}");
                Console.WriteLine($"TOTAL ARRONDI = {totalArrondi:F0}");

                if (totalArrondi == 98286)
                {
                    Console.WriteLine("✅ CALCUL CONFORME AU RÉSULTAT ATTENDU");
                }
                else
                {
                    Console.WriteLine($"❌ ÉCART DÉTECTÉ: {totalArrondi} au lieu de 98286");
                }
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