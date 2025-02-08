using System;
using System.Threading;
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
            threads[i] = new Thread(() => InvertImageColors(filenames[index]));
            threads[i].Start();
        }

        /* Attendre que tous les threads soient terminés */
        for (int i = 0; i < threads.Length; i++)
        {
            /* Bloque le programme jusqu'à ce que le thread soit terminé */
            threads[i].Join();
        }
    }

    /// <summary> process one image.</summary>
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
                BitmapData bmpData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, image.PixelFormat);
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

                image.Save(invertedFileName, GetImageFormat(original_file_extension));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing file {filename}: {ex.Message}");
        }
    }

    /// <summary> Méthode pour obtenir le format de l'image en fonction de l'extension.</summary>
    private static System.Drawing.Imaging.ImageFormat GetImageFormat(string extension)
    {
        switch (extension.ToLower())
        {
            case ".jpg":
            case ".jpeg":
                return System.Drawing.Imaging.ImageFormat.Jpeg;
            case ".png":
                return System.Drawing.Imaging.ImageFormat.Png;
            case ".bmp":
                return System.Drawing.Imaging.ImageFormat.Bmp;
            case ".gif":
                return System.Drawing.Imaging.ImageFormat.Gif;
            case ".tiff":
                return System.Drawing.Imaging.ImageFormat.Tiff;
            default:
                throw new NotSupportedException("Format de fichier non pris en charge.");
        }
    }
}
