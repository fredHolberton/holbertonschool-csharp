﻿using System;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

/// <summary>Public class ImageProcessor for image processing.</summary>
public class ImageProcessor
{
    /// <summary>Inverts each image’s color.</summary>
    public static void Inverse(string[] filenames)
    {
        Thread[] threads = new Thread[filenames.Length];

        for (int i = 0; i < filenames.Length; i++)
        {     
            if (isImage(Path.GetExtension(filenames[i])))
            {
                int index = i;
                threads[i] = new Thread(() => InverseOneImage(filenames[index]));
                threads[i].Start();
            }
        }

        /* Attendre que tous les threads soient terminés */
        foreach (Thread thread in threads)
        {
            /* Bloque le programme jusqu'à ce que le thread soit terminé */
            if (thread != null)
                thread.Join();
        }
    }

    /// <summary>Converts each image to grayscale.</summary>
    public static void Grayscale(string[] filenames)
    {
        Thread[] threads = new Thread[filenames.Length];

        for (int i = 0; i < filenames.Length; i++)
        {     
            if (isImage(Path.GetExtension(filenames[i])))
            {
                int index = i;
                threads[i] = new Thread(() => GrayscaleOneImage(filenames[index]));
                threads[i].Start();
            }
        }

        /* Attendre que tous les threads soient terminés */
        foreach (Thread thread in threads)
        {
            /* Bloque le programme jusqu'à ce que le thread soit terminé */
            if (thread != null)
                thread.Join();
        }
    }

    /// <summary> process one image.</summary>
    private static void InverseOneImage(string filename)
    {
        try
        {
            /* Charger l'image */
            using (Bitmap image = new Bitmap(filename))
            {
                /* Inverser les couleurs de manière plus rapide */
                /* Verrouiller les bits de l'image pour un accès direct aux données des pixels */
                int width = image.Width;
                int height = image.Height;

                BitmapData bmpData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                int stride = bmpData.Stride;
                byte[] pixelBuffer = new byte[stride * height];

                System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

                for (int i = 0; i < pixelBuffer.Length / 4; i++)
                {
                    int x = i * 4;

                    pixelBuffer[x] ^= 0xFF;
                    pixelBuffer[x + 1] ^= 0xFF;
                    pixelBuffer[x + 2] ^= 0xFF;
                    pixelBuffer[x + 3] ^= 0xFF;
                }

                System.Runtime.InteropServices.Marshal.Copy(pixelBuffer, 0, bmpData.Scan0, pixelBuffer.Length);

                image.UnlockBits(bmpData);

                /* Sauvegarder l'image inversée avec un suffixe "_inverted" */
                string original_file_name = Path.GetFileNameWithoutExtension(filename);
                string original_file_extension = Path.GetExtension(filename);
                string invertedFileName = original_file_name + "_inverse" + original_file_extension;
                image.Save(invertedFileName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors du traitement de l'image {filename} : {ex.Message}");
        }
    }


    private static void GrayscaleOneImage(string filename)
    {
        try
        {
            /* Charger l'image */
            using (Bitmap image = new Bitmap(filename))
            {
                /* Verrouiller les bits de l'image pour un accès direct aux données des pixels */
                int width = image.Width;
                int height = image.Height;

                BitmapData bmpData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                int stride = bmpData.Stride;
                byte[] pixelBuffer = new byte[stride * height];

                System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

                for (int i = 0; i < pixelBuffer.Length / 4; i++)
                {
                    int x = i * 4;
                    int grayValue = (int)(0.3 * pixelBuffer[x] + 0.59 *  pixelBuffer[x + 1] + 0.11 * pixelBuffer[x + 2]);

                    pixelBuffer[x] = (byte)grayValue;
                    pixelBuffer[x + 1] = (byte)grayValue;
                    pixelBuffer[x + 2] = (byte)grayValue;
                    /*pixelBuffer[x + 3] ^= 0xFF; */
                }

                System.Runtime.InteropServices.Marshal.Copy(pixelBuffer, 0, bmpData.Scan0, pixelBuffer.Length);

                image.UnlockBits(bmpData);

                /* Sauvegarder l'image inversée avec un suffixe "_inverted" */
                string original_file_name = Path.GetFileNameWithoutExtension(filename);
                string original_file_extension = Path.GetExtension(filename);
                string invertedFileName = original_file_name + "_grayscale" + original_file_extension;
                image.Save(invertedFileName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors du traitement de l'image {filename} : {ex.Message}");
        }
    }

    /// <summary> Return true if the file is an image.</summary>
    private static bool isImage(string fileExtension)
    {
        string[] imageExtensions = new string[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".ico" };
        fileExtension = fileExtension.ToLower();

        /* Vérifier si l'extension est dans la liste des extensions d'images */
        foreach (var extension in imageExtensions)
        {
            if (fileExtension == extension)
            {
                return true;
            }
        }

        return false;
    }
}