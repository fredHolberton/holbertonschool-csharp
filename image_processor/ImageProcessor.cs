using System;
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
        foreach (string filename in filenames)
        {
            try
            {
                byte[] imageData = File.ReadAllBytes(filename);

                byte[] invertedData = InvertColors(imageData);

                string outputFilename = $"{Path.GetFileNameWithoutExtension(filename)}_inverse{Path.GetExtension(filename)}";
                File.WriteAllBytes(outputFilename, invertedData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {filename}: {ex.Message}");
            }
        }
    }

    private static byte[] InvertColors(byte[] imageData)  
    {
        byte[] invertedData = new byte[imageData.Length];
        for (int i = 0; i < imageData.Length / 4; i++)
        {
            int x = i * 4;

            invertedData[x] ^= 0xFF;
            invertedData[x + 1] ^= 0xFF;
            invertedData[x + 2] ^= 0xFF;
            invertedData[x + 3] ^= 0xFF;
        }

        return invertedData;
    } 


    /// <summary>Converts each image to grayscale.</summary>
    public static void Grayscale(string[] filenames)
    {
        foreach (string filename in filenames)
        {
            try
            {
                byte[] imageData = File.ReadAllBytes(filename);

                byte[] modifiedData = GrayscaleColors(imageData);

                string outputFilename = $"{Path.GetFileNameWithoutExtension(filename)}_grayscale{Path.GetExtension(filename)}";
                File.WriteAllBytes(outputFilename, modifiedData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {filename}: {ex.Message}");
            }
        }
    }

    private static byte[] GrayscaleColors(byte[] imageData)  
    {
        byte[] modifiedData = new byte[imageData.Length];
        for (int i = 0; i < imageData.Length / 4; i++)
        {
            int x = i * 4;
            int grayValue = (int)(0.3 * imageData[x] + 0.59 * imageData[x + 1] + 0.11 * imageData[x + 2]);

            modifiedData[x] = (byte)grayValue;
            modifiedData[x + 1] = (byte)grayValue;
            modifiedData[x + 2] = (byte)grayValue;
            modifiedData[x + 3] = imageData[x + 3];
        }

        return modifiedData;
    } 

    /// <summary>Reduces each image to only black and white values, based on a given threshold.</summary>
    public static void BlackWhite(string[] filenames, double threshold)
    {
        foreach (string filename in filenames)
        {
            try
            {
                byte[] imageData = File.ReadAllBytes(filename);

                byte[] modifiedData = BlackWhiteColors(imageData, threshold);

                string outputFilename = $"{Path.GetFileNameWithoutExtension(filename)}_bw{Path.GetExtension(filename)}";
                File.WriteAllBytes(outputFilename, modifiedData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {filename}: {ex.Message}");
            }
        }
    }

    private static byte[] BlackWhiteColors(byte[] imageData, double threshold)  
    {
        byte[] modifiedData = new byte[imageData.Length];
        for (int i = 0; i < imageData.Length / 4; i++)
        {
            int x = i * 4;
            double luminance = (double)(imageData[x] * 65536 + imageData[x + 1] * 256 + imageData[x + 2]);  
            double modifiedColor = (luminance >= threshold) ? 255 : 0;



            modifiedData[x] = (byte)modifiedColor;
            modifiedData[x + 1] = (byte)modifiedColor;
            modifiedData[x + 2] = (byte)modifiedColor;
            modifiedData[x + 3] = imageData[x + 3];
        }

        return modifiedData;
    }
}