
using MySql.Data.MySqlClient;
using System;
using SystemInventory.Classes.IModels;
using System.Data;
using SystemIventory.Classes;
using System.Collections.Generic;

namespace SystemInventory.Classes.Models
{
    public class DataTableModel : IDataTableModel
    {
        private MySqlDataAdapter _mysqlAdapter = null;
        private MySqlConnection _mysqlConnection =  null;
        private static DataTableModel _dataTableModel = null;
        IConnection _connection = null;
        private DataTableModel()
        {
            _connection = new DbConnection();
            _mysqlConnection = _connection.GetConnection();
        }
        public static DataTableModel Get_Instance
        {
            get
            {
                if (_dataTableModel == null)
                {
                    _dataTableModel = new DataTableModel();

                }

                return _dataTableModel;
            }
        }
        public ResponseQuery GetAllDataReequipamiento()
        {
            try
            {
                DataTable dataTable = new DataTable();
                _mysqlAdapter = new MySqlDataAdapter(Query.MysqlGetDataReequipamiento, _mysqlConnection);
                _mysqlAdapter.Fill(dataTable);
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = dataTable
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery GetWorkActionFromId(string command, string idWorkAction)
        {
            DataTable dataTable = new DataTable();
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
                    _mysqlAdapter.Fill(dataTable);
                    return new ResponseQuery 
                    {
                        StatusQuery = true,
                        Result = dataTable
                    };
                }
                catch (Exception ex)
                {

                    return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
                }
            }
        }

        public ResponseQuery GetAllWorkAction(int workAction)
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlGetAllWorkAction;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("@workAction", workAction);
                    _mysqlAdapter = new MySqlDataAdapter(cmd);
                    _mysqlAdapter.Fill(dataTable);
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = dataTable
                };
            }
            catch (Exception ex)
            {

                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery GetInfromationWokActionFromType(int accion, string tipo)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string consulta = String.Empty;
                if (accion == 0)
                {
                    consulta = "SELECT * FROM view_estado_accion where Tipo_Orden = '" + tipo + "' ORDER BY accion DESC";

                }
                else
                {
                    consulta = "SELECT * FROM view_estado_accion WHERE accion = '" + accion + "' AND Tipo_Orden = '" + tipo + "' ORDER BY accion DESC";
                }
                using (MySqlDataAdapter lector = new MySqlDataAdapter(consulta, _mysqlConnection))
                {
                    lector.Fill(dataTable);
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = dataTable
                };
            }
            catch (Exception ex)
            {

                return new ResponseQuery { StatusQuery = false,Result=dataTable,MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery GetChangesWorkAction(int orden, string tipo)
        {
            DataTable dataTable = new DataTable();
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
                        lector.Fill(dataTable);
                    }
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = dataTable
                };
            }
            catch (Exception ex)
            {

                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery GetWorkActionMaterials()
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (MySqlDataAdapter lector = new MySqlDataAdapter(Query.MysqlGetWorkActionMaterials, _mysqlConnection))
                {
                    lector.Fill(dataTable);
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = dataTable
                };
            }
            catch (Exception ex)
            {

                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery GetStatusWorkActionInProduction(string tipo)
        {
            try
            {
                DataTable dataTable = new DataTable();
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
                    lector.Fill(dataTable);
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = dataTable
                };
            }
            catch (Exception ex)
            {

                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery GetDataListInstitutionFromWorkAction(string comando, string accion)
        {
            DataTable dataTable = new DataTable();
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
                    _mysqlAdapter.Fill(dataTable);
                }

                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = dataTable
                };
            }
            catch (Exception ex)
            {

                return new ResponseQuery { StatusQuery = false,Result=dataTable ,MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery GetAllTypeDevice()
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(Query.MysqlGetAllTypeDevice, _mysqlConnection))
                {
                    adaptador.Fill(dataTable);
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = dataTable
                };
            }
            catch (Exception ex)
            {

                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery GetAllTypeMaterials()
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(Query.MysqlGetAllTypeMaterials, _mysqlConnection))
                {
                    adaptador.Fill(dataTable);
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = dataTable
                };
            }
            catch (Exception ex)
            {

                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery GetTotalRecordOrders()
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(Query.MysqlGetTotalRecordOrders, _mysqlConnection))
                {

                    adapter.Fill(dataTable);
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = dataTable
                };
            }
            catch (Exception ex)
            {

                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery GetInvoiceMaterials(string tipo)
        {
            try
            {
                DataTable dataTable = new DataTable();
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
                    adaptador.Fill(dataTable);
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = dataTable
                };
            }
            catch (Exception ex)
            {

                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery GetAllInventoryMaterials()
        {
            try
            {
                DataTable dataTable = new DataTable();

                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(Query.MysqlGetAllInventoryMaterials, _mysqlConnection))
                {
                    adaptador.Fill(dataTable);
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = dataTable
                };
            }
            catch (Exception ex)
            {

                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery GetAllDeviceDamage()
        {
            try
            {
                DataTable dataTable = new DataTable();

                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(Query.MysqlGetAllDeviceDamage, _mysqlConnection))
                {
                    adaptador.Fill(dataTable);
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = dataTable
                };
            }
            catch (Exception ex)
            {

                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }
    }
}
