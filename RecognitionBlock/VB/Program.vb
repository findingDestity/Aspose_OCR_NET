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

				'Select the block to recognize text
				Dim startX As Integer = 0, startY As Integer = 0, width As Integer = 120, height As Integer = 100
				Dim rectangleBlock As IRecognitionBlock = Aspose.OCR.RecognitionBlock.FromRectangle(startX, startY, width, height)
				ocrEngine.AddRecognitionBlock(rectangleBlock)

				'Set resource file name and extract OCR text
				ocrEngine.Resource = New FileStream(resourceFileName, FileMode.Open)
                Try
                    If ocrEngine.Process() Then
                        Console.WriteLine(rectangleBlock.Text.ToString())
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
