using System;
using System.IO;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        string[] filenames;

        if (args.Length > 1)
            filenames = args;
        else
            filenames = Directory.GetFiles("images/", "*.*");

        Console.WriteLine("lancement du traitement des images : {0}", DateTime.Now.ToString("hh:mm:ss"));
        ImageProcessor.Grayscale(filenames);
        Console.WriteLine("Fin du traitement des images : {0}", DateTime.Now.ToString("hh:mm:ss"));
        
    }
}