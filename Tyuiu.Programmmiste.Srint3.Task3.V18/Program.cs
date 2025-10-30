
using Tyuiu.Programmmiste.Srint3.Task3.V18.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* TASK: REMPLACEMENT DES CHIFFRES PAR UN CARACTÈRE                      *");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* À l'aide d'une boucle foreach, remplacez les nombres par la lettre n   *");
        Console.WriteLine("* dans la chaine : 4n5nvf 56 bgy                                        *");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine();

        DataService ds = new DataService();
        string inputString = "4n5nvf 56 bgy";
        char replacementChar = 'n';

        Console.WriteLine($"Chaîne originale: \"{inputString}\"");
        Console.WriteLine($"Caractère de remplacement: '{replacementChar}'");
        Console.WriteLine();

        try
        {
            string result = ds.ReplaceNumOnChar(inputString, replacementChar);

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* RÉSULTAT:                                                              *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine($"Chaîne transformée: \"{result}\"");
            Console.WriteLine("***************************************************************************");

            // Affichage détaillé du traitement
            Console.WriteLine();
            Console.WriteLine("DÉTAIL DU TRAITEMENT:");
            Console.WriteLine("Caractère | Est un chiffre | Action");
            Console.WriteLine("------------------------------------");

            foreach (char c in inputString)
            {
                bool isDigit = char.IsDigit(c);
                string action = isDigit ? $"Remplacé par '{replacementChar}'" : "Conservé";
                Console.WriteLine($"    '{c}'    |      {isDigit,-5}      | {action}");
            }
            Console.WriteLine("------------------------------------");
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

   