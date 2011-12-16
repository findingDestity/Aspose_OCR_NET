using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.OCR;
using System.IO;


namespace RecognitionBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            const string resourceFileName = @"D:\2011.07.02 v1.0 Aspose.OCR.Resources.zip";

            try
            {
                //Create OcrEngine instance and assign 
                //image, language and image configuration
                OcrEngine ocrEngine = new OcrEngine();
                ocrEngine.Image = ImageStream.FromFile("Sample.bmp");

                ocrEngine.Languages.AddLanguage(Language.Load("english"));
                ocrEngine.Config.NeedRotationCorrection = false;
                ocrEngine.Config.UseDefaultDictionaries = true;

                //Select the block to recognize text
                int startX = 0, startY = 0, width = 120, height = 100;
                IRecognitionBlock rectangleBlock = Aspose.OCR.RecognitionBlock.FromRectangle(startX, startY, width, height);
                ocrEngine.AddRecognitionBlock(rectangleBlock);

                //Set resource file name and extract OCR text
                using (ocrEngine.Resource = new FileStream(resourceFileName, FileMode.Open))
                {
                    try
                    {
                        if (ocrEngine.Process())
                        {
                            Console.WriteLine(rectangleBlock.Text.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception: " + ex.Message);
                    }
                }
                ocrEngine = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}
