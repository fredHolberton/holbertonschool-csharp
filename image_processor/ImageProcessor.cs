﻿using System;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

/// <summary>Public class ImageProcessor for image processing.</summary>
public class ImageProcessor
{
    /// <summary> inverts an image’s color.</summary>
    public static void Inverse(string[] filenames)
    {
        //Thread[] threads = new Thread[filenames.Length];
        var tasks = new Task[filenames.Length];

        for (int i = 0; i < filenames.Length; i++)
        {     
            if (isImage(Path.GetExtension(filenames[i])))
            {
                int index = i;
                //threads[i] = new Thread(() => InvertImageColors(filenames[index]));
                //threads[i].Start();
                tasks[i] = Task.Run(() =>
                {
                    InvertImageColors(filenames[index]);
                });
            }
            
        }

        /* Attendre que tous les threads soient terminés */
        //foreach (Thread thread in threads)
        //{
            /* Bloque le programme jusqu'à ce que le thread soit terminé */
        //    if (thread != null)
        //        thread.Join();
        //}
        Task.WhenAll(tasks).Wait();
    }

    /* process one image. */
    private static void InvertImageColors(string filename)
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
                    byte blue = pixelBuffer[x];
                    byte green = pixelBuffer[x + 1];
                    byte red = pixelBuffer[x + 2];
                    byte alpha = pixelBuffer[x + 3];

                    pixelBuffer[x] = (byte)(255 - blue);
                    pixelBuffer[x + 1] = (byte)(255 - green);
                    pixelBuffer[x + 2]  = (byte)(255 - red);
                    pixelBuffer[x + 3] = (byte)(255 - alpha);
                }
                System.Runtime.InteropServices.Marshal.Copy(pixelBuffer, 0, bmpData.Scan0, pixelBuffer.Length);
                image.UnlockBits(bmpData);
                /* Sauvegarder l'image inversée avec un suffixe "_inverted" */
                string original_file_name = Path.GetFileNameWithoutExtension(filename);
                string original_file_extension = Path.GetExtension(filename);
                string invertedFileName = original_file_name + "_inverse" + original_file_extension;

                image.Save(invertedFileName, GetImageFormat(filename));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing file {filename}: {ex.Message}");
        }
    }

    /* Return true if the file is an image */
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

    /* Retun the image format corresponding to the image file */
    private static ImageFormat GetImageFormat(string filename)
    {
        string extension = Path.GetExtension(filename);
        switch (extension.ToLower())
        {
            case ".jpg":
            case ".jpeg":
                return ImageFormat.Jpeg;
            case ".png":
                return ImageFormat.Png;
            case ".bmp":
                return ImageFormat.Bmp;
            case ".gif":
                return ImageFormat.Gif;
            case ".tiff":
                return ImageFormat.Tiff;
            case ".ico":
                return ImageFormat.Icon;
            default:
                throw new ArgumentException("Extension non prise en charge", nameof(extension));
        }
    }
}
