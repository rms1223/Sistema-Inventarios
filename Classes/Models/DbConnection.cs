

using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using SystemInventory.Classes.IModels;
using SystemIventory.Classes;


namespace SystemInventory.Classes.Models
{
    internal class DbConnection : IConnection
    {
        private MySqlConnection _mysqlConnection = null;

        public void CloseConnection()
        {
            try
            {
                _mysqlConnection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al cerrar la base de datos\n" + ex);
            }
        }

        public MySqlConnection GetConnection()
        {
            SetDatabaseConnection();
            return _mysqlConnection;
        }
        private void SetDatabaseConnection()
        {
            try
            {
                string connexion = string.Empty;
                if (VariablesName.TypeDatabase.Equals("sistema_nuevo"))
                {
                    connexion = "Server=" + VariablesName.DatabaseServer + ";Database=" + VariablesName.DatabaseName + ";port=3306;User Id=" + VariablesName.DatabaseUser + ";password=" + VariablesName.DatabasePassworD; 
                }
                else
                {
                    connexion = "Server=" + VariablesName.DatabaseServer + ";Database=" + VariablesName.DatabaseOldName + ";port=3306;User Id=" + VariablesName.DatabaseUser + ";password=" + VariablesName.DatabasePassworD;
                }
                _mysqlConnection = new MySqlConnection(connexion);
                _mysqlConnection.Open();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexion: Verifique que este conectado a Internet", "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ConnectionMessage = "ERROR DE CONEXION";

            }

        }

        public void VerifyDatabaseConnection()
        {
            if (_mysqlConnection.State.ToString() == "Closed")
            {
                GetConnection();
            }


        }
    }
}
