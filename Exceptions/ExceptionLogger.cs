using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRSAutoFramework.Exceptions
{
    internal class ExceptionLogger
    {
        public void WriteExceptionToFile(string folderPath, Exception e)
        {
            string message = null;
            byte[] data = null;
           
            //if (SRSException.IsSRSException(e))
            //{
            //    SRSException SRSEx = (e as SRSException);

            //    string str = SRSEx.AsSoapDetail.OuterXml;
            //    data = ASCIIEncoding.ASCII.GetBytes(str);
            //    message = "Message: " + e.Message + "\r\nSource: " + e.Source
            //        + "\r\nBottom SRS Exception: " + SRSEx.BottomSRSExceptionSummary.Message
            //        + "\r\nTop non SRS Exception: " + SRSEx.TopNonSRSExceptionSummary.Message
            //        +"\r\n-----------------------------------------------------------------------\r\n"
            //        +str;

            //}
            //else
            //{
            //    message = "Message: " + e.Message + "\r\nSource: " + e.Source;
            //}

            new Helpers.FileHelper(folderPath).WriteToFile(message, Helpers.LogType.Exception);
        }
    }
}
