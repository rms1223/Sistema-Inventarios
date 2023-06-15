using SystemIventory.Classes.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing.Charts;
using DataTable = System.Data.DataTable;
using SystemIventory.Entidades;

namespace SystemIventory.Classes
{
    class ConnectionMysqlDatabase
    {

        private MySqlConnection _mysqlConnection = null;

        MySqlTransaction _mysqlTrasaction;
        private Dictionary<string, string> _totals;
        private MySqlCommand _mysqlCommand;
        private MySqlDataAdapter _mysqlAdapter;
        private static ConnectionMysqlDatabase _conexionDatabaseMysql = null;
        private DataSet _sourceWorkActions;


        private Dictionary<string, int> _totalTecnicals = new Dictionary<string, int>();
        private Dictionary<string, int> _totalLocations = new Dictionary<string, int>();
        public List<string> InventoryLocations { get; } = new List<string>();
        public List<string> Carteles { get; } = new List<string>();
        public bool StatusTecnicals { get; set; }
        public string NameStatusMysqlConnection = "DISPONIBLE";
        public string ConnectionMessage = string.Empty;

        private ConnectionMysqlDatabase()
        {
            _totals = new Dictionary<string, string>();
            SetDatabaseConnection();
            _mysqlCommand = new MySqlCommand();
            _mysqlCommand.Connection = _mysqlConnection;
            _sourceWorkActions = new DataSet();
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
        public static ConnectionMysqlDatabase Get_Instance
        {
            get
            {
                if (_conexionDatabaseMysql == null)
                {
                    _conexionDatabaseMysql = new ConnectionMysqlDatabase();
                    
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
            if (_mysqlConnection.State.ToString() == "Closed")
            {

                SetDatabaseConnection();
            }


        }

        private void SetDatabaseConnection()
        {
            try
            {
                string connexion = string.Empty;
                if (VariablesName.TypeDatabase.Equals("sistema_nuevo"))
                {
                    connexion = "Server=" + VariablesName.DatabaseServer + ";Database=" + VariablesName.DatabaseName + ";port=3306;User Id=" + VariablesName.DatabaseUser + ";password=" + VariablesName.DatabasePassworD; /*+ ";SslMode=none";*/
                }
                else
                {
                    connexion = "Server=" + VariablesName.DatabaseServer + ";Database=" + VariablesName.DatabaseOldName + ";port=3306;User Id=" + VariablesName.DatabaseUser + ";password=" + VariablesName.DatabasePassworD; /*+ ";SslMode=none";*/
                }
                _mysqlConnection = new MySqlConnection(connexion);
                _mysqlConnection.Open();
                _mysqlConnection.StateChange += new StateChangeEventHandler(OnStateChange);
                ConnectionMessage = "CONECTADO";

            }
            catch (MySqlException)
            {
                //MessageBox.Show("Error de conexion: Verifique que este conectado a Internet", "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConnectionMessage = "ERROR DE CONEXION";

            }

        }
        public void CloseMysqlConnection()
        {
            try
            {
                _mysqlConnection.Close();
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
        
        public void SaveInstitution(Institution institution)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Query.MysqlProcedureSaveInstitution;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("codigo", institution.Codigo);
                    cmd.Parameters.AddWithValue("centro_educativo", institution.Nombre);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public string GetInstitutionCode(string code, string queryType)
        {
            string institucion = string.Empty;

            _mysqlCommand = new MySqlCommand(Query.MysqlGetNameInstitution, _mysqlConnection);
            _mysqlCommand.Parameters.AddWithValue("@code", code);
            using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
            {
                if (lector.Read())
                {
                    if (queryType.Equals("consulta"))
                    {
                        institucion = lector["Centro_educativo"].ToString();
                    }
                    else
                    {
                        institucion = lector["Centro_educativo"].ToString() + "(" + code + ")";
                    }

                }
                else
                {
                    institucion = "No existe";
                }

                return institucion;
            }

        }
        
        public bool SaveRegisterReequipamiento(int codeModel, string serial, string placa, string query)
        {
            try
            {
                _mysqlTrasaction = _mysqlConnection.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    
                    cmd.CommandText = Query.MysqlSaveRecordReequipamiento;
                    cmd.Parameters.AddWithValue("@codeModel", codeModel);
                    cmd.Parameters.AddWithValue("@devicePlaca", placa);
                    cmd.Parameters.AddWithValue("@deviceSerial", serial);
                    cmd.Connection = _mysqlConnection;
                    cmd.ExecuteNonQuery();

                }
                _mysqlTrasaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _mysqlTrasaction.Rollback();
                MessageBox.Show("Error\n" + ex);
                return false;

            }

        }
        
        public DataTable GetAllDataReequipamiento()
        {
            try
            {
                DataTable tabla = new DataTable();
                _mysqlAdapter = new MySqlDataAdapter(Query.MysqlGetDataReequipamiento, _mysqlConnection);
                _mysqlAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void UpdateStatusList(int list, string statusList)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = _mysqlConnection;
                cmd.CommandText = Query.MysqlUpdateStatusList;
                cmd.Parameters.AddWithValue("@val_lista", list);
                cmd.Parameters.AddWithValue("@val_estadoLista", statusList);
                cmd.BeginExecuteNonQuery();
            }
        }

        public DataTable GetWorkActionFromId(string command, string idWorkAction)
        {
            DataTable tabla = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Query.MysqlProcedureGetWorkActionFromId;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("comando", command);
                    cmd.Parameters.AddWithValue("accion", idWorkAction);

                    _mysqlAdapter = new MySqlDataAdapter(cmd);
                    _mysqlAdapter.Fill(tabla);
                    return tabla;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }        

        /*public DataTable GetInformationWorkActionFromId(string idWorkAction)
        {
            try
            {
                DataTable tabla = new DataTable();
                string _consulta = "SELECT Serial,Placa,Codigo_Accion,Descripcion FROM equipo_acciones WHERE ";
                _consulta += idWorkAction;
                _mysqlAdapter = new MySqlDataAdapter(_consulta, _mysqlConnection);
                _mysqlAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception)
            {

                throw;
            }
        }*/

        public void GetInformationLocation()
        {
            _mysqlCommand = new MySqlCommand(Query.MysqlGetInformationLocation, _mysqlConnection);
            using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
            {
                while (lector.Read())
                {
                    InventoryLocations.Add(lector["Nombre"].ToString());
                    _totalLocations.Add(lector["Nombre"].ToString(), lector.GetInt32("Codigo"));

                }
            }
        }

        public void GetAllLotes()
        {
            Carteles.Clear();
            _mysqlCommand = new MySqlCommand(Query.MysqlGetAllLotes, _mysqlConnection);
            using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
            {
                while (lector.Read())
                {
                    Carteles.Add(lector["id_cartel"].ToString());

                }
            }
        }
        
        public int GetNextCodeProduct()
        {
            int valor_codigo = 0;
            _mysqlCommand = new MySqlCommand(Query.MysqlGetNextCodeProduct, _mysqlConnection);
            using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
            {
                while (lector.Read())
                {
                    valor_codigo = Convert.ToInt32(lector["codigo_modelo"].ToString());
                }
            }
            return valor_codigo + 1;
        }

        public List<string> GetAllTypesDevice()
        {
            List<string> lista = new List<string>();
            _mysqlCommand = new MySqlCommand(Query.MysqlGetAllTypeDevice, _mysqlConnection);
            using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
            {
                while (lector.Read())
                {
                    lista.Add(lector["id_tipo"].ToString() + "-" + lector["tipo_equipo"].ToString());

                }
            }
            return lista;
        }

        public bool SaveModelDevice(int code, string brand,string model,string queryType)
        {
            try
            {
                _mysqlTrasaction = _mysqlConnection.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Query.MysqlProcedureSaveModelDevice;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("codigo", code);
                    cmd.Parameters.AddWithValue("marca", brand);
                    cmd.Parameters.AddWithValue("modelo", model);
                    cmd.Parameters.AddWithValue("tipo", queryType);
                    cmd.ExecuteNonQuery();

                }
                _mysqlTrasaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _mysqlTrasaction.Rollback();
                MessageBox.Show("Error\n" + ex);
                if (_mysqlConnection.State.ToString() == "Closed")
                {

                    SetDatabaseConnection();
                }

                return false;

            }

        }

        public Device SearchDeviceFromId(string placa_serie, string queryType)
        {
            Device equipo = new Device();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = _mysqlConnection;
                    cmd.CommandText = Query.MysqlProcedureSearchDeviceFromId;
                    cmd.Parameters.AddWithValue("buscar", placa_serie);
                    cmd.Parameters.AddWithValue("comando", queryType);
                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            equipo.Placa = lector.GetString("placa");
                            equipo.Serie = lector.GetString("serie");
                            equipo.Marca = lector.GetString("marca");
                            equipo.Modelo = lector.GetString("modelo");
                            equipo.Tipo_equipo = lector.GetString("tipo_equipo");
                        }

                    }
                    Console.WriteLine(equipo);
                    return equipo;

                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
        
        public int GetIdWorkActionFromType(string typeWorkAction)
        {
            int num_accion = 0;
            string _consulta = string.Empty;
            if (typeWorkAction.Equals("orden_trabajo"))
            {
                _consulta = Query.MysqlGetIdWorkActionFromType;
            }
            else
            {
                _consulta = Query.MysqlGetIdWorkActionMaterialsFromType;
            }
            
            _mysqlCommand = new MySqlCommand(_consulta,_mysqlConnection);
            using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
            {
                while (lector.Read())
                {
                    num_accion = Convert.ToInt32(lector["Codigo"]);
                }
            }
            return num_accion;
        }
        
        public int GetIdOrder()
        {
            int num_accion = 0;
            _mysqlCommand = new MySqlCommand(Query.MysqlGetIdOrder, _mysqlConnection);
            using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
            {
                while (lector.Read())
                {
                    num_accion = Convert.ToInt32(lector["Codigo"]);
                }
            }
            return num_accion+1;
        }
        
        public bool SaveInventoryRecord(Equipos_Reequipamiento deviceReequipamiento, string query)
        {
            try
            {
                _mysqlTrasaction = _mysqlConnection.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Query.MysqlProcedureSaveInventoryRecord;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("serie", deviceReequipamiento.Serie);
                    cmd.Parameters.AddWithValue("placa", deviceReequipamiento.Placa);
                    cmd.Parameters.AddWithValue("institucion", deviceReequipamiento.Institucion);
                    cmd.Parameters.AddWithValue("modalidad", deviceReequipamiento.Modalidad);
                    cmd.Parameters.AddWithValue("accion", deviceReequipamiento.Accion);
                    cmd.Parameters.AddWithValue("numero_estacion", deviceReequipamiento.Numero_Maquina);
                    cmd.ExecuteNonQuery();

                }
                _mysqlTrasaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _mysqlTrasaction.Rollback();
                MessageBox.Show("Error\n" + ex);
                if (_mysqlConnection.State.ToString() == "Closed")
                {

                    SetDatabaseConnection();
                }
                
                return false;

            }

        }
        
        public DataSet GetWorkActionReport(int workAction)
        {
            _sourceWorkActions.Clear();
            using (MySqlCommand cmd = new MySqlCommand())
            {

                cmd.CommandText = Query.MysqlGetWorkActionReport;
                cmd.Parameters.AddWithValue("@workAction",workAction);
                cmd.Connection = _mysqlConnection;
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(_sourceWorkActions);
                }
            }
            return _sourceWorkActions;
        }
        
        public DataSet GetOrderReport(int order,string location)
        {
            _sourceWorkActions.Clear();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Query.MysqlProcedureGetOrderReport;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("orden", order);
                    cmd.Parameters.AddWithValue("ubicacion",location);
                    cmd.Connection = _mysqlConnection;
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(_sourceWorkActions);
                    }
                    return _sourceWorkActions;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public DataSet GetOuputMaterialReport(int order)
        {
            _sourceWorkActions.Clear();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Query.MysqlProcedureGetOuputMaterialReport;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("orden_buscar", order);
                    cmd.Connection = _mysqlConnection;
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(_sourceWorkActions);
                    }
                    return _sourceWorkActions;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        
        public DataTable GetAllWorkAction(int workAction)
        {
            try
            {
                DataTable tabla = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlGetAllWorkAction;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("@workAction", workAction);
                    _mysqlAdapter = new MySqlDataAdapter(cmd);
                    _mysqlAdapter.Fill(tabla);
                }
                return tabla;
            }
            catch (MySqlException)
            {

                throw;
            }
        }
        
        public void SaveNewWorkAction(int workAction, string description,string typeWorkAction)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                DateTime time = new DateTime();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = Query.MysqlProcedureSaveNewWorkAction;
                cmd.Connection = _mysqlConnection;
                cmd.Parameters.AddWithValue("accion", workAction);
                cmd.Parameters.AddWithValue("descripcion", description);
                cmd.Parameters.AddWithValue("fecha", time);
                cmd.Parameters.AddWithValue("tipo_orden", typeWorkAction);
                cmd.ExecuteNonQuery();
            }
            
        }

        public void SaveNewOrderMaterialsWorkAction(int orden, string descripcion)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                DateTime time = new DateTime();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = Query.MysqlProcedureSaveNewOrderMaterialsWorkAction;
                cmd.Connection = _mysqlConnection;
                cmd.Parameters.AddWithValue("orden", orden);
                cmd.Parameters.AddWithValue("descripcion", descripcion);
                cmd.Parameters.AddWithValue("fecha", time);
                cmd.ExecuteNonQuery();
            }

        }
        
        public void UpdateNewOrderMaterialsWorkAction(string descripcion,int cantidad,int orden)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                   
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Query.MysqlProcedureUpdateNewOrderMaterialsWorkAction;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("descripcion", descripcion);
                    cmd.Parameters.AddWithValue("cantidad", cantidad);
                    cmd.Parameters.AddWithValue("orden", orden);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        
        public int GetTotalMaterialsInStockFromDescription(string description)
        {
            try
            {
                int cantidad = 0;
                _mysqlCommand = new MySqlCommand
                {
                    CommandText = Query.MysqlGetTotalMaterialsInStockFromDescription
                };
                _mysqlCommand.Parameters.AddWithValue("@description", description);
                _mysqlCommand.Connection = _mysqlConnection;
                using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        cantidad = Convert.ToInt32(lector["cantidad"]);
                    }
                }
                return cantidad;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return -1;
            }
        }

        public void SaveNewOrderMaterialsForTecnicals(string descripcion, int cantidad, int orden,string tecnico)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Query.MysqlProcedureSaveNewOrderMaterialsForTecnicals;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("descripcion", descripcion);
                    cmd.Parameters.AddWithValue("cantidad", cantidad);
                    cmd.Parameters.AddWithValue("orden", orden);
                    cmd.Parameters.AddWithValue("tecnico", tecnico);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Material debe ser registrado previamente", "Opcioness Materiales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        public void SaveNewProduct(string codigo,string descripcion)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Query.MysqlProcedureSaveNewProduct;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("descripcion", descripcion);
                    cmd.Parameters.AddWithValue("codigo_pro", codigo);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public DataSet GetGeneralDevicesReport()
        {
            DataSet data = new DataSet();
            try
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(Query.MysqlGetGeneralDevicesReport, _mysqlConnection))
                {

                    adapter.Fill(data);
                }
               
            }
            catch (Exception)
            {
                if (_mysqlConnection.State.ToString() == "Closed")
                {
                    
                    SetDatabaseConnection();
                }
                
               
            }
            return data;
            
        }
       
        public DataTable GetInfromationWokActionFromType(int accion,string tipo)
        {
            DataTable tabla = new DataTable();
            try
            {
                string consulta = String.Empty;
                if (accion == 0)
                {
                    consulta = "SELECT * FROM view_estado_accion where Tipo_Orden = '"+tipo+"' ORDER BY accion DESC";

                }
                else
                {
                    consulta = "SELECT * FROM view_estado_accion WHERE accion = '" + accion + "' AND Tipo_Orden = '" + tipo + "' ORDER BY accion DESC";
                }
                using (MySqlDataAdapter lector = new MySqlDataAdapter(consulta, _mysqlConnection))
                {
                    lector.Fill(tabla);
                }
                return tabla;
            }
            catch (Exception)
            {
                return tabla;
            }
            
        }

        public DataTable GetChangesWorkAction(int orden, string tipo)
        {
            DataTable tabla = new DataTable();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlGetChangesWorkAction;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("@orden", orden);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    using (MySqlDataAdapter lector = new MySqlDataAdapter(cmd))
                    {
                        lector.Fill(tabla);
                    }
                }
                return tabla;
            }
            catch (Exception)
            {
                return tabla;
            }

        }

        public DataTable GetWorkActionMaterials()
        {

            DataTable tabla = new DataTable();
            using (MySqlDataAdapter lector = new MySqlDataAdapter(Query.MysqlGetWorkActionMaterials, _mysqlConnection))
            {
                lector.Fill(tabla);
            }
            return tabla;
        }

        public DataTable GetStatusWorkActionInProduction(string tipo)
        {
            DataTable tabla = new DataTable();
            string consulta = String.Empty;
            if (tipo.Equals("PENDIENTE"))
            {
                consulta = "SELECT * FROM obtener_ordenes_pendientes";

            }
            else
            {
                consulta = "SELECT * FROM obtener_ordenes_enproceso";
            }
            using (MySqlDataAdapter lector = new MySqlDataAdapter(consulta, _mysqlConnection))
            {
                lector.Fill(tabla);
            }
            return tabla;
        }
        
        public bool UpdateStatusWorkActionInProduction(int orden, string estado_update)
        {
            try
            {
                bool estado = true;
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlUpdateStatusWorkActionInProduction;
                    cmd.Parameters.AddWithValue("@estado_update", estado_update);
                    cmd.Parameters.AddWithValue("@orden", orden);
                    cmd.Connection = _mysqlConnection;
                    cmd.ExecuteNonQuery();
                }
                return estado;
            }
            catch (Exception)
            {
                if (_mysqlConnection.State.ToString() == "Closed")
                {

                    SetDatabaseConnection();
                }
                return false;
            }
        }

        public void ApplyWorkAction(int accion, string estado)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = Query.MysqlProcedureApplyWorkAction;
                cmd.Connection = _mysqlConnection;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("accion", accion);
                cmd.Parameters.AddWithValue("estado", GetCodeLocations(estado));
                cmd.ExecuteNonQuery();
            }
        }

        public void SaveInvoice(int numero, string detalle, double valor,string fecha,int orden,string tipo)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = Query.MysqlProcedureSaveInvoice;
                cmd.Connection = _mysqlConnection;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("num_fac", numero);
                cmd.Parameters.AddWithValue("detalle", detalle);
                cmd.Parameters.AddWithValue("valor", valor);
                cmd.Parameters.AddWithValue("fecha_registro", fecha);
                cmd.Parameters.AddWithValue("orden", orden);
                cmd.Parameters.AddWithValue("tipo",tipo);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetDataListInstitutionFromWorkAction(string comando, string accion)
        {
            DataTable tabla2 = new DataTable();
            try
            {

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = _mysqlConnection;
                    cmd.CommandText = Query.MysqlGetDataListInstitutionFromWorkAction;
                    cmd.Parameters.AddWithValue("comando", comando);
                    cmd.Parameters.AddWithValue("accion_usu", accion);
                    _mysqlAdapter = new MySqlDataAdapter(cmd);
                    _mysqlAdapter.Fill(tabla2);
                }

                return tabla2;
            }
            catch (Exception)
            {

                MessageBox.Show("Error al cargar vuelva a intentarlo", "Error al procesar Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return tabla2;
            }
            
        }
        
        public bool SaveNewDevice(int tipo,string placa, string serie,string cartel)
        {
            try
            {
                bool estado = true;
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlProcedureSaveNewDevice;
                    cmd.Connection = _mysqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("tipo", tipo);
                    cmd.Parameters.AddWithValue("placa_equi", placa);
                    cmd.Parameters.AddWithValue("serie_equi", serie);
                    cmd.Parameters.AddWithValue("cartel", cartel);
                    cmd.ExecuteNonQuery();
                }
                return estado;
            }
            catch (Exception)
            {
                if (_mysqlConnection.State.ToString() == "Closed")
                {

                    SetDatabaseConnection();
                }
                return false;
            }
            
        }
        
        public DataTable GetAllTypeDevice()
        {
            DataTable datos = new DataTable();
            using (MySqlDataAdapter adaptador = new MySqlDataAdapter(Query.MysqlGetAllTypeDevice,_mysqlConnection))
            {
                adaptador.Fill(datos);
            }
            return datos;
        }
        
        public DataTable GetAllTypeMaterials()
        {
            DataTable datos = new DataTable();
            using (MySqlDataAdapter adaptador = new MySqlDataAdapter(Query.MysqlGetAllTypeMaterials, _mysqlConnection))
            {
                adaptador.Fill(datos);
            }
            return datos;
        }

        public InstalledDevice GetDevicesInInstitutionFromCode(string codigo,string tipo,int orden)
        {
            InstalledDevice equi = new InstalledDevice();
            try
            {
                string consulta = string.Empty;
                
                if (tipo.Equals("ADMINISTRATIVO"))
                {
                    consulta = "SELECT * FROM equipos_instalacion_instituciones_final WHERE Codigo_Institucion= '" + codigo + "' AND id_orden = '"+orden+"'";

                }
                else
                {
                    consulta = "SELECT * FROM equipos_instalacion_instituciones WHERE Codigo_Institucion= '" + codigo + "'";
                }

                _mysqlCommand = new MySqlCommand(consulta, _mysqlConnection);
                using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        equi.Codigo = lector["Codigo_Institucion"].ToString();
                        equi.Modalidad = lector["Modalidad"].ToString();
                        equi.Condicion = lector["Condicion"].ToString();
                        equi.Port_docente = Convert.ToInt32(lector["Port_1_docente"]);
                        equi.Port_preescolar = Convert.ToInt32(lector["Port_1_preeescolar"]);
                        equi.Port_1_estudiante = Convert.ToInt32(lector["Port_1_estudiante"]);
                        equi.Port_2_estudiante = Convert.ToInt32(lector["Port_2_estudiante"]);
                        equi.Servidor = Convert.ToInt32(lector["Servidor"]);
                        equi.Nas = Convert.ToInt32(lector["Nas"]);
                        equi.Proyector = Convert.ToInt32(lector["Proyector"]);
                        equi.Impresora = Convert.ToInt32(lector["Impresora"]);
                        equi.Audifonos = Convert.ToInt32(lector["Audifonos"]);
                        equi.Mouse = Convert.ToInt32(lector["Mouse"]);
                        equi.Candados = Convert.ToInt32(lector["Candados"]);
                        equi.Convertidor = Convert.ToInt32(lector["ConvertirdorPolarizado"]);
                        equi.Extensiones = Convert.ToInt32(lector["Extensiones"]);
                        equi.Regletas = Convert.ToInt32(lector["Regletas"]);
                        equi.Maletin_proyector = Convert.ToInt32(lector["Maletin_proyector"]);
                        equi.Maletin_portatil = Convert.ToInt32(lector["Maletin_portatil"]);
                        equi.Router = Convert.ToInt32(lector["Router"]);
                        equi.Switch24 = Convert.ToInt32(lector["Switch"]);
                        equi.Ap_interno = Convert.ToInt32(lector["ApInterno"]);
                        equi.Ap_externo = Convert.ToInt32(lector["ApExterno"]);
                        equi.Parlantes_1 = Convert.ToInt32(lector["Parlantes_1"]);
                        equi.Parlantes_2 = Convert.ToInt32(lector["Parlantes_2"]);
                        equi.Unidad_optica = Convert.ToInt32(lector["Unidad_optica"]);
                        equi.UPS_1 = Convert.ToInt32(lector["Ups_1"]);
                        equi.UPS_2 = Convert.ToInt32(lector["Ups_2"]);

                        if (tipo.Equals("BODEGA"))
                        {
                            equi.Cable_hdmi = Convert.ToInt32(lector["Cable_hdmi"]);
                            equi.Cable_usb = Convert.ToInt32(lector["Cable_usb"]);
                            equi.Cable_vga = Convert.ToInt32(lector["Cable_vga"]);
                            equi.Patch_blanco = Convert.ToInt32(lector["Patch_blanco"]);
                            equi.Cartucho_tinta = Convert.ToInt32(lector["Cartucho_tinta"]);

                        }

                    }
                }
                
            }
            catch (Exception)
            {

                MessageBox.Show("Error al procesar datos vuelva a intentarlo", "Error al procesar Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return equi;
        }

        public DataTable GetTotalRecordOrders()
        {
            DataTable data_pedidos = new DataTable();
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(Query.MysqlGetTotalRecordOrders, _mysqlConnection))
            {

                adapter.Fill(data_pedidos);
            }
            return data_pedidos;

        }
        
        public InstalledDevice GetFinalInventoryOrder(int orden)
        {
            InstalledDevice equi = new InstalledDevice();
            _mysqlCommand = new MySqlCommand();
            _mysqlCommand.Connection = _mysqlConnection;
            _mysqlCommand.CommandText = Query.MysqlGetFinalInventoryOrder;
            _mysqlCommand.Parameters.AddWithValue("@orden", orden);

            using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
            {
                while (lector.Read())
                {
                    equi.Codigo = lector["Codigo_Institucion"].ToString();
                    equi.Modalidad = lector["Modalidad"].ToString();
                    equi.Condicion = lector["Condicion"].ToString();
                    equi.Port_docente = Convert.ToInt32(lector["Port_1_docente"]);
                    equi.Port_preescolar = Convert.ToInt32(lector["Port_1_preeescolar"]);
                    equi.Port_1_estudiante = Convert.ToInt32(lector["Port_1_estudiante"]);
                    equi.Port_2_estudiante = Convert.ToInt32(lector["Port_2_estudiante"]);
                    equi.Servidor = Convert.ToInt32(lector["Servidor"]);
                    equi.Nas = Convert.ToInt32(lector["Nas"]);
                    equi.Proyector = Convert.ToInt32(lector["Proyector"]);
                    equi.Impresora = Convert.ToInt32(lector["Impresora"]);
                    equi.Audifonos = Convert.ToInt32(lector["Audifonos"]);
                    equi.Mouse = Convert.ToInt32(lector["Mouse"]);
                    equi.Candados = Convert.ToInt32(lector["Candados"]);
                    equi.Convertidor = Convert.ToInt32(lector["ConvertirdorPolarizado"]);
                    equi.Extensiones = Convert.ToInt32(lector["Extensiones"]);
                    equi.Regletas = Convert.ToInt32(lector["Regletas"]);
                    equi.Maletin_proyector = Convert.ToInt32(lector["Maletin_proyector"]);
                    equi.Maletin_portatil = Convert.ToInt32(lector["Maletin_portatil"]);
                    equi.Router = Convert.ToInt32(lector["Router"]);
                    equi.Switch24 = Convert.ToInt32(lector["Switch"]);
                    equi.Ap_interno = Convert.ToInt32(lector["ApInterno"]);
                    equi.Ap_externo = Convert.ToInt32(lector["ApExterno"]);
                    equi.Parlantes_1 = Convert.ToInt32(lector["Parlantes_1"]);
                    equi.Parlantes_2 = Convert.ToInt32(lector["Parlantes_2"]);
                    equi.Unidad_optica = Convert.ToInt32(lector["Unidad_optica"]);
                    equi.UPS_1 = Convert.ToInt32(lector["Ups_1"]);
                    equi.UPS_2 = Convert.ToInt32(lector["Ups_2"]);
                    equi.Cable_hdmi = Convert.ToInt32(lector["Cable_hdmi"]);
                    equi.Cable_usb = Convert.ToInt32(lector["Cable_usb"]);
                    equi.Cable_vga = Convert.ToInt32(lector["Cable_vga"]);
                    equi.Patch_blanco = Convert.ToInt32(lector["Patch_blanco"]);
                    equi.Cartucho_tinta = Convert.ToInt32(lector["Cartucho_tinta"]);
                    equi.Id_Registro = Convert.ToInt32(lector["id_registro"]);
                }
            }
            return equi;
        }
        
        public bool SaveFinalInventoryOrder(InstalledDevice equi,string orden,string encargado,string num_pedido)
        {
            try
            {
                _mysqlTrasaction = _mysqlConnection.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = _mysqlConnection;
                    cmd.CommandText = Query.MysqlProcedureSaveFinalInventoryOrder;
                    cmd.Parameters.AddWithValue("Codigo", equi.Codigo);
                    cmd.Parameters.AddWithValue("Modalidad", equi.Modalidad);
                    cmd.Parameters.AddWithValue("Condicion", equi.Condicion);
                    cmd.Parameters.AddWithValue("Lote", equi.Lote);
                    cmd.Parameters.AddWithValue("Observaciones", equi.observacion);
                    cmd.Parameters.AddWithValue("port_docente",equi.Port_docente);
                    cmd.Parameters.AddWithValue("port_preescolar", equi.Port_preescolar);
                    cmd.Parameters.AddWithValue("port_1_estudiante", equi.Port_1_estudiante);
                    cmd.Parameters.AddWithValue("port_2_estudiante", equi.Port_2_estudiante);
                    cmd.Parameters.AddWithValue("servidor", equi.Servidor);
                    cmd.Parameters.AddWithValue("nas", equi.Nas);
                    cmd.Parameters.AddWithValue("proyector", equi.Proyector);
                    cmd.Parameters.AddWithValue("impresora", equi.Impresora);
                    cmd.Parameters.AddWithValue("audifonos", equi.Audifonos);
                    cmd.Parameters.AddWithValue("candados", equi.Candados);
                    cmd.Parameters.AddWithValue("convertidor", equi.Convertidor);
                    cmd.Parameters.AddWithValue("extensiones", equi.Extensiones);
                    cmd.Parameters.AddWithValue("regletas", equi.Regletas);
                    cmd.Parameters.AddWithValue("maletin_proyector", equi.Maletin_proyector);
                    cmd.Parameters.AddWithValue("maletin_portatil", equi.Maletin_portatil);
                    cmd.Parameters.AddWithValue("router", equi.Router);
                    cmd.Parameters.AddWithValue("switch24", equi.Switch24);
                    cmd.Parameters.AddWithValue("ap_interno", equi.Ap_interno);
                    cmd.Parameters.AddWithValue("ap_externo", equi.Ap_externo);
                    cmd.Parameters.AddWithValue("parlantes_1", equi.Parlantes_1);
                    cmd.Parameters.AddWithValue("parlantes_2", equi.Parlantes_2);
                    cmd.Parameters.AddWithValue("unidad_optica", equi.Unidad_optica);
                    cmd.Parameters.AddWithValue("ups_1", equi.UPS_1);
                    cmd.Parameters.AddWithValue("ups_2", equi.UPS_2);
                    cmd.Parameters.AddWithValue("cargador_ap", equi.Cargador_AP);
                    cmd.Parameters.AddWithValue("Patch_blanco", equi.Patch_blanco);
                    cmd.Parameters.AddWithValue("Patch_verde", equi.Patch_verde);
                    cmd.Parameters.AddWithValue("Cable_hdmi", equi.Cable_hdmi);
                    cmd.Parameters.AddWithValue("Cable_vga", equi.Cable_vga);
                    cmd.Parameters.AddWithValue("Cable_usb", equi.Cable_usb);
                    cmd.Parameters.AddWithValue("Cartucho_tinta", equi.Cartucho_tinta);
                    cmd.Parameters.AddWithValue("mouse", equi.Mouse);
                    cmd.Parameters.AddWithValue("fecha", DateTime.Now.ToString("MM/dd/yyyy"));
                    cmd.Parameters.AddWithValue("orden", Convert.ToInt32(orden));
                    cmd.Parameters.AddWithValue("usuario", encargado);
                    cmd.Parameters.AddWithValue("id_pedido", num_pedido);
                    cmd.Connection = _mysqlConnection;
                    cmd.ExecuteNonQuery();

                }
                _mysqlTrasaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _mysqlTrasaction.Rollback();
                MessageBox.Show("Error\n" + ex);
                return false;

            }

        }
        
        public void SaveChangeInDatabase(string placa, string serie, int accion,string estado,int estacion)
        {
            try
            {
                //insertar_cambios
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = _mysqlConnection;
                    cmd.CommandText = Query.MysqlProcedureSaveChangeInDatabase;
                    cmd.Parameters.AddWithValue("placa",placa);
                    cmd.Parameters.AddWithValue("serie",serie);
                    cmd.Parameters.AddWithValue("orden",accion);
                    cmd.Parameters.AddWithValue("tipo", estado);
                    cmd.Parameters.AddWithValue("estacion", estacion);
                    cmd.Parameters.AddWithValue("fecha",VariablesName.ActualDate);
                    cmd.Connection = _mysqlConnection;
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Registro ya existe "+ex, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public bool DeleteDevice(string placa, string serie, int workAction, int NumberEstation)
        {
            try
            {
                bool estado = true;
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlDeleteDevice;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("@placa", placa);
                    cmd.Parameters.AddWithValue("@workAction", workAction);
                    cmd.ExecuteNonQuery();
                }
                SaveChangeInDatabase(placa,serie,workAction,"ELIMINADO",NumberEstation);
                return estado;
            }
            catch (Exception EX)
            {
                MessageBox.Show("Error al guardar Registros "+EX, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        
        public List<string> GetListMaterials()
        {
            List<string> materiales = new List<string>();

            _mysqlCommand = new MySqlCommand(Query.MysqlGetListMaterials, _mysqlConnection);
            using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
            {
                while (lector.Read())
                {
                    materiales.Add(lector["descripcion"].ToString());
                }
            }
            return materiales;
        }
        
        public List<string> GetTecnicals()
        {
            List<string> tecnicos = new List<string>();
            _mysqlCommand = new MySqlCommand(Query.MysqlGetTecnicals, _mysqlConnection);
            using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
            {
                while (lector.Read())
                {
                    tecnicos.Add(lector["nombre"].ToString());
                }
            }
            return tecnicos;
        }
        
        public int GetCodeTechnicals()
        {
            int valor_codigo = 0;
            _mysqlCommand = new MySqlCommand(Query.MysqlGetCodeTechnicals, _mysqlConnection);
            using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
            {
                while (lector.Read())
                {
                    valor_codigo = Convert.ToInt32(lector["codigo_tecnico"].ToString());
                }
            }
            return valor_codigo + 1;
        }
        
        public bool SaveTechnical(string nameTechnical)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    int codigo = GetCodeTechnicals();
                    cmd.CommandText = Query.MysqlSaveTechnical;
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@nameTechnical", nameTechnical);
                    cmd.Connection = _mysqlConnection;
                    cmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        
        public DataTable GetInvoiceMaterials(string tipo)
        {
            DataTable datos = new DataTable();
            string consulta = string.Empty;
            if (tipo.Equals("Facturas Equipos"))
            {
                consulta = Query.MysqlGetInvoice;
            }
            else
            {
                consulta = Query.MysqlGetInvoiceMaterials;
            }
            using (MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, _mysqlConnection))
            {
                adaptador.Fill(datos);
            }
            return datos;
        }
        
        public DataTable GetAllInventoryMaterials()
        {
            DataTable datos = new DataTable();
            
            using (MySqlDataAdapter adaptador = new MySqlDataAdapter(Query.MysqlGetAllInventoryMaterials, _mysqlConnection))
            {
                adaptador.Fill(datos);
            }
            return datos;
        }
        
        public bool SaveUnitCostMaterials(string idInvoice,string detail, double cost, string codeDevice,string typeDevice)
        {
            try
            {
                _mysqlTrasaction = _mysqlConnection.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = _mysqlConnection;
                    cmd.CommandText = Query.MysqlProcedureSaveUnitCostMaterials;
                    cmd.Parameters.AddWithValue("num_fac", idInvoice);
                    cmd.Parameters.AddWithValue("detalle", detail);
                    cmd.Parameters.AddWithValue("valor", cost);
                    cmd.Parameters.AddWithValue("codigo_equipo", codeDevice);
                    cmd.Parameters.AddWithValue("tipo", typeDevice);
                    cmd.Connection = _mysqlConnection;
                    cmd.ExecuteNonQuery();

                }
                _mysqlTrasaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _mysqlTrasaction.Rollback();
                MessageBox.Show("Error\n" + ex);
                return false;

            }

        }
        
        public List<string> GetAllNameDamage()
        {
            List<string> danos = new List<string>();
            _mysqlCommand = new MySqlCommand(Query.MysqlGetAllNameDamage, _mysqlConnection);
            using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
            {
                while (lector.Read())
                {
                    danos.Add(lector["dano"].ToString());
                }
            }

            return danos;
        }
        
        public DataTable GetAllDeviceDamage()
        {
            DataTable datos = new DataTable();

            using (MySqlDataAdapter adaptador = new MySqlDataAdapter(Query.MysqlGetAllDeviceDamage, _mysqlConnection))
            {
                adaptador.Fill(datos);
            }
            return datos;
        }
        
        public bool SaveNewDamage(string placa, string serie, string dano, string estado)
        {
            try
            {
                _mysqlTrasaction = _mysqlConnection.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = _mysqlConnection;
                    cmd.CommandText = Query.MysqlSaveNewDamage;
                    cmd.Parameters.AddWithValue("placa_equi", placa);
                    cmd.Parameters.AddWithValue("serie_equi", serie);
                    cmd.Parameters.AddWithValue("danos", dano);
                    cmd.Parameters.AddWithValue("estado_equi", estado);

                    cmd.Connection = _mysqlConnection;
                    cmd.ExecuteNonQuery();

                }
                _mysqlTrasaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _mysqlTrasaction.Rollback();
                MessageBox.Show("Error\n" + ex);
                return false;

            }

        }
        
        public string GetRolSystemFromIdUser(string user, string password)
        {
            try
            {
                string rol = string.Empty;

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlGetRolSystemFromIdUser;
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Connection = _mysqlConnection;
                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            rol = lector["rol_user"].ToString();
                        }
                    }
                    
                }
                return rol;
            }
            catch (Exception)
            {

                throw;
            }
            

        }
        
        public DataSet GetDevicesInWarranty(string status)
        {
            string consulta = string.Empty;
            DataSet data = new DataSet();
            try
            {
                if (status.Equals("GENERAL"))
                {
                    consulta = "SELECT * FROM view_equipos_reparacion";
                }
                else
                {
                    consulta = "SELECT * FROM view_equipos_reparacion WHERE ESTADO ='"+status+"'" ;
                }
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, _mysqlConnection))
                {

                    adapter.Fill(data);
                }

            }
            catch (Exception)
            {
                if (_mysqlConnection.State.ToString() == "Closed")
                {

                    SetDatabaseConnection();
                }


            }
            return data;

        }

        public string GetDescriptionOutputOrderFromIdOrder(int idOrder)
        {
            string descrip = string.Empty;

            try
            {
                
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlGetDescriptionOutputOrderFromIdOrder;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("@idOrder", idOrder);
                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            descrip = lector["descripcion"].ToString();
                        }
                    }

                }

            }
            catch (Exception)
            {
                if (_mysqlConnection.State.ToString() == "Closed")
                {

                    SetDatabaseConnection();
                    descrip = "Error al procersar los datos";
                }


            }
            return descrip;

        }
        
        public string GetDescriptionWorkActionFromId(int idOrder)
        {
            string descrip = string.Empty;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlGetDescriptionWorkActionFromId;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("@idOrder", idOrder);
                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            descrip = lector["Descripcion"].ToString();
                        }
                    }

                }

            }
            catch (Exception)
            {
                if (_mysqlConnection.State.ToString() == "Closed")
                {

                    SetDatabaseConnection();
                    descrip = "Error al procersar los datos";
                }


            }
            return descrip;

        }
        
        public List<string> GetRoles()
        {
            List<string> roles = new List<string>();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlGetRoles;
                    cmd.Connection = _mysqlConnection;
                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            roles.Add(lector["id_rol"].ToString());
                        }
                    }

                }

            }
            catch (Exception)
            {
                if (_mysqlConnection.State.ToString() == "Closed")
                {

                    SetDatabaseConnection();
                }


            }
            return roles;

        }
        
        public bool SaveUserSystem(string user,string pass,string rol)
        {
            try
            {
                _mysqlTrasaction = _mysqlConnection.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlSaveUserSystem;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@rol", rol);

                    cmd.ExecuteNonQuery();

                }
                _mysqlTrasaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _mysqlTrasaction.Rollback();
                MessageBox.Show("Error\n" + ex);
                return false;

            }

        }
        
        public Installation GetAllInformationInInstitutionFromCode(string code)
        {
            Installation insta = new Installation();
            _mysqlCommand = new MySqlCommand();
            _mysqlCommand.Connection = _mysqlConnection;
            _mysqlCommand.CommandText = Query.MysqlGetAllInformationInInstitutionFromCode;
            _mysqlCommand.Parameters.AddWithValue("@code", code);
            using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
            {

                if (lector.Read())
                {
                    insta.Codigo_pre = lector["codigo_institucion"].ToString();
                    insta.Cantidad_aps = Convert.ToInt32(lector["cantidad_instalada"].ToString());
                    insta.Descripcion = lector["descripcion"].ToString();
                    insta.Fecha = lector["fecha_registro"].ToString();
                    insta.Documento = lector["documento"].ToString();
                }
                return insta;
            }

        }
        
        public string GetPendingOrder()
        {
            string num_accion = string.Empty;
            _mysqlCommand = new MySqlCommand(Query.MysqlGetPendingOrder, _mysqlConnection);
            using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
            {
                while (lector.Read())
                {
                    num_accion = lector["Total"].ToString();
                }
            }
            return num_accion;
        }

        public bool RegisterNewCartel(string code, string description, string date)
        {
            try
            {
                _mysqlTrasaction = _mysqlConnection.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlRegisterNewCartel ;
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Connection = _mysqlConnection;
                    cmd.ExecuteNonQuery();

                }
                _mysqlTrasaction.Commit();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }


}
