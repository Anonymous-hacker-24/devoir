using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ___________programe de BELL YAMB BErnard Alex_____________
//definition de la classe Program
class Program
{
    static void Main(string[] args)
    {
        // Chemin du fichier contenant le dictionnaire des mots
        string dictionnairePath = "motsbell_yambdictionnaire.txt";

        // Lecture du dictionnaire et stockage des mots dans une liste
        List<string> dictionnaire = File.ReadAllLines(dictionnairePath).ToList();

        // Saisie de l'utilisateur
        Console.WriteLine("Entrez les mots séparés par des virgules :");
        string entreeUtilisateur = Console.ReadLine();

        // Séparation des mots saisis par l'utilisateur
        string[] mots = entreeUtilisateur.Split(',');

        // Parcours des mots saisis
        foreach (string mot in mots)
        {
            // Suppression des espaces avant et après le mot saisi
            string motTraite = mot.Trim();

            // Vérification si le mot est présent dans le dictionnaire
            if (dictionnaire.Contains(motTraite))
            {
                Console.WriteLine($"{motTraite} correspond à {motTraite}");
            }
            else
            {
                // Trie des lettres du mot pour trouver la correspondance
                string lettreTrie = new string(motTraite.OrderBy(c => c).ToArray());

                // Recherche d'une correspondance dans le dictionnaire
                string correspondance = dictionnaire.FirstOrDefault(m => new string(m.OrderBy(c => c).ToArray()) == lettreTrie);

                if (correspondance != null)
                {
                    Console.WriteLine($"{motTraite} correspond à {correspondance}");
                }
                else
                {
                    Console.WriteLine($"{motTraite} aucune correspondance trouvée");
                }
            }
        }

        // Attente que l'utilisateur appuie sur n'importe quelle touche pour fermer la console
        Console.ReadKey();
    }
}
