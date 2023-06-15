using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace SystemIventory.Classes.DataBase
{
    class OptionsMail
    {
        public Mail _mail { get; set; }
        private SmtpClient _smtpClient;
        private MailMessage _mailMessage;


        public OptionsMail(Mail mail)
        {
            _mail = mail;
            _smtpClient = new SmtpClient();
            _mailMessage = new MailMessage();
        }

        public bool SendMail()
        {
            try
            {

                _smtpClient.Host = VariablesName.MailSmtpHost;
                _smtpClient.Port = VariablesName.MailSmtpPort;
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                _smtpClient.Credentials = new System.Net.NetworkCredential(VariablesName.MailUser, VariablesName.MailPassword);
                _mailMessage.From = new MailAddress(VariablesName.MailFrom);

                _mailMessage.To.Add(new MailAddress(_mail.MailTo));
                if (_mail.listMailCc.Count != 0)
                {
                    foreach (var cc in _mail.listMailCc)
                    {
                        _mailMessage.CC.Add(cc);

                    }
                }

                _mailMessage.Subject = _mail.MailSubject;
                string _message = string.Empty;
                _message += "<strong>Usuario: '"+ Environment.UserName+ "'</strong>";
                _message += _mail.MailMessage;
                _mailMessage.Body = _message;
                _message += "<h3> Centro de Distribución ACS-FOD</h3>";
                if (_mail.listAttachments.Count != 0)
                {
                    foreach (var attach in _mail.listAttachments)
                    {
                        _mailMessage.Attachments.Add(attach);
                    }
                }
                _mailMessage.IsBodyHtml = true;
                _smtpClient.EnableSsl = true;
                _smtpClient.Send(_mailMessage);

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
