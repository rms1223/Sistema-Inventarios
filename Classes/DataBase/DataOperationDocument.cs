using SystemIventory.Classes.Entities;
using SystemIventory.Classes.DataBase;
using SystemIventory.Reports;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SystemInventory.Classes.IModels;
using SystemInventory.Classes.Models;

namespace SystemIventory.Classes
{
    class DataOperationDocument
    {
        private DataGridView _dataDatagridview;
        private DataGridView _dataDatgridViewDelete;
        private DataGridView _dataDatagridviewAdd;

        private OperationsRepository _mysqlConnectionDatabase;
        private IDataBaseRepository _dataBaseRepository;
        private IDataTableModel dataTableModel;

        private DataReports _dataReports;
        public int Count { get; set; }
        public int IdDevice { get; set; }


        public DataOperationDocument(DataGridView _mainDatgridviewUser)
        {
            _dataDatagridview = _mainDatgridviewUser;
            _dataBaseRepository = DataBaseRepository.Get_Instance;
            _mysqlConnectionDatabase = OperationsRepository.Get_Instance;
            dataTableModel = DataTableModel.Get_Instance;

        }

        public int GetRowCount
        {
            get
            {
                return _dataDatagridview.Rows.Count;
            }
        }
        public void DataChanges(DataGridView data_eliminada, DataGridView data_agregada)
        {
            _dataDatgridViewDelete = data_eliminada;
            _dataDatagridviewAdd = data_agregada;
        }
        public DataOperationDocument()
        {
            _dataBaseRepository = DataBaseRepository.Get_Instance;
            _mysqlConnectionDatabase = OperationsRepository.Get_Instance;
            dataTableModel = DataTableModel.Get_Instance;
        }

        public void SearchIdOrder()
        {
            _dataDatagridview.DataSource = dataTableModel.GetTotalRecordOrders();
        }


        public void GetIdDeviceInWorkAction(string comando, string accion)
        {
            _dataDatagridview.Columns.Clear();
            if (accion.Equals(VariablesName.NameWokActions))
            {
                if (!string.IsNullOrEmpty(comando))
                {
                    int valor = Convert.ToInt32(comando);
                    _dataDatagridview.DataSource = dataTableModel.GetAllWorkAction(valor).Result;
                }

            }
            else
            {
                _dataDatagridview.DataSource = dataTableModel.GetWorkActionFromId(comando, accion).Result;
            }

        }

        public void GetChanges(int orden)
        {
            try
            {
                _dataDatagridviewAdd.Columns.Clear();
                _dataDatgridViewDelete.Columns.Clear();
                _dataDatagridviewAdd.DataSource = dataTableModel.GetChangesWorkAction(orden, "AGREGADO");
                _dataDatgridViewDelete.DataSource = dataTableModel.GetChangesWorkAction(orden,"ELIMINADO");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al procesar los datos", "Opciones de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }

        public void SearchCodeInDatagridView(string codigo, string tipo_listado)
        {
            string nombre;
            if (tipo_listado.Equals("Consulta_listado"))
            {
                nombre = "Codigo";
            }
            else
            {
                nombre = VariablesName.CodigoInstitucion;
            }
            bool estado = false;
            _dataDatagridview.AllowUserToAddRows = false;
            foreach (DataGridViewRow item in _dataDatagridview.Rows)
            {
                if (item.Cells[nombre].Value.Equals(codigo))
                {
                    _dataDatagridview.Rows[item.Index].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                    _dataDatagridview.FirstDisplayedScrollingRowIndex = item.Index;
                    estado = true;
                    break;
                }
            }
            _dataDatagridview.AllowUserToAddRows = true;
            if (!estado)
            {
                MessageBox.Show("No existe el codigo " + codigo, "Opciones de listas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool SaveInventoryDevicesInDatabase(int cod_mod,string serie,string placa, string query)
        {
            return _dataBaseRepository.SaveRegisterReequipamiento(cod_mod,serie,placa,query).StatusQuery;
        }

        public void SaveInstitutionInDatabase(Institution institucion)
        {
            _dataBaseRepository.SaveInstitution(institucion);
        }


        public void CopyDataInDatagridview()
        {
            if (_dataDatagridview.RowCount != 0)
            {
                _dataDatagridview.DataSource = null;
            }
            _dataDatagridview.ColumnCount = 3;
            _dataDatagridview.Columns[0].Name = VariablesName.Placa;
            _dataDatagridview.Columns[1].Name = VariablesName.Serial;
            _dataDatagridview.Columns[2].Name = VariablesName.Descripcion;
            string text = Clipboard.GetText();
            if (!string.IsNullOrEmpty(text))
            {
                string[] lines = text.Replace("\n", "").Split('\r');
                _dataDatagridview.Rows.Add(lines.Length - 1);
                string[] campos;
                int row = 0;
                int col = 0;

                foreach (var item in lines)
                {
                    campos = item.Split('\t');
                    foreach (var item2 in campos)
                    {
                        if (!string.IsNullOrEmpty(item2))
                        {
                            _dataDatagridview[col, row].Value = item2;
                            col++;
                        }

                    }
                    row++;
                    col = 0;
                }
            }
        }

        public void LoadInfromationWorkAction()
        {
            _dataDatagridview.DataSource = dataTableModel.GetInfromationWokActionFromType(0,VariablesName.OutputOrder);
        }
        public void ApplyWorkActionInDatabase(int accion, string estado)
        {
            _dataBaseRepository.ApplyWorkAction(accion, estado);
        }

        public List<string> GetAllLocationsInDatabase()
        {
            return _mysqlConnectionDatabase.InventoryLocations;
        }
        public void UpdateStatusWorkActionInDatabase(int lista, string estado_lista)
        {
            _dataBaseRepository.UpdateStatusList(lista, estado_lista);
        }
        public void GetStatusWorkActionFromDatabase(int accion)
        {
            _dataDatagridview.DataSource = dataTableModel.GetInfromationWokActionFromType(accion,VariablesName.OutputOrder);
        }
        public bool SaveInventoryRecordsInDatabase(Equipos_Reequipamiento equi_requi, string query)
        {
            return _dataBaseRepository.SaveInventoryRecord(equi_requi, query).StatusQuery;
        }
        
        public void LoadWorkActionInfromationInDatagridview()
        {
            _dataDatagridview.ColumnCount = 8;
            _dataDatagridview.Columns[0].Name = "Placa";
            _dataDatagridview.Columns[1].Name = "Serie";
            _dataDatagridview.Columns[2].Name = "Marca";
            _dataDatagridview.Columns[3].Name = "Modelo";
            _dataDatagridview.Columns[4].Name = "Tipo_equipo";
            _dataDatagridview.Columns[5].Name = "Institucion";
            _dataDatagridview.Columns[6].Name = "Modalidad";
            _dataDatagridview.Columns[7].Name = "Estacion";
            Count = 1;
            IdDevice = 0;
        }

        public void ProcessLocalWorkAction(string valor, string tipo_buscar, string institucion, string modalidad, int num_maquina)
        {
            Device equi = (Device)_dataBaseRepository.SearchDeviceFromId(valor, tipo_buscar).Result;
            if (equi.Placa != null)
            {
                if (VerifyDataInDatagridview(valor, tipo_buscar))
                {
                    ValidateRecords(equi, institucion, modalidad, num_maquina);
                }
                else
                {
                    MessageBox.Show("Equipo ya fue asignado", "Orden de Trabajo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No existe la placa o Serie: " + valor, "Error al Buscar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _dataDatagridview.FirstDisplayedScrollingRowIndex = _dataDatagridview.RowCount - 1;

        }
        private bool VerifyDataInDatagridview(string valor, string tipo_buscar)
        {

            bool estado = true;
            if (_dataDatagridview.Rows.Count != 1)
            {
                _dataDatagridview.AllowUserToAddRows = false;
                foreach (DataGridViewRow item in _dataDatagridview.Rows)
                {

                    if (item.Cells[tipo_buscar].Value.ToString().Equals(valor))
                    {
                        estado = false;
                    }
                }   
                _dataDatagridview.AllowUserToAddRows = true;
            }
            return estado;
        }
        private void ValidateRecords(Device equi,string institucion,string modalidad, int num_maquina)
        {
            if (equi.Tipo_equipo.Equals("PORTATIL"))
            {
                Count++;
                _dataDatagridview.Rows.Add(equi.Placa, equi.Serie, equi.Marca, equi.Modelo, equi.Tipo_equipo, institucion,modalidad, num_maquina);
                num_maquina = Count;
            }
            else
            {
                _dataDatagridview.Rows.Add(equi.Placa, equi.Serie, equi.Marca, equi.Modelo, equi.Tipo_equipo, institucion, equi.Tipo_equipo, 000);
            }
        }
        public void SaveWorkActionInDatabase(string orden_trabajo,string institucion,string tipo_orden, bool cambio)
        {
            _dataDatagridview.AllowUserToAddRows = false;
            try
            {
                
                _mysqlConnectionDatabase.VerifyDatabaseConnection();
                bool estado_ope = true;
                _dataBaseRepository.SaveNewWorkAction(Convert.ToInt32(orden_trabajo), institucion, tipo_orden);
                Equipos_Reequipamiento equi_requi = new Equipos_Reequipamiento();
                foreach (DataGridViewRow item in _dataDatagridview.Rows)
                {

                    if (!string.IsNullOrEmpty(item.Cells[VariablesName.Serial].Value.ToString()))
                    {
                        equi_requi.Accion = Convert.ToInt32(orden_trabajo);
                        string serie = item.Cells[VariablesName.Serial].Value.ToString();
                        if (serie.StartsWith("MP1") && serie.Length > 8)
                        {
                            equi_requi.Serie = serie.Substring(0, 8);
                        }
                        else
                        {
                            equi_requi.Serie = serie;
                        }

                        equi_requi.Placa = item.Cells[VariablesName.Placa].Value.ToString();
                        equi_requi.Institucion = item.Cells[VariablesName.Institucion].Value.ToString();
                        equi_requi.Modalidad = item.Cells["Modalidad"].Value.ToString();
                        equi_requi.Numero_Maquina = Convert.ToInt32(item.Cells["Estacion"].Value.ToString());
                        equi_requi.Tipo_Equipo = item.Cells["Tipo_equipo"].Value.ToString();
                        estado_ope = SaveInventoryRecordsInDatabase(equi_requi, Query.Insert);
                        if (cambio)
                        {
                            _dataBaseRepository.SaveChangeInDatabase(equi_requi.Placa, equi_requi.Serie, equi_requi.Accion, "AGREGADO", equi_requi.Numero_Maquina);
                        }
                        if (!estado_ope)
                        {
                            break;
                        }
                    }
                }
                if (estado_ope)
                {
                    MessageBox.Show("Datos Guardados", "Opciones Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception)
            {

                throw;
            }
            _dataDatagridview.AllowUserToAddRows = true;
        }

        public void LoadDataNewDeviceInDatagridview()
        {
            _dataDatagridview.ColumnCount = 5;
            _dataDatagridview.Columns[0].Name = "Codigo Modelo";
            _dataDatagridview.Columns[1].Name = "Placa";
            _dataDatagridview.Columns[2].Name = "Serie";
            _dataDatagridview.Columns[3].Name = "Tipo";
            _dataDatagridview.Columns[4].Name = "Cartel";
        }

        public void AddNewRecordInDatagridview(string tipo,string placa, string serie,string nombre_tipo,string lote)
        {
            if (VerifyDataInDatagridview(placa, VariablesName.Placa) && VerifyDataInDatagridview(serie, VariablesName.Serial))
            {
                _dataDatagridview.Rows.Add(tipo, placa, serie, nombre_tipo, lote);
            }
            else
            {
                MessageBox.Show("Equipo ya fue ingresado", "Registro de Equipos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void SaveNewRecordInDatabase(string orden_trabajo,string descripcionorden,string nombre_tipo,string tipo_orden)
        {
            try
            {
                
                bool estado_ope = true;
                Equipos_Reequipamiento equi_requi = new Equipos_Reequipamiento();
                _dataDatagridview.AllowUserToAddRows = false;
                foreach (DataGridViewRow item in _dataDatagridview.Rows)
                {

                    if (!string.IsNullOrEmpty(item.Cells[VariablesName.Serial].Value.ToString()))
                    {
                        string Serie = item.Cells[VariablesName.Serial].Value.ToString();
                        string Placa = item.Cells[VariablesName.Placa].Value.ToString();
                        int Tipo_Equipo = Convert.ToInt32(item.Cells["Codigo Modelo"].Value.ToString());

                        string idCartel = item.Cells["Cartel"].Value.ToString();
                        estado_ope = _dataBaseRepository.SaveNewDevice(Tipo_Equipo, Placa, Serie.ToUpper(), idCartel).StatusQuery;
                        _dataBaseRepository.SaveNewWorkAction(Convert.ToInt32(orden_trabajo), descripcionorden, tipo_orden);

                        equi_requi.Accion = Convert.ToInt32(orden_trabajo);
                        if (Serie.StartsWith("MP1") && Serie.Length > 8)
                        {
                            equi_requi.Serie = Serie.Substring(0, 8).ToUpper();
                        }
                        else
                        {
                            equi_requi.Serie = Serie.ToUpper();
                        }

                        equi_requi.Placa = Placa;
                        equi_requi.Institucion = "INGRESO EQUIPOS NUEVOS";
                        equi_requi.Modalidad = "N/A";
                        equi_requi.Numero_Maquina = 0;
                        equi_requi.Tipo_Equipo = nombre_tipo;
                        estado_ope = SaveInventoryRecordsInDatabase(equi_requi, Query.Insert);

                        if (!estado_ope)
                        {
                            break;
                        }
                    }
                }
                if (estado_ope)
                {
                    MessageBox.Show("Datos Guardados", "Ingreso Equipos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                _dataDatagridview.AllowUserToAddRows = true;
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar los datos","Error de Ingreso",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void ClearData()
        {
            _dataDatagridview.Rows.Clear();
            _dataDatagridview.Refresh();
        }


        public string SelectOrderByType(string orden_txt,string tipo_pedido)
        {
            try
            {
                string path = string.Empty;
                OrdersReport report = new OrdersReport();
                try
                {
                    _dataReports = new DataReports
                    {
                        Reporte = report.GetReport(),
                        NameTableDataSource = "pedidos_db",
                        ReportEmbedResourse = "InventarioFod.pedidos_email.rdlc",
                        GetParameters = new ReportParameter[]
                    {
                        new ReportParameter("fecha", DateTime.Now.ToString("dd/MM/yyyy")),
                        new ReportParameter("institucion",(string)_dataBaseRepository.GetDescriptionWorkActionFromId(Convert.ToInt32(orden_txt)).Result)
                    }
                    };
                    _dataReports.GetDataOrderReport(Convert.ToInt32(orden_txt), tipo_pedido);
                    byte[] byteViewExcel = report.GetReport().LocalReport.Render("EXCELOPENXML");
                    path = Path.Combine(Application.StartupPath, $"Documentos\\Pedido_Materiales_Listo_{orden_txt}.xlsx");
                    FileStream file = new FileStream(path, FileMode.Create);
                    file.Write(byteViewExcel, 0, byteViewExcel.Length);
                    file.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al procesar" + ex);
                }
                return path;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public string SelectWorkAction(string orden_txt)
        {
            try
            {
                string path = string.Empty;
                salida_materiales report = new salida_materiales();
                try
                {
                    int accion_num = Convert.ToInt32(orden_txt);
                    _dataReports = new DataReports
                    {
                        Reporte = report.GetReport(),
                        NameTableDataSource = "inventario_acciones",
                        NameTableDataSourceOpcional = "materiales",
                        ReportEmbedResourse = "InventarioFod.reporteacciones.rdlc",
                        GetParameters = new ReportParameter[]
                        {
                            new ReportParameter("accion",accion_num.ToString("D7")),
                            new ReportParameter("fecha",DateTime.Now.ToString("dd/MM/yyyy")),

                        }
                    };
                    if (!String.IsNullOrEmpty(orden_txt))
                    {
                        _dataReports.GetDataWorkActionReport(Convert.ToInt32(orden_txt));
                    }
                    byte[] byteViewExcel = report.GetReport().LocalReport.Render("EXCELOPENXML");
                    path = Path.Combine(Application.StartupPath, $"Documentos\\Orden_{orden_txt}_Equipos_Enviados.xlsx");
                    FileStream file = new FileStream(path, FileMode.Create);
                    file.Write(byteViewExcel, 0, byteViewExcel.Length);
                    file.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al procesar" + ex);
                }
                return path;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

