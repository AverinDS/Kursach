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
using Limilabs.Client.POP3;
using Limilabs.Mail.MIME;
using Limilabs.Mail;
using Limilabs.Mail.Headers;
using Limilabs.Client.IMAP;



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

        public string setMailto
        {
            set { mailto = value; }
            get { return mailto; }
        }

        string smtpServer = "smtp.gmail.com";
        string from = "courseworksdavaysya@gmail.com";
        string password = "gfhjkm123gfhjkm";
        string mailto = "fedyafedorovichfedorov@gmail.com";
        public void SendMail(string caption, string message, string attachFile)
        {
            try
            {
                System.Net.Mail.MailAddress MailFrom = new System.Net.Mail.MailAddress(from, "Central System");//отправитель
                System.Net.Mail.MailAddress MailTo = new System.Net.Mail.MailAddress(mailto);//кому
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
            catch (Exception ex)
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

        public void GetAttach()
        {
            using (Pop3 pop3 = new Pop3())
            {

                pop3.ConnectSSL("pop.gmail.com", 995);   // or ConnectSSL

                pop3.UseBestLogin("courseworksdavaysya@gmail.com", "gfhjkm123gfhjkm");
                foreach (string uid in pop3.GetAll())
                {
                    IMail email = new MailBuilder().CreateFromEml(pop3.GetMessageByUID(uid));
                    Console.WriteLine(email.Subject);

                    // save all attachments to disk
                    foreach (MimeData mime in email.Attachments)
                    {
                        mime.Save(mime.SafeFileName);
                    }
                }
                pop3.Close();
            }
        }

        public void GetAttachImap()
        {
            using (Imap imap = new Imap())
            {
                imap.ConnectSSL("imap.gmail.com", 993);   // or ConnectSSL for SSL
                imap.UseBestLogin("courseworksdavaysya@gmail.com", "gfhjkm123gfhjkm");
                imap.SelectInbox();
                List<long> uids = imap.Search(Flag.All);
                foreach (long uid in uids)
                {
                    IMail email = new MailBuilder().CreateFromEml(imap.GetMessageByUID(uid));
                    MessageBox.Show(email.Subject);
                    // save all attachments to disk

                    foreach (MimeData mime in email.Attachments)
                    {
                        mime.Save(mime.SafeFileName);
                    }

                   
                }
                imap.Close();
                WorkWithDatabase DB = new WorkWithDatabase();
                //работа по считыванию файлов
                int count = int.Parse(DB.GettingMaxId("storage"));
                for (int i = 0; i < count; i++)
                {
                    if (File.Exists(string.Format("DateProductManagerStorageValue{0}.txt", i)))
                    {
                        string line = "";
                        StreamReader read = new StreamReader(string.Format("DateProductManagerStorageValue{0}.txt", i));
                        int k = 1;
                        while ((line = read.ReadLine()) != null)
                        {
                            try
                            {
                                string date = line.Substring(0, line.IndexOf(' '));//получение даты
                                line = line.Remove(0, line.IndexOf(' ') + 1);
                                string productId = line.Substring(0, line.IndexOf(' '));//idproduct
                                line = line.Remove(0, line.IndexOf(' ') + 1);
                                string managerId = line.Substring(0, line.IndexOf(' '));//idmanager
                                line = line.Remove(0, line.IndexOf(' ') + 1);
                                string idStorage = line.Substring(0, line.IndexOf(' '));//idstorage
                                line = line.Remove(0, line.IndexOf(' ') + 1);
                                string value = line;//value
                               
                                Convert.ToDateTime(date);
                                int.Parse(productId);
                                int.Parse(managerId);
                                int.Parse(value);
                                k++;

                                //Работа с БД
                               
                                string idbalance = DB.Getting_id("balance", "ProductId = " + productId + " and StorageId = " + idStorage);
                                if (idbalance == "") throw new Exception("Не найдено записей с такими параметрами");
                                string oldValue = DB.Getting_smth("balance", "Number", "ProductID = " + productId + " and StorageId = " + idStorage);
                                if ((int.Parse(oldValue) - int.Parse(value)) < 0) throw new Exception("Невозможно продать больше товара, чем есть на складе");
                                DB.InsertInDB("sale", (int.Parse(DB.GettingMaxId("sale")) + 1).ToString(), date, value, productId, managerId, idbalance);
                                
                                DB.UpdateDB("balance", "number", (int.Parse(oldValue) - int.Parse(value)).ToString(), idbalance);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(string.Format("В файле {0} обнаружена ошибка в строке {1}. Строка будет проигнорированна.\n Дополнительно:", string.Format("DateProductManagerValue{0}.txt", i), k) + ex.Message);
                            }
                        }
                        read.Close();
                        File.Delete(string.Format("DateProductManagerStorageValue{0}.txt", i));//закрыть чтение
                    }
                }
            }
            DeletingAll();
        }


        private void DeletingAll()
        {
            using (Imap imap = new Imap())
            {
                imap.ConnectSSL("imap.gmail.com", 993);
                imap.UseBestLogin("courseworksdavaysya@gmail.com", "gfhjkm123gfhjkm");
                // Recognize Trash folder
                List<FolderInfo> folders = imap.GetFolders();
                CommonFolders common = new CommonFolders(folders);
                FolderInfo trash = common.Trash;
                // Find all emails we want to delete
                imap.SelectInbox();
                List<long> uids = imap.Search(Expression.Subject(""));
                // Move email to Trash
                List<long> uidsInTrash = new List<long>();
                foreach (long uid in uids)
                {
                    long uidInTrash = (long)imap.MoveByUID(uid, trash);

                    uidsInTrash.Add(uidInTrash);
                }
                // Delete moved emails from Trash

                imap.Select(trash);

                foreach (long uid in uidsInTrash)
                {

                    imap.DeleteMessageByUID(uid);
                }
                imap.Close();
            }

        }



       
           
    }
}

