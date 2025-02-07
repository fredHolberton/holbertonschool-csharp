using System;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

/// <summary>Public class ImageProcessor for image processing.</summary>
public class ImageProcessor
{
    /// <summary> inverts an image’s color.</summary>
    public static void Inverse(string[] filenames)
    {
        Thread[] threads = new Thread[filenames.Length];

        for (int i = 0; i < filenames.Length; i++)
        {     
            int index = i;
            threads[i] = new Thread(() => InverseOneImage(filenames[index]));
            threads[i].Start();
        }

        /* Attendre que tous les threads soient terminés */
        for (int i = 0; i < threads.Length; i++)
        {
            /* Bloque le programme jusqu'à ce que le thread soit terminé */
            threads[i].Join();
        }

    }

    private static void InverseOneImage(string filename)
    {
        /* Récupère le nom et l'extension du fichier image */
        string[] words = filename.Split('.');
        string original_file_name = words[0];
        string original_file_extension = words[1];

        /* crée un bitmap à partir du fichier image */
        Bitmap myBitmap = new Bitmap(filename);

        // Set each pixel in myBitmap to it's inverse.
        for (int Xcount = 0; Xcount < myBitmap.Width; Xcount++)
        {
            for (int Ycount = 0; Ycount < myBitmap.Height; Ycount++)
            {
                Color colorPixel = myBitmap.GetPixel(Xcount,Ycount);
                Color invertedColor = Color.FromArgb(255 - colorPixel.R, 255 - colorPixel.G, 255 - colorPixel.B);

                myBitmap.SetPixel(Xcount, Ycount, invertedColor);
            }
        }

        myBitmap.Save(original_file_name + "_inverse." + original_file_extension);
    }
}
