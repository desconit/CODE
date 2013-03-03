using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace TextMsgTest
{
    class MessageSender
    {

        public MessageResponse SendMessage(CandidateMessage candidateMessage)
        {

            WebClient client = new WebClient();
            // Add a user agent header in case the requested URI contains a query.
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.QueryString.Add("user", "nazebiah");
            client.QueryString.Add("password", "Basketba11");
            client.QueryString.Add("api_id", "3285640");
            client.QueryString.Add("concat", "5");
            client.QueryString.Add("from", "AJK");
            client.QueryString.Add("to", candidateMessage.CandidateNumber);

            //Create message body 
            StringBuilder txtMessage = new StringBuilder();
            txtMessage.AppendLine(candidateMessage.CompanyName);

            if (candidateMessage.CompanyAddressLine1 != string.Empty)
                txtMessage.AppendLine(candidateMessage.CompanyAddressLine1);

            if (candidateMessage.CompanyAddressLine1 != string.Empty)
                txtMessage.AppendLine(candidateMessage.CompanyAddressLine2);

            // txtMessage.AppendLine(candidateMessage.CompanyAddressLine3);
            txtMessage.AppendFormat("Report to: {0} - {1}", candidateMessage.ReportToName, candidateMessage.ReportToContactNumber);
            txtMessage.AppendLine();
            txtMessage.AppendFormat("Start: {0}", string.Format("{0} {1} ", candidateMessage.Start.DayOfWeek, candidateMessage.Start.ToString("HH:MM")));
            txtMessage.AppendLine();
            txtMessage.AppendFormat("Must bring: {0}", candidateMessage.MustBring);
            txtMessage.AppendLine();
            txtMessage.Append(candidateMessage.TextMessageSigniture);

            Console.Write(txtMessage.ToString());

            client.QueryString.Add("text", txtMessage.ToString());

            string baseurl = "http://api.clickatell.com/http/sendmsg";
            Stream data = client.OpenRead(baseurl);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            var msgResponse = new MessageResponse();
            if (s.StartsWith("ID:"))
                msgResponse.Success = true;
            else
            {
                msgResponse.Success = false;
                msgResponse.Response = s;
            }


            return msgResponse;
        }

        public MessageResponse SendMailShotMessage(CandidateMessage candidateMessage)
        {
            WebClient client = new WebClient();
            // Add a user agent header in case the requested URI contains a query.
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.QueryString.Add("user", "nazebiah");
            client.QueryString.Add("password", "Basketba11");
            client.QueryString.Add("api_id", "3285640");
            client.QueryString.Add("concat", "3");
            client.QueryString.Add("from", "AJK");
            // client.QueryString.Add("to", candidateMessage.CandidateNumber);
            client.QueryString.Add("to", "0711249993,07958656944,07702812910,07702812908");


            StringBuilder txtMessage = new StringBuilder();
            txtMessage.Append(candidateMessage.TxtMessage);
            txtMessage.AppendLine();
            txtMessage.Append(candidateMessage.TxtMessage1);
            txtMessage.AppendLine();
            txtMessage.Append(candidateMessage.TextMessageSigniture);
            Console.Write(txtMessage.ToString());

            client.QueryString.Add("text", txtMessage.ToString());

            string baseurl = "http://api.clickatell.com/http/sendmsg";
            Stream data = client.OpenRead(baseurl);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            var msgResponse = new MessageResponse();
            if (s.StartsWith("ID:"))
                msgResponse.Success = true;
            else
            {
                msgResponse.Success = false;
                msgResponse.Response = s;
            }


            return msgResponse;
        }


        public class CandidateMessage
        {
            public string CompanyName { get; set; }

            public string CompanyAddressLine1 { get; set; }

            public string CompanyAddressLine2 { get; set; }

            public string CompanyAddressLine3 { get; set; }

            public string ReportToName { get; set; }

            public string ReportToContactNumber { get; set; }

            public DateTime Start { get; set; }

            public string MustBring { get; set; }

            public string TextMessageSigniture { get; set; }

            public string CandidateName { get; set; }

            public string CandidateNumber { get; set; }

            public string TxtMessage { get; set; }

            public string TxtMessage1 { get; set; }
        }

        public class MessageResponse
        {
            public bool Success { get; set; }
            public string Response { get; set; }
        }

    }
}
