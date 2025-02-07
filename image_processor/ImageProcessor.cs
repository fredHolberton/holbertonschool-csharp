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

    /// <summary> inverts one image’s color.</summary>
    private static void InverseOneImage(string filename)
    {
        /* Récupère le nom et l'extension du fichier image */
        string[] words = filename.Split('.');
        string original_file_name = Path.GetFileName(filename);
        string original_file_extension = Path.GetExtension(filename);

        /* crée un bitmap à partir du fichier image */
        using (Bitmap image = new Bitmap(filename))
        {
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
            }

            System.Runtime.InteropServices.Marshal.Copy(pixelBuffer, 0, bmpData.Scan0, pixelBuffer.Length);

            image.UnlockBits(bmpData);

            image.Save(original_file_name + "_inverse." + original_file_extension);
        }
    }
}
