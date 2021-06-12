﻿using System.Collections.Generic;
using System.Net.Mail;
namespace InventarioFod.Clases.Manejo_De_Datos
{
    class Mail
    {
        public string Mail_To { get; set; }
        public string Mail_From { get; set; }
        public List<MailAddress> Mail_Cc { get; set; }
        public List<Attachment> attachments { get; set; }
        public string Mail_Subject { get; set; }
        public string Mail_Message { get; set; }

        public Mail(string mail_To, string mail_From, List<MailAddress> mail_Cc, List<Attachment> attachments)
        {
            Mail_To = mail_To;
            Mail_From = mail_From;
            Mail_Cc = mail_Cc;
            this.attachments = attachments;
        }
        public Mail()
        {
            Mail_Cc = new List<MailAddress>();
            attachments = new List<Attachment>();
        }
    }
}
