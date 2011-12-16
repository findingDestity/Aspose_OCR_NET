using System;
using System.Collections.Generic;
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
                ocrEngine.Image = ImageStream.FromFile("./../../Samples/Sample.bmp");

                ocrEngine.Languages.AddLanguage(Language.Load("english"));
                ocrEngine.Config.NeedRotationCorrection = false;
                ocrEngine.Config.UseDefaultDictionaries = true;

                //Set resource file name and extract OCR text
                using (ocrEngine.Resource = new FileStream(resourceFileName, FileMode.Open))
                {
                    try
                    {
                        if (ocrEngine.Process())
                        {
                            Console.WriteLine(ocrEngine.Text.ToString());
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
