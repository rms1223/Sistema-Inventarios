using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace InventarioFod.Clases.Manejo_De_Datos
{
    class Procesar_Email
    {
        public Mail _Mail { get; set; }
        private SmtpClient smtpClient;
        private MailMessage mailMessage;


        public Procesar_Email(Mail mail)
        {
            this._Mail = mail;
            smtpClient = new SmtpClient();
            mailMessage = new MailMessage();
        }

        public bool Send_Mail()
        {
            try
            {

                smtpClient.Host = Var_Name.SmtpHost;
                smtpClient.Port = Var_Name.SmtpPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new System.Net.NetworkCredential(Var_Name.Mail_User, Var_Name.Mail_Pass);
                mailMessage.From = new MailAddress(Var_Name.Email_from);

                mailMessage.To.Add(new MailAddress(_Mail.Mail_To));
                if (_Mail.Mail_Cc.Count != 0)
                {
                    foreach (var cc in _Mail.Mail_Cc)
                    {
                        mailMessage.CC.Add(cc);

                    }
                }

                mailMessage.Subject = _Mail.Mail_Subject;
                string mensaje = string.Empty;
                mensaje += "<strong>Usuario: '"+ Environment.UserName+ "'</strong>";
                mensaje += _Mail.Mail_Message;
                mailMessage.Body = mensaje;
                mensaje += "<h3> Centro de Distribución ACS-FOD</h3>";
                if (_Mail.attachments.Count != 0)
                {
                    foreach (var attach in _Mail.attachments)
                    {
                        mailMessage.Attachments.Add(attach);
                    }
                }
                mailMessage.IsBodyHtml = true;
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
