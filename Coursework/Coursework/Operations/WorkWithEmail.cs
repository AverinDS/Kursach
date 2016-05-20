using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;



namespace Coursework
{
    class WorkWithEmail //работа с электронной почтой
    {
        bool Internet = false;
        public bool GetInternet
        {
            get { return Internet; }
        }
        public bool CheckingInternet()
        {
            WebClient Client = new WebClient();

            string s = "";
            try
            {
                s = Client.DownloadString("http://www.google.com");
                Internet = true;
            }
            catch { Internet = false; }
            if (s == "") return false;
            else return true;
        }

        string smtpServer = "smtp.gmail.com";
        string from = "fedyafedorovichfedorov@gmail.com";
        string password = "fedyafedorovichfedorov123";
        string mailto = "courseworkSDAVAYSYA@gmail.com";
        public void SendMail(string caption, string message, string attachFile)
        {
            try
            {
                MailAddress MailFrom = new MailAddress(from, "Central System");//отправитель
                MailAddress MailTo = new MailAddress(mailto);//кому
                MailMessage m = new MailMessage(MailFrom, MailTo);//объект сообщения 
                m.Subject = "Report from Central System";
                m.Body = "Report from " + DateTime.Now.ToString();
                m.Attachments.Add(new Attachment(attachFile));
                SmtpClient smtp = new SmtpClient(smtpServer, 25);//адрес smtp сервера 587 465
               
                smtp.EnableSsl = true;//
                smtp.Credentials = new NetworkCredential(from, password);//логинимся
                smtp.Send(m);
                MessageBox.Show("Письмо отправлено");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Getting()
        {
            string response = null;
            string from = null;
            string subject = null;
            int totmessages = 0;

            TcpClient mailclient = null;
            try
            {
                mailclient = new TcpClient("pop3.mail.ru", 110);
            }
            catch (SocketException)
            {
                MessageBox.Show("Unable to connect to server");
             
                return;
            }

            NetworkStream ns = mailclient.GetStream();
            StreamReader sr = new StreamReader(ns, Encoding.GetEncoding("windows-1251"));
            StreamWriter sw = new StreamWriter(ns);
            response = sr.ReadLine(); //открываем «диалог»
            sw.WriteLine("User " + "courseworkSDAVAYSYA@gmail.com"); //Передаем имя пользователя
            sw.Flush();
            response = sr.ReadLine();

            if (response.Substring(0, 3) == "-ER")//если сервер ответил «ошибка»
            {
                MessageBox.Show("Unable to log into server");
              
                return; // прерываем «диалог»
            }
            sw.WriteLine("Pass " + "gfhjkm123gfhjkm"); //Передаем пароль
            sw.Flush();
            try
            {// если авторизация прошла успешно
                response = sr.ReadLine(); //получим ответ от сервера
            }
            catch (IOException)
            {
                MessageBox.Show("Unable to log into server");
                
                return; //иначе прерываем «диалог»
            }
            if (response.Substring(0, 4) == "-ERR")//если сервер ответил «ошибка»
            {
                MessageBox.Show("Unable to log into server");
           
                return; // прерываем «диалог»
            }
            sw.WriteLine("stat"); //Посылаем запрос на статистику почтового ящика
            sw.Flush();
            response = sr.ReadLine();
            string[] nummess = response.Split(' ');
            totmessages = Convert.ToInt16(nummess[1]);
            if (totmessages > 0)
            {
                MessageBox.Show("you have " + totmessages + " messages");
            }
            else
            {
                MessageBox.Show("You have no messages");
            }

            for (int i = 1; i <= totmessages; i++)
            {
                sw.WriteLine("top " + i + " 0"); //читаем заголовки каждого письма
                sw.Flush();
                while (true)
                {
                    response = sr.ReadLine();
                    if (response == ".")
                        break;
                    if (response.Length > 4)
                    {
                        if (response.Substring(0, 5) == "From:")
                            from = response;
                        if (response.Substring(0, 8) == "Subject:")
                            subject = response;
                    }
                }
                MessageBox.Show(i + " " + from + " " + subject);

            }





        }


    }
}

