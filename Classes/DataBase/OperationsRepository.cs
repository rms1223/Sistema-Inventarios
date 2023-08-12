using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using SystemInventory.Classes.Models;
using SystemInventory.Classes.IModels;

namespace SystemIventory.Classes
{
    class OperationsRepository
    {

        private MySqlConnection _mysqlConnection = null;
        private static OperationsRepository _conexionDatabaseMysql = null;

        private Dictionary<string, int> _totalTecnicals = new Dictionary<string, int>();
        private Dictionary<string, int> _totalLocations = new Dictionary<string, int>();
        public List<string> InventoryLocations { get; set; } = new List<string>();
        public List<string> Carteles { get; set; } = new List<string>();
        public bool StatusTecnicals { get; set; }
        public string NameStatusMysqlConnection = "DISPONIBLE";
        public string ConnectionMessage = string.Empty;

        private IConnection _connection;
        private IDataBaseRepository _dataBaseRepository;

        private OperationsRepository()
        {
            //_totals = new Dictionary<string, string>();
            _connection = new DbConnection();
            _dataBaseRepository = DataBaseRepository.Get_Instance;
            _mysqlConnection = _connection.GetConnection();
            GetLocation();
            GetAllLotes();
            _mysqlConnection.StateChange += new StateChangeEventHandler(OnStateChange);
            ConnectionMessage = "CONECTADO";
            NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(AvailabilityChangedCallback);
            
        }

        private void AvailabilityChangedCallback(object sender, NetworkAvailabilityEventArgs e)
        {
            if (e.IsAvailable)
            {
                //Internet Connection is available  
                NameStatusMysqlConnection = "DISPONIBLE";
                VerifyDatabaseConnection();
            }
            else
            {
                NameStatusMysqlConnection = "NO DISPONIBLE";
            }
        }
        public static OperationsRepository Get_Instance
        {
            get
            {
                if (_conexionDatabaseMysql == null)
                {
                    _conexionDatabaseMysql = new OperationsRepository();
                    
                }
                
                return _conexionDatabaseMysql;
            }
        }
        public string StatusMysqlConnection()
        {
            return NameStatusMysqlConnection;
        }

        public void OnStateChange(object sender, StateChangeEventArgs e)
        {
            VerifyDatabaseConnection();
        }
        public void VerifyDatabaseConnection()
        {
            _connection.VerifyDatabaseConnection();

        }
        public void CloseConnection()
        {
            try
            {
                _connection.CloseConnection();
                _conexionDatabaseMysql = null;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al cerrar la base de datos\n" + ex);
            }
        }
        
        public int GetCodeTecnical(string name)
        {
            return _totalTecnicals[name];
        }
        public int GetCodeLocations(string location)
        {

            return _totalLocations[location];
        }
        
        public void GetLocation()
        {
            InventoryLocations = (List<string>)_dataBaseRepository.GetInformationLocation().Result;
            _totalLocations = (Dictionary<string, int>)_dataBaseRepository.GetInformationTotalLocation().Result;


        }
        public void GetAllLotes()
        {
            Carteles.Clear();
            Carteles = (List<string>)_dataBaseRepository.GetAllLotes().Result;
        }
        public List<string> GetTecnicals()
        {
            return (List<string>)_dataBaseRepository.GetTecnicals().Result;
        }
    }


}
