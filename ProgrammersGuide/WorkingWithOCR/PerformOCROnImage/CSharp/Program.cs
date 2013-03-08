//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.OCR. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System;
using System.IO;

using Aspose.OCR;

namespace PerformOCROnImage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            // Resource file
            const string resourceFileName = "Aspose.OCR.Resources.zip";
            // Source file: the file on which OCR will be performed
            string imageFile = "Sampleocr.bmp";

            Console.WriteLine("Performing OCR on " + imageFile + "....");

            // Initialize OcrEngine
            OcrEngine ocr = new OcrEngine();
            // Set the image
            ocr.Image = ImageStream.FromFile(dataDir + imageFile);
            // Add language
            ocr.Languages.AddLanguage(Language.Load("english"));
            // Load the resource file
            using (ocr.Resource = new FileStream(resourceFileName, FileMode.Open))
            {
                try
                {
                    // Process the whole image
                    if (ocr.Process())
                    {
                        // Get the complete recognized text found from the image
                        Console.WriteLine("Text recognized./n" + ocr.Text);
                        //File result = new File
                        File.WriteAllText(dataDir + "Output.txt", ocr.Text.ToString());

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }
        }
    }
}