using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using SystemInventory.Classes.IModels;
using SystemIventory.Classes.Entities;
using SystemIventory.Classes;
using SystemInventory.Classes.Entities;
using System.Data;

namespace SystemInventory.Classes.Models
{
    public class DataBaseRepository : IDataBaseRepository
    {
        private static DataBaseRepository _dataBaseRepository = null;
        private MySqlConnection _mysqlConnection = null;
        private MySqlTransaction _mysqlTrasaction;
        private IConnection _connection;
        public List<string> Carteles { get; } = new List<string>();
        private Dictionary<string, int> _totalLocations = new Dictionary<string, int>();
        private Dictionary<string, int> _totalTecnicals = new Dictionary<string, int>();
        private DataBaseRepository()
        {
            _connection = new DbConnection();
            _mysqlConnection = _connection.GetConnection();

            
        }
        public static DataBaseRepository Get_Instance
        {
            get
            {
                if (_dataBaseRepository == null)
                {
                    _dataBaseRepository = new DataBaseRepository();

                }

                return _dataBaseRepository;
            }
        }
        public ResponseQuery SaveInstitution(SystemIventory.Classes.Entities.Institution institution)
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
                    return new ResponseQuery
                    {
                        StatusQuery = true
                    };
                }
                catch (Exception ex)
                {
                    return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
                }
            }
        }
        public ResponseQuery GetInstitutionCode(string code, string queryType)
        {
            try
            {
                string institucion = string.Empty;

                var _mysqlCommand = new MySqlCommand(Query.MysqlGetNameInstitution, _mysqlConnection);
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

                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = institucion
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery SaveRegisterReequipamiento(int codeModel, string serial, string placa, string query)
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
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                _mysqlTrasaction.Rollback();
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery UpdateStatusList(int list, string statusList)
        {
            try
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
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery GetNextCodeProduct()
        {
            try
            {
                int valor_codigo = 0;
                using (var _mysqlCommand = new MySqlCommand(Query.MysqlGetNextCodeProduct, _mysqlConnection))
                {
                    using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            valor_codigo = Convert.ToInt32(lector["codigo_modelo"].ToString());
                        }
                    }

                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = (valor_codigo + 1)
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery GetAllTypesDevice()
        {
            try
            {
                _mysqlTrasaction = _mysqlConnection.BeginTransaction();
                List<string> typeList = new List<string>();
                using (var _mysqlCommand = new MySqlCommand(Query.MysqlGetAllTypeDevice, _mysqlConnection))
                {
                    using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            typeList.Add(lector["codigo_modelo"].ToString() + "-" + lector["tipo_equipo"].ToString());

                        }
                    }

                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = typeList
                };
            }
            catch (Exception ex)
            {
                _mysqlTrasaction.Rollback();
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery SaveModelDevice(int code, string brand, string model, string queryType)
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
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                _mysqlTrasaction.Rollback();
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }
        public ResponseQuery SearchDeviceFromId(string placa_serie, string queryType)
        {
            Device device = new Device();
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
                            device.Placa = lector.GetString("placa");
                            device.Serie = lector.GetString("serie");
                            device.Marca = lector.GetString("marca");
                            device.Modelo = lector.GetString("modelo");
                            device.Tipo_equipo = lector.GetString("tipo_equipo");
                        }

                    }
                    return new ResponseQuery
                    {
                        StatusQuery = true,
                        Result = device
                    };
                }
                catch (Exception ex)
                {
                    return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
                }
            }

        }

        public ResponseQuery GetIdWorkActionFromType(string typeWorkAction)
        {
            try
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

                var _mysqlCommand = new MySqlCommand(_consulta, _mysqlConnection);
                using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        num_accion = Convert.ToInt32(lector["Codigo"]);
                    }
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = num_accion
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery GetIdOrder()
        {
            try
            {
                int num_accion = 0;
                using (var _mysqlCommand = new MySqlCommand(Query.MysqlGetIdOrder, _mysqlConnection))
                {
                    using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            num_accion = Convert.ToInt32(lector["Codigo"]);
                        }
                    }
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = (num_accion + 1)
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery SaveInventoryRecord(Equipos_Reequipamiento deviceReequipamiento, string query)
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
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                _mysqlTrasaction.Rollback();
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery SaveNewWorkAction(int workAction, string description, string typeWorkAction)
        {
            try
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
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery SaveNewOrderMaterialsWorkAction(int orden, string descripcion)
        {
            try
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
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery UpdateNewOrderMaterialsWorkAction(string descripcion, int cantidad, int orden)
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
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery GetTotalMaterialsInStockFromDescription(string description)
        {
            try
            {
                int count = 0;
                var _mysqlCommand = new MySqlCommand()
                {
                    CommandText = Query.MysqlGetTotalMaterialsInStockFromDescription
                };
                _mysqlCommand.Parameters.AddWithValue("@description", description);
                _mysqlCommand.Connection = _mysqlConnection;
                using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        count = Convert.ToInt32(lector["cantidad"]);
                    }
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = count
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, Result = -1, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery SaveNewOrderMaterialsForTecnicals(string descripcion, int cantidad, int orden, string tecnico)
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
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery SaveNewProduct(string codigo, string descripcion)
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
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }


        public ResponseQuery UpdateStatusWorkActionInProduction(int orden, string estado_update)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlUpdateStatusWorkActionInProduction;
                    cmd.Parameters.AddWithValue("@estado_update", estado_update);
                    cmd.Parameters.AddWithValue("@orden", orden);
                    cmd.Connection = _mysqlConnection;
                    cmd.ExecuteNonQuery();
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery ApplyWorkAction(int accion, string estado)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlProcedureApplyWorkAction;
                    cmd.Connection = _mysqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("accion", accion);
                    cmd.Parameters.AddWithValue("estado", _totalLocations[estado]);
                    cmd.ExecuteNonQuery();
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery SaveInvoice(int numero, string detalle, double valor, string fecha, int orden, string tipo)
        {
            try
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
                    cmd.Parameters.AddWithValue("tipo", tipo);
                    cmd.ExecuteNonQuery();
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }


        public ResponseQuery SaveNewDevice(int tipo, string placa, string serie, string cartel)
        {
            try
            {
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
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }


        public ResponseQuery GetDevicesInInstitutionFromCode(string codigo, string tipo, int orden)
        {
            InstalledDevice installedDevice = new InstalledDevice();
            try
            {
                string consulta = string.Empty;

                if (tipo.Equals("ADMINISTRATIVO"))
                {
                    consulta = "SELECT * FROM equipos_instalacion_instituciones_final WHERE Codigo_Institucion= '" + codigo + "' AND id_orden = '" + orden + "'";

                }
                else
                {
                    consulta = "SELECT * FROM equipos_instalacion_instituciones WHERE Codigo_Institucion= '" + codigo + "'";
                }
                using (var _mysqlCommand = new MySqlCommand(consulta, _mysqlConnection))
                {

                    using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            installedDevice.Codigo = lector["Codigo_Institucion"].ToString();
                            installedDevice.Modalidad = lector["Modalidad"].ToString();
                            installedDevice.Condicion = lector["Condicion"].ToString();
                            installedDevice.Port_docente = Convert.ToInt32(lector["Port_1_docente"]);
                            installedDevice.Port_preescolar = Convert.ToInt32(lector["Port_1_preeescolar"]);
                            installedDevice.Port_1_estudiante = Convert.ToInt32(lector["Port_1_estudiante"]);
                            installedDevice.Port_2_estudiante = Convert.ToInt32(lector["Port_2_estudiante"]);
                            installedDevice.Servidor = Convert.ToInt32(lector["Servidor"]);
                            installedDevice.Nas = Convert.ToInt32(lector["Nas"]);
                            installedDevice.Proyector = Convert.ToInt32(lector["Proyector"]);
                            installedDevice.Impresora = Convert.ToInt32(lector["Impresora"]);
                            installedDevice.Audifonos = Convert.ToInt32(lector["Audifonos"]);
                            installedDevice.Mouse = Convert.ToInt32(lector["Mouse"]);
                            installedDevice.Candados = Convert.ToInt32(lector["Candados"]);
                            installedDevice.Convertidor = Convert.ToInt32(lector["ConvertirdorPolarizado"]);
                            installedDevice.Extensiones = Convert.ToInt32(lector["Extensiones"]);
                            installedDevice.Regletas = Convert.ToInt32(lector["Regletas"]);
                            installedDevice.Maletin_proyector = Convert.ToInt32(lector["Maletin_proyector"]);
                            installedDevice.Maletin_portatil = Convert.ToInt32(lector["Maletin_portatil"]);
                            installedDevice.Router = Convert.ToInt32(lector["Router"]);
                            installedDevice.Switch24 = Convert.ToInt32(lector["Switch"]);
                            installedDevice.Ap_interno = Convert.ToInt32(lector["ApInterno"]);
                            installedDevice.Ap_externo = Convert.ToInt32(lector["ApExterno"]);
                            installedDevice.Parlantes_1 = Convert.ToInt32(lector["Parlantes_1"]);
                            installedDevice.Parlantes_2 = Convert.ToInt32(lector["Parlantes_2"]);
                            installedDevice.Unidad_optica = Convert.ToInt32(lector["Unidad_optica"]);
                            installedDevice.UPS_1 = Convert.ToInt32(lector["Ups_1"]);
                            installedDevice.UPS_2 = Convert.ToInt32(lector["Ups_2"]);

                            if (tipo.Equals("BODEGA"))
                            {
                                installedDevice.Cable_hdmi = Convert.ToInt32(lector["Cable_hdmi"]);
                                installedDevice.Cable_usb = Convert.ToInt32(lector["Cable_usb"]);
                                installedDevice.Cable_vga = Convert.ToInt32(lector["Cable_vga"]);
                                installedDevice.Patch_blanco = Convert.ToInt32(lector["Patch_blanco"]);
                                installedDevice.Cartucho_tinta = Convert.ToInt32(lector["Cartucho_tinta"]);

                            }

                        }
                    }

                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = installedDevice
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }


        }
        public ResponseQuery GetFinalInventoryOrder(int orden)
        {
            try
            {
                InstalledDevice installedDevice = new InstalledDevice();
                using (var _mysqlCommand = new MySqlCommand())
                {
                    _mysqlCommand.Connection = _mysqlConnection;
                    _mysqlCommand.CommandText = Query.MysqlGetFinalInventoryOrder;
                    _mysqlCommand.Parameters.AddWithValue("@orden", orden);

                    using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            installedDevice.Codigo = lector["Codigo_Institucion"].ToString();
                            installedDevice.Modalidad = lector["Modalidad"].ToString();
                            installedDevice.Condicion = lector["Condicion"].ToString();
                            installedDevice.Port_docente = Convert.ToInt32(lector["Port_1_docente"]);
                            installedDevice.Port_preescolar = Convert.ToInt32(lector["Port_1_preeescolar"]);
                            installedDevice.Port_1_estudiante = Convert.ToInt32(lector["Port_1_estudiante"]);
                            installedDevice.Port_2_estudiante = Convert.ToInt32(lector["Port_2_estudiante"]);
                            installedDevice.Servidor = Convert.ToInt32(lector["Servidor"]);
                            installedDevice.Nas = Convert.ToInt32(lector["Nas"]);
                            installedDevice.Proyector = Convert.ToInt32(lector["Proyector"]);
                            installedDevice.Impresora = Convert.ToInt32(lector["Impresora"]);
                            installedDevice.Audifonos = Convert.ToInt32(lector["Audifonos"]);
                            installedDevice.Mouse = Convert.ToInt32(lector["Mouse"]);
                            installedDevice.Candados = Convert.ToInt32(lector["Candados"]);
                            installedDevice.Convertidor = Convert.ToInt32(lector["ConvertirdorPolarizado"]);
                            installedDevice.Extensiones = Convert.ToInt32(lector["Extensiones"]);
                            installedDevice.Regletas = Convert.ToInt32(lector["Regletas"]);
                            installedDevice.Maletin_proyector = Convert.ToInt32(lector["Maletin_proyector"]);
                            installedDevice.Maletin_portatil = Convert.ToInt32(lector["Maletin_portatil"]);
                            installedDevice.Router = Convert.ToInt32(lector["Router"]);
                            installedDevice.Switch24 = Convert.ToInt32(lector["Switch"]);
                            installedDevice.Ap_interno = Convert.ToInt32(lector["ApInterno"]);
                            installedDevice.Ap_externo = Convert.ToInt32(lector["ApExterno"]);
                            installedDevice.Parlantes_1 = Convert.ToInt32(lector["Parlantes_1"]);
                            installedDevice.Parlantes_2 = Convert.ToInt32(lector["Parlantes_2"]);
                            installedDevice.Unidad_optica = Convert.ToInt32(lector["Unidad_optica"]);
                            installedDevice.UPS_1 = Convert.ToInt32(lector["Ups_1"]);
                            installedDevice.UPS_2 = Convert.ToInt32(lector["Ups_2"]);
                            installedDevice.Cable_hdmi = Convert.ToInt32(lector["Cable_hdmi"]);
                            installedDevice.Cable_usb = Convert.ToInt32(lector["Cable_usb"]);
                            installedDevice.Cable_vga = Convert.ToInt32(lector["Cable_vga"]);
                            installedDevice.Patch_blanco = Convert.ToInt32(lector["Patch_blanco"]);
                            installedDevice.Cartucho_tinta = Convert.ToInt32(lector["Cartucho_tinta"]);
                            installedDevice.Id_Registro = Convert.ToInt32(lector["id_registro"]);
                        }
                    }
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = installedDevice
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery SaveFinalInventoryOrder(InstalledDevice equi, string orden, string encargado, string num_pedido)
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
                    cmd.Parameters.AddWithValue("port_docente", equi.Port_docente);
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
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                _mysqlTrasaction.Rollback();
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery SaveChangeInDatabase(string placa, string serie, int accion, string estado, int estacion)
        {
            try
            {

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = _mysqlConnection;
                    cmd.CommandText = Query.MysqlProcedureSaveChangeInDatabase;
                    cmd.Parameters.AddWithValue("placa", placa);
                    cmd.Parameters.AddWithValue("serie", serie);
                    cmd.Parameters.AddWithValue("orden", accion);
                    cmd.Parameters.AddWithValue("tipo", estado);
                    cmd.Parameters.AddWithValue("estacion", estacion);
                    cmd.Parameters.AddWithValue("fecha", VariablesName.ActualDate);
                    cmd.Connection = _mysqlConnection;
                    cmd.ExecuteNonQuery();

                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery DeleteDevice(string placa, string serie, int workAction, int NumberEstation)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlDeleteDevice;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("@placa", placa);
                    cmd.Parameters.AddWithValue("@workAction", workAction);
                    cmd.ExecuteNonQuery();
                }
                SaveChangeInDatabase(placa, serie, workAction, "ELIMINADO", NumberEstation);
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery GetListMaterials()
        {
            try
            {
                List<string> materials = new List<string>();
                using (var _mysqlCommand = new MySqlCommand(Query.MysqlGetListMaterials, _mysqlConnection))
                {
                    using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            materials.Add(lector["descripcion"].ToString());
                        }
                    }

                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = materials
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery GetCodeTechnicals()
        {
            try
            {
                int valor_codigo = 0;
                using (var _mysqlCommand = new MySqlCommand(Query.MysqlGetCodeTechnicals, _mysqlConnection))
                {
                    using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            valor_codigo = Convert.ToInt32(lector["codigo_tecnico"].ToString());
                        }
                    }

                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = (valor_codigo + 1)
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery SaveTechnical(string nameTechnical)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlSaveTechnical;
                    cmd.Parameters.AddWithValue("@codigo", 01);
                    cmd.Parameters.AddWithValue("@nameTechnical", nameTechnical);
                    cmd.Connection = _mysqlConnection;
                    cmd.ExecuteNonQuery();

                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }


        public ResponseQuery SaveUnitCostMaterials(UnitCostMaterial unitCost)
        {
            try
            {
                _mysqlTrasaction = _mysqlConnection.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = _mysqlConnection;
                    cmd.CommandText = Query.MysqlProcedureSaveUnitCostMaterials;
                    cmd.Parameters.AddWithValue("num_fac", unitCost.IdInvoice);
                    cmd.Parameters.AddWithValue("detalle", unitCost.Detail);
                    cmd.Parameters.AddWithValue("valor", unitCost.Cost);
                    cmd.Parameters.AddWithValue("codigo_equipo", unitCost.CodeDevice);
                    cmd.Parameters.AddWithValue("tipo", unitCost.TypeDevice);
                    cmd.Connection = _mysqlConnection;
                    cmd.ExecuteNonQuery();

                }
                _mysqlTrasaction.Commit();
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                _mysqlTrasaction?.Rollback();
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery GetAllNameDamage()
        {
            try
            {
                List<string> danos = new List<string>();
                using (var _mysqlCommand = new MySqlCommand(Query.MysqlGetAllNameDamage, _mysqlConnection))
                {
                    using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            danos.Add(lector["dano"].ToString());
                        }
                    }

                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = danos
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }


        public ResponseQuery SaveNewDamage(string placa, string serie, string dano, string estado)
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
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                _mysqlTrasaction?.Rollback();
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery GetRolSystemFromIdUser(User user)
        {
            try
            {
                string rol = string.Empty;

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlGetRolSystemFromIdUser;
                    cmd.Parameters.AddWithValue("@user", user.UserName);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Connection = _mysqlConnection;
                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            rol = lector["rol_user"].ToString();
                        }
                    }

                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = rol
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }


        }


        public ResponseQuery GetDescriptionOutputOrderFromIdOrder(int idOrder)
        {
            string descripcion = string.Empty;
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
                            descripcion = lector["descripcion"].ToString();
                        }
                    }
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = descripcion
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery GetDescriptionWorkActionFromId(int idOrder)
        {

            try
            {
                string descripcion = string.Empty;
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlGetDescriptionWorkActionFromId;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("@idOrder", idOrder);
                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            descripcion = lector["Descripcion"].ToString();
                        }
                    }
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = descripcion
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery GetRoles()
        {
            try
            {
                List<string> roles = new List<string>();
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
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = roles
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }
        public ResponseQuery SaveUserSystem(User user)
        {
            try
            {

                _mysqlTrasaction = _mysqlConnection.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlSaveUserSystem;
                    cmd.Connection = _mysqlConnection;
                    cmd.Parameters.AddWithValue("@user", user.UserName);
                    cmd.Parameters.AddWithValue("@pass", user.Password);
                    cmd.Parameters.AddWithValue("@rol", user.Rol);

                    cmd.ExecuteNonQuery();

                }
                _mysqlTrasaction.Commit();
                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                _mysqlTrasaction?.Rollback();
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }

        public ResponseQuery GetAllInformationInInstitutionFromCode(string code)
        {
            try
            {
                Installation installation = new Installation();
                using (var _mysqlCommand = new MySqlCommand())
                {
                    _mysqlCommand.Connection = _mysqlConnection;
                    _mysqlCommand.CommandText = Query.MysqlGetAllInformationInInstitutionFromCode;
                    _mysqlCommand.Parameters.AddWithValue("@code", code);
                    using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                    {

                        if (lector.Read())
                        {
                            installation.Codigo_pre = lector["codigo_institucion"].ToString();
                            installation.Cantidad_aps = Convert.ToInt32(lector["cantidad_instalada"].ToString());
                            installation.Descripcion = lector["descripcion"].ToString();
                            installation.Fecha = lector["fecha_registro"].ToString();
                            installation.Documento = lector["documento"].ToString();
                        }
                    }


                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = installation
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery GetPendingOrder()
        {
            try
            {
                string num_accion = string.Empty;
                using (var _mysqlCommand = new MySqlCommand(Query.MysqlGetPendingOrder, _mysqlConnection))
                {
                    using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            num_accion = lector["Total"].ToString();
                        }
                    }

                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = num_accion
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery RegisterNewCartel(string code, string description, string date)
        {
            try
            {
                _mysqlTrasaction = _mysqlConnection.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query.MysqlRegisterNewCartel;
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Connection = _mysqlConnection;
                    cmd.ExecuteNonQuery();

                }
                _mysqlTrasaction.Commit();

                return new ResponseQuery
                {
                    StatusQuery = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }
        public ResponseQuery GetInformationLocation()
        {
            try
            {
                List<string> InventoryLocations = new List<string>();
                var _mysqlCommand = new MySqlCommand(Query.MysqlGetInformationLocation, _mysqlConnection);
                using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        InventoryLocations.Add(lector["Nombre"].ToString());

                    }
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = InventoryLocations
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }

        public ResponseQuery GetInformationTotalLocation()
        {
            try
            {
                _totalLocations.Clear();
                var _mysqlCommand = new MySqlCommand(Query.MysqlGetInformationLocation, _mysqlConnection);
                using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        _totalLocations.Add(lector["Nombre"].ToString(), lector.GetInt32("Codigo"));

                    }
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = _totalLocations
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }
        public ResponseQuery GetAllLotes()
        {
            try
            {
                Carteles.Clear();
                var _mysqlCommand = new MySqlCommand(Query.MysqlGetAllLotes, _mysqlConnection);
                using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Carteles.Add(lector["id_cartel"].ToString());

                    }
                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = Carteles
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }
        }
        public ResponseQuery GetTecnicals()
        {
            try
            {

                List<string> tecnicos = new List<string>();
                using (var _mysqlCommand = new MySqlCommand(Query.MysqlGetTecnicals, _mysqlConnection))
                {
                    using (MySqlDataReader lector = _mysqlCommand.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            tecnicos.Add(lector["nombre"].ToString());
                        }
                    }

                }
                return new ResponseQuery
                {
                    StatusQuery = true,
                    Result = tecnicos
                };
            }
            catch (Exception ex)
            {
                return new ResponseQuery { StatusQuery = false, MessageQuery = new List<string>() { ex.Message } };
            }

        }
    }
}
