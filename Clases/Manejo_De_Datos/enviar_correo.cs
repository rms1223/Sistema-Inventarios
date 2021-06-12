using InventarioFod.Clases.Manejo_De_Datos.Conexion_DB;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Windows.Forms;

namespace InventarioFod.Clases.Manejo_De_Datos
{
    class enviar_correo
    {

        public string Mensaje_add_correo { get; set; }

        public List<Attachment> atach;

        public enviar_correo(List<Attachment> adjuntos)
        {
            atach = adjuntos;
        }
        public void Send_mail()
        {
            Mail correo = new Mail();
            correo.Mail_To = Var_Name.Email_from;
            correo.Mail_Subject = "Pedido y Orden de Trabajo";
            correo.Mail_Message = " Se adjuntan los documentos de la orden procesada";
            foreach (var item in Lectura_xml.Lista_Correos)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    correo.Mail_Cc.Add(new MailAddress(item));
                }

            }
            correo.attachments = atach;
            Procesar_Email proc = new Procesar_Email(correo);
            if (proc.Send_Mail())
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
