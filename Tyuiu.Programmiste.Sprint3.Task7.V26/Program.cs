
using Tyuiu.Programmiste.Sprint3.Task7.V26.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* TASK: TABULATION DE FONCTION                                           *");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* Fonction: F(x) = 5 - 3x + (1 + sin(x)) / (2x - 0.5)                    *");
        Console.WriteLine("* Intervalle: [-5; 5] avec pas de 1                                      *");
        Console.WriteLine("* Vérification division par zéro → retourne 0                            *");
        Console.WriteLine("* Format: 2 décimales                                                    *");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine();

        DataService ds = new DataService();

        int startValue = -5;
        int stopValue = 5;

        Console.WriteLine("PARAMÈTRES:");
        Console.WriteLine($"- Début: {startValue}");
        Console.WriteLine($"- Fin: {stopValue}");
        Console.WriteLine($"- Pas: 1");
        Console.WriteLine();

        try
        {
            double[] resultArray = ds.GetMassFunction(startValue, stopValue);

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* RÉSULTATS: TABLEAU DES VALEURS                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("|     x     |    F(x)    |");
            Console.WriteLine("|-----------|------------|");

            for (int i = 0, x = startValue; x <= stopValue; i++, x++)
            {
                // Vérification spéciale pour x = 0.25 (division par zéro)
                double denominator = 2 * x - 0.5;
                bool isDivisionByZero = Math.Abs(denominator) < 0.0001;

                Console.Write($"|{x,6}     |");

                if (isDivisionByZero)
                {
                    Console.WriteLine($"{"Division par zéro",10} |");
                }
                else
                {
                    Console.WriteLine($"{resultArray[i],10:F2} |");
                }
            }

            Console.WriteLine("***************************************************************************");

            // Affichage supplémentaire des valeurs brutes
            Console.WriteLine();
            Console.WriteLine("VALEURS DÉTAILLÉES:");
            for (int i = 0, x = startValue; x <= stopValue; i++, x++)
            {
                Console.WriteLine($"F({x,2}) = {resultArray[i]:F6}");
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
