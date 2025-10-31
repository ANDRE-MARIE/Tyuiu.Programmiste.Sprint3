
using Tyuiu.Programmiste.Sprint3.Task6.V10.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        
        {
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* TASK: SOMME DES DIVISEURS SUPÉRIEURS À 12 - VERSION FINALE             *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Programme qui calcule la somme de tous les diviseurs > 12              *");
            Console.WriteLine("* parmi les entiers du segment [20, 32]                                  *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine();

            DataService ds = new DataService();

            int startValue = 20;
            int stopValue = 32;

            Console.WriteLine("PARAMÈTRES:");
            Console.WriteLine($"- Segment: [{startValue}, {stopValue}]");
            Console.WriteLine($"- Condition: diviseurs STRICTEMENT > 12 (à partir de 13)");
            Console.WriteLine();

            try
            {
                int result = ds.GetSumTheDivisors(startValue, stopValue);

                Console.WriteLine("***************************************************************************");
                Console.WriteLine("* RÉSULTAT:                                                              *");
                Console.WriteLine("***************************************************************************");
                Console.WriteLine($"Somme des diviseurs > 12 = {result}");

                if (result == 348)
                {
                    Console.WriteLine("✅ SUCCÈS : Résultat correct !");
                }
                Console.WriteLine("***************************************************************************");

                // VÉRIFICATION DÉTAILLÉE
                Console.WriteLine();
                Console.WriteLine("VÉRIFICATION DÉTAILLÉE:");
                Console.WriteLine("Nombre\tDiviseurs > 12\t\tSomme partielle");
                Console.WriteLine("--------------------------------------------------------");

                int verificationTotal = 0;

                for (int number = startValue; number <= stopValue; number++)
                {
                    List<int> divisorsAbove12 = new List<int>();

                    // Trouver tous les diviseurs > 12 pour ce nombre
                    for (int divisor = 13; divisor <= number; divisor++)
                    {
                        if (number % divisor == 0)
                        {
                            divisorsAbove12.Add(divisor);
                        }
                    }

                    int partialSum = 0;
                    foreach (int divisor in divisorsAbove12)
                    {
                        partialSum += divisor;
                    }
                    verificationTotal += partialSum;

                    Console.Write($"{number}\t");
                    if (divisorsAbove12.Count > 0)
                    {
                        Console.Write($"{string.Join(", ", divisorsAbove12)}");
                        Console.Write($"\t\t");
                        if (partialSum < 10) Console.Write(" "); // Alignement
                        Console.Write($"+{partialSum}");
                    }
                    else
                    {
                        Console.Write("Aucun\t\t\t 0");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine($"SOMME TOTALE = {verificationTotal}");

                if (verificationTotal == 348)
                {
                    Console.WriteLine("✅ CALCUL MANUEL CONFORME");
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
