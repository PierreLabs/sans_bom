using System;
using System.IO;

//Build :
//dotnet build -c release -r win10-x64

namespace bombom
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Converti un lot de fichiers à l'intérieur d'un dossier. Ne pas manipuler des originaux,
            mais ne travailler qu'avec des copies (on n'est pas à l'abri d'une mauvaise conversion)
             */
            Console.WriteLine("Chemin des fichiers :");
            string path = Console.ReadLine();
            File.SetAttributes(path, FileAttributes.Normal);

            var files = Directory.GetFiles(path);

            var utf8SansBOM = new System.Text.UTF8Encoding(false); //false = sans BOM

            foreach (var file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                var content = File.ReadAllLines(file);
                Console.WriteLine("Conversion du fichier '" + file + "'...");
                var startindex = file.LastIndexOf('\\');
                var file2 = file.Insert(startindex+1,"converti_");
                System.IO.File.WriteAllLines(file2, content, utf8SansBOM);
                Console.WriteLine(file2 + " converti");
            }
            Console.WriteLine("Terminé.");
            Console.ReadLine();
        }
    }
}
