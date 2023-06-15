using System.Collections.Generic;
using System.Net.Mail;
using System.Windows.Forms;

namespace SystemIventory.Classes.DataBase
{
    class OperationMail
    {

        public string Mensaje_add_correo { get; set; }

        public List<Attachment> atach;

        public OperationMail(List<Attachment> adjuntos)
        {
            atach = adjuntos;
        }
        public void SendMail()
        {
            Mail correo = new Mail();
            correo.MailTo = VariablesName.MailFrom;
            correo.MailSubject = "Pedido y Orden de Trabajo";
            correo.MailMessage = " Se adjuntan los documentos de la orden procesada";
            foreach (var item in OperationsFileXlm.MailList)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    correo.listMailCc.Add(new MailAddress(item));
                }

            }
            correo.listAttachments = atach;
            OptionsMail proc = new OptionsMail(correo);
            if (proc.SendMail())
            {
                MessageBox.Show("Correo Enviado", "Opciones de Correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Correo No Enviado", "Opciones de Correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
