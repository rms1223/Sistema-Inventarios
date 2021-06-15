using InventarioFod.Clases.Entidades.Security;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace InventarioFod.Clases.Manejo_De_Datos.Conexion_DB
{
    class Lectura_xml
    {
        public static List<string> Lista_Modalidad { get; set; }
        public static List<string> Lista_Correos { get; set; }


        private void Lectura_xml_Parametros_Listados()
        {
            
            string elemento_actual =string.Empty;

            XmlDocument document = new XmlDocument();
            document.Load(Path.Combine(Application.StartupPath,@"Data\Data_App.xml"));
            foreach (XmlNode item in document.DocumentElement.ChildNodes)
            {
                elemento_actual = item.Name;
                if (item.HasChildNodes)
                {
                    for (int i = 0; i < item.ChildNodes.Count; i++)
                    {
                        Cargar_Datos_Requipamiento(item.ChildNodes[i].InnerText,elemento_actual);
                    }
                }
            }

        }

        private void Cargar_Datos_Requipamiento(string dato, string elemento)
        {
            switch (elemento)
            {               
                case "Modalidad":
                    Lista_Modalidad.Add(dato);
                    break;
                case "Correos":
                    Lista_Correos.Add(dato);
                    break;
                default:
                    break;
            }
        }





        public Lectura_xml()
        {

            XmlTextReader reader = new XmlTextReader(Path.Combine(Application.StartupPath, @"Data\Configuration_App.xml"));
            string nombre_actual = "";
            while (reader.Read())
            {

                switch (reader.NodeType)
                {
                    case XmlNodeType.None:
                        break;
                    case XmlNodeType.Element:
                        
                        nombre_actual = reader.Name;
                        break;
                    case XmlNodeType.Text:
                        Cargar_valores(nombre_actual, reader.Value);
                        break;
                    default:
                        break;
                }

            }
            Lista_Modalidad = new List<string>();
            Lista_Correos = new List<string>();
            Lectura_xml_Parametros_Listados();
            reader.Close();
        }

        private void Cargar_valores(string nombre_campo,string valor)
        {
            switch (nombre_campo)
            {
                case "user":
                    Var_Name.user = valor;
                    break;
                case "pass":
                    Var_Name.pass = valor;
                    break;
                case "server":
                    Var_Name.server = valor;
                    break;
                case "name_database":
                    Var_Name.name_database = valor;
                    break;
                case "name_database2":
                    Var_Name.name_database_viejo = valor;
                    break;
                default:
                    break;
            }
        }


    }
}
