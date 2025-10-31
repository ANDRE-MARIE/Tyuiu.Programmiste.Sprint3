
using System.Globalization;
using Tyuiu.Programmiste.Sprint3.Task7.V26.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* TASK: TABULATION DE FONCTION - CORRIGÉ                                 *");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* Fonction: F(x) = 5 - 3x + (1 + sin(x)) / (2x - 0.5)                    *");
        Console.WriteLine("* Intervalle: [-5; 5] avec pas de 1                                      *");
        Console.WriteLine("* Format: 2 décimales, virgule comme séparateur                          *");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine();

        DataService ds = new DataService();

        int startValue = -5;
        int stopValue = 5;

        Console.WriteLine("PARAMÈTRES:");
        Console.WriteLine($"- Début: {startValue}");
        Console.WriteLine($"- Fin: {stopValue}");
        Console.WriteLine();

        try
        {
            double[] resultArray = ds.GetMassFunction(startValue, stopValue);

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* RÉSULTATS CORRIGÉS (format attendu)                                  *");
            Console.WriteLine("***************************************************************************");

            // Afficher le tableau formaté exactement comme attendu
            Console.Write("Valeurs obtenues: [");
            for (int i = 0; i < resultArray.Length; i++)
            {
                // Format avec virgule comme séparateur décimal
                string formattedValue = resultArray[i].ToString("F2", CultureInfo.GetCultureInfo("fr-FR"));

                // Pour les nombres avec .0, s'assurer qu'ils s'affichent avec ,0
                if (resultArray[i] == Math.Floor(resultArray[i]))
                {
                    formattedValue = ((int)resultArray[i]).ToString() + ",0";
                }

                Console.Write(formattedValue);

                if (i < resultArray.Length - 1)
                    Console.Write(",");
            }
            Console.WriteLine("]");
            Console.WriteLine("***************************************************************************");

            // Affichage détaillé pour vérification
            Console.WriteLine();
            Console.WriteLine("TABLEAU DÉTAILLÉ:");
            Console.WriteLine("|  x  |   F(x) calculé   |  F(x) arrondi  |  Attendu       |");
            Console.WriteLine("|-----|------------------|----------------|----------------|");

            // Valeurs attendues fournies
            double[] expectedValues = { 19.81, 16.79, 13.87, 10.98, 7.94, 3.0, 3.23, -0.45, -3.79, -6.97, -10.0 };

            for (int i = 0, x = startValue; x <= stopValue; i++, x++)
            {
                double calculated = 5 - 3 * x + (1 + Math.Sin(x)) / (2 * x - 0.5);
                double rounded = Math.Round(calculated, 2);

                string status = rounded == expectedValues[i] ? "✅" : "❌";

                Console.WriteLine($"| {x,3} | {calculated,15:F6} | {rounded,14:F2} | {expectedValues[i],12} | {status}");
            }

            // Vérification finale
            Console.WriteLine();
            Console.WriteLine("VÉRIFICATION:");
            bool allMatch = true;
            for (int i = 0; i < resultArray.Length; i++)
            {
                if (Math.Abs(resultArray[i] - expectedValues[i]) > 0.01)
                {
                    Console.WriteLine($"❌ Index {i}: Obtenu {resultArray[i]}, Attendu {expectedValues[i]}");
                    allMatch = false;
                }
            }

            if (allMatch)
            {
                Console.WriteLine("✅ TOUTES LES VALEURS CORRESPONDENT !");
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

