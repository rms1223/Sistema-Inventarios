﻿using System.Collections.Generic;
using System.Net.Mail;
namespace SystemIventory.Classes.DataBase
{
    class Mail
    {
        public string MailTo { get; set; }
        public string MailFrom { get; set; }
        public List<MailAddress> listMailCc { get; set; } = new List<MailAddress>();
        public List<Attachment> listAttachments { get; set; } = new List<Attachment>();
        public string MailSubject { get; set; }
        public string MailMessage { get; set; }

        public Mail(string mail_To, string mail_From, List<MailAddress> mail_Cc, List<Attachment> attachments)
        {
            MailTo = mail_To;
            MailFrom = mail_From;
            listMailCc = mail_Cc;
            this.listAttachments = attachments;
        }
        public Mail()
        {
           
        }
    }
}
