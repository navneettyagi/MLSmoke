using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace SRSAutoFramework.Helpers
{
    class PdfHelper
    {
        //pathToFile should be the absolute or relative path to the pdf file with Filename.pdf 
        //for example - D://test//Test.pdf
        public static string GetAllTextFromPDF(string pathToFile)
        {
            try
            {
                StringBuilder text = new StringBuilder();
                using (PdfReader reader = new PdfReader(pathToFile))
                {
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    }
                }

                return text.ToString();
            }
            catch (Exception e)
            {
                LogHelper.LogException(e);
                throw;
            }
        }

        public static string GetDefinedPageTextFromPDF(string pathToFile, int pageN)
        {
            try
            {
                StringBuilder text = new StringBuilder();
                using (PdfReader reader = new PdfReader(pathToFile))
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, pageN));
                return text.ToString();
            }
            catch (Exception e)
            {
                LogHelper.LogException(e);
                throw;
            }
        }

    }

}
