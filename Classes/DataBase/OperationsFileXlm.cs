using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace SystemIventory.Classes.DataBase
{
    class OperationsFileXlm
    {
        public static List<string> ModalityList { get; set; }
        public static List<string> MailList { get; set; }


        private void ReadParametersXlmFile()
        {
            
            string _actualElement =string.Empty;

            XmlDocument _documentXlm = new XmlDocument();
            _documentXlm.Load(Path.Combine(Application.StartupPath,@"Data\Data_App.xml"));
            foreach (XmlNode item in _documentXlm.DocumentElement.ChildNodes)
            {
                _actualElement = item.Name;
                if (item.HasChildNodes)
                {
                    for (int i = 0; i < item.ChildNodes.Count; i++)
                    {
                        LoadDataXlm(item.ChildNodes[i].InnerText,_actualElement);
                    }
                }
            }

        }

        private void LoadDataXlm(string data, string elementoXlm)
        {
            switch (elementoXlm)
            {               
                case "Modalidad":
                    ModalityList.Add(data);
                    break;
                case "Correos":
                    MailList.Add(data);
                    break;
                default:
                    break;
            }
        }

        public OperationsFileXlm()
        {

            XmlTextReader _readerFileXlm = new XmlTextReader(Path.Combine(Application.StartupPath, @"Data\Configuration_App.xml"));
            string nombre_actual = string.Empty;
            while (_readerFileXlm.Read())
            {

                switch (_readerFileXlm.NodeType)
                {
                    case XmlNodeType.None:
                        break;
                    case XmlNodeType.Element:
                        
                        nombre_actual = _readerFileXlm.Name;
                        break;
                    case XmlNodeType.Text:
                        LoadValuesFromXlmFile(nombre_actual, _readerFileXlm.Value);
                        break;
                    default:
                        break;
                }

            }
            ModalityList = new List<string>();
            MailList = new List<string>();
            ReadParametersXlmFile();
            _readerFileXlm.Close();
        }

        private void LoadValuesFromXlmFile(string nombre_campo,string valor)
        {
            switch (nombre_campo)
            {
                case "user":
                    VariablesName.DatabaseUser = valor;
                    break;
                case "pass":
                    VariablesName.DatabasePassworD = valor;
                    break;
                case "server":
                    VariablesName.DatabaseServer = valor;
                    break;
                case "name_database":
                    VariablesName.DatabaseName = valor;
                    break;
                case "name_database2":
                    VariablesName.DatabaseOldName = valor;
                    break;
                default:
                    break;
            }
        }


    }
}
