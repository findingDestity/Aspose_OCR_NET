Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Aspose.OCR
Imports System.IO


Namespace RecognitionBlock
	Friend Class Program
		Shared Sub Main(ByVal args As String())
			Const resourceFileName As String = "D:\2011.07.02 v1.0 Aspose.OCR.Resources.zip"

			Try
				'Create OcrEngine instance and assign 
				'image, language and image configuration
				Dim ocrEngine As OcrEngine = New OcrEngine()
                ocrEngine.Image = ImageStream.FromFile("./../../Samples/Sample.bmp")

				ocrEngine.Languages.AddLanguage(Language.Load("english"))
				ocrEngine.Config.NeedRotationCorrection = False
				ocrEngine.Config.UseDefaultDictionaries = True

                'Set resource file name and extract OCR text
				ocrEngine.Resource = New FileStream(resourceFileName, FileMode.Open)
                Try
                    If ocrEngine.Process() Then
                        Console.WriteLine(ocrEngine.Text.ToString())
                    End If
                Catch ex As Exception
                    Console.WriteLine("Exception: " & ex.Message)
                End Try
                ocrEngine = Nothing
            Catch ex As Exception
                Console.WriteLine("Exception: " & ex.Message)
            End Try

			Console.ReadKey()
		End Sub
	End Class
End Namespace
