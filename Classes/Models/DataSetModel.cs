using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using SystemInventory.Classes.Models;
using SystemIventory.Classes;

namespace SystemInventory.Classes.IModels
{
    public class DataSetModel : IDataSetModel
    {
        private MySqlDataAdapter _mysqlAdapter = null;
        private MySqlConnection _mysqlConnection = null;
        private static DataSetModel _dataSetModel = null;
        private DataSet _sourceWorkActions = null;
        IConnection _connection = null;
        private DataSetModel()
        {
            _sourceWorkActions = new DataSet();
            _connection = new DbConnection();
            _mysqlConnection = _connection.GetConnection();
        }
        public static DataSetModel Get_Instance
        {
            get
            {
                if (_dataSetModel == null)
                {
                    _dataSetModel = new DataSetModel();

                }

                return _dataSetModel;
            }
        }
        public ResponseQuery GetWorkActionReport(int workAction)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {

                    _sourceWorkActions.Clear();
                    cmd.CommandText = Query.MysqlGetWorkActionReport;
                    cmd.Parameters.AddWithValue("@workAction", workAction);
                    cmd.Connection = _mysqlConnection;
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(_sourceWorkActions);
                    }
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = _sourceWorkActions
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery GetOrderReport(int order, string location)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    _sourceWorkActions.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Query.MysqlProcedureGetOrderReport;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("orden", order);
                    cmd.Parameters.AddWithValue("ubicacion", location);
                    cmd.Connection = _mysqlConnection;
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(_sourceWorkActions);
                    }
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = _sourceWorkActions
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery GetOuputMaterialReport(int order)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    _sourceWorkActions.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Query.MysqlProcedureGetOuputMaterialReport;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("orden_buscar", order);
                    cmd.Connection = _mysqlConnection;
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(_sourceWorkActions);
                    }

                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = _sourceWorkActions
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery GetGeneralDevicesReport()
        {
            try
            {
                _sourceWorkActions.Clear();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(Query.MysqlGetGeneralDevicesReport, _mysqlConnection))
                {

                    adapter.Fill(_sourceWorkActions);
                }

                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = _sourceWorkActions
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery GetDevicesInWarranty(string status)
        {
            try
            {
                string consulta = string.Empty;
                _sourceWorkActions.Clear();
                if (status.Equals("GENERAL"))
                {
                    consulta = "SELECT * FROM view_equipos_reparacion";
                }
                else
                {
                    consulta = "SELECT * FROM view_equipos_reparacion WHERE ESTADO ='" + status + "'";
                }
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, _mysqlConnection))
                {

                    adapter.Fill(_sourceWorkActions);
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = _sourceWorkActions
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }

    }
}
