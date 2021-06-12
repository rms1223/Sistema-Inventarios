using InventarioFod.Clases.Entidades;
using InventarioFod.Clases.Manejo_De_Datos;
using InventarioFod.Reportes;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace InventarioFod.Clases
{
    //Nomenclatura:
    //Db= utilizado para referirise a la base de datos mysql
    //excel= utilizado para el manejo de los archivos de excel
    class Manejo_Documento_Excel
    {
        private DataGridView datos_datagridview;
        private DataGridView datos_eliminados;
        private DataGridView datos_agregados;

        private Conexion_db_Mysql base_datos;

        private Manejo_Datos_Reportes Datos_Reporte;
        public int Contador { get; set; }
        public int Num_maquina { get; set; }


        //private DataTable dt;

        public Manejo_Documento_Excel(DataGridView datos_usuario)
        {
            datos_datagridview = datos_usuario;
            base_datos = Conexion_db_Mysql.Get_Instance;

        }

        public void Data_cambios(DataGridView data_eliminada, DataGridView data_agregada)
        {
            datos_eliminados = data_eliminada;
            datos_agregados = data_agregada;
        }
        public Manejo_Documento_Excel()
        {
            base_datos = Conexion_db_Mysql.Get_Instance;
        }

        public void Buscar_pedido_orden()
        {
            datos_datagridview.DataSource = base_datos.Get_Total_regitros_pedidos();
        }


        public void Obtener_equipo_acciones(string comando, string accion)
        {
            datos_datagridview.Columns.Clear();
            if (accion.Equals(Var_Name.Acciones))
            {
                if (!string.IsNullOrEmpty(comando))
                {
                    int valor = Convert.ToInt32(comando);
                    datos_datagridview.DataSource = base_datos.Obtener_Acciones(valor);
                }

            }
            else
            {
                datos_datagridview.DataSource = base_datos.Obtener_Acciones(comando, accion);
            }

        }

        public void Obtener_cambios(int orden)
        {
            try
            {
                datos_agregados.Columns.Clear();
                datos_eliminados.Columns.Clear();
                datos_agregados.DataSource = base_datos.Obtener_Cambios_Ordenes(orden, "AGREGADO");
                datos_eliminados.DataSource = base_datos.Obtener_Cambios_Ordenes(orden,"ELIMINADO");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al procesar los datos", "Opciones de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }
        //Metodo para cargar los cambios realizados


        //Metodo Utilizado para Buscar Codigo de la institucion
        //DENTRO DEL DATAGRIDVIEW
        public void Buscar_codigo(string codigo, string tipo_listado)
        {
            string nombre;
            if (tipo_listado.Equals("Consulta_listado"))
            {
                nombre = "Codigo";
            }
            else
            {
                nombre = Var_Name.Codigo_Institucion;
            }
            bool estado = false;
            datos_datagridview.AllowUserToAddRows = false;
            foreach (DataGridViewRow item in datos_datagridview.Rows)
            {
                if (item.Cells[nombre].Value.Equals(codigo))
                {
                    datos_datagridview.Rows[item.Index].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                    datos_datagridview.FirstDisplayedScrollingRowIndex = item.Index;
                    estado = true;
                    break;
                }
            }
            datos_datagridview.AllowUserToAddRows = true;
            if (!estado)
            {
                MessageBox.Show("No existe el codigo " + codigo, "Opciones de listas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //agregadas recientemente randy
        public bool Inventario_Equipos_Reequipamiento(int cod_mod,string serie,string placa, string query)
        {
            return base_datos.Insertar_Registros_Reequipamiento(cod_mod,serie,placa,query);
        }

        public void Insertar_Institucion(Institucion institucion)
        {
            base_datos.Guardar_Institucion(institucion);
        }


        //Metodo para cargar acciones mediante copia de datos con control+v
        public void Cargar_datos_accion()
        {
            if (datos_datagridview.RowCount != 0)
            {
                datos_datagridview.DataSource = null;
            }
            datos_datagridview.ColumnCount = 3;
            datos_datagridview.Columns[0].Name = Var_Name.Placa;
            datos_datagridview.Columns[1].Name = Var_Name.Serie;
            datos_datagridview.Columns[2].Name = Var_Name.Descripcion;
            string text = Clipboard.GetText();
            if (!string.IsNullOrEmpty(text))
            {
                string[] lines = text.Replace("\n", "").Split('\r');
                datos_datagridview.Rows.Add(lines.Length - 1);
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
                            datos_datagridview[col, row].Value = item2;
                            col++;
                        }

                    }
                    row++;
                    col = 0;
                }
            }
        }

        public void Cargar_Estados_Acciones()
        {
            datos_datagridview.DataSource = base_datos.Obtener_Estados_Acciones(0,Var_Name.ORDEN_SALIDA);
        }
        public void Aplicar_Acciones(int accion, string estado)
        {
            base_datos.Aplicar_Acciones_Db(accion, estado);
        }

        public List<string> Obtener_Ubicaciones()
        {
            return base_datos.Ubicaciones_Inventario;
        }
        public void Aplicar_Estado_Lista(int lista, string estado_lista)
        {
            base_datos.Aplicar_Estado_Listado(lista, estado_lista);
        }
        public void Obtener_Estado_Acciones(int accion)
        {
            datos_datagridview.DataSource = base_datos.Obtener_Estados_Acciones(accion,Var_Name.ORDEN_SALIDA);
        }
        public bool Inventario_Equipos(Equipos_Reequipamiento equi_requi, string query)
        {
            return base_datos.Insertar_Registros_Inventarios(equi_requi, query);
        }
        public int Get_Row_Count
        {
            get
            {
                return datos_datagridview.Rows.Count;
            }
        }


        ///Utilizado para cargar los datos de la creacion de ordenes de Trabajo
        ///
        public void Cargar_orden_trabajo()//metodo para cargar los datos necesarios para la orden de trabajo en el datagridview
        {
            datos_datagridview.ColumnCount = 8;
            datos_datagridview.Columns[0].Name = "Placa";
            datos_datagridview.Columns[1].Name = "Serie";
            datos_datagridview.Columns[2].Name = "Marca";
            datos_datagridview.Columns[3].Name = "Modelo";
            datos_datagridview.Columns[4].Name = "Tipo_equipo";
            datos_datagridview.Columns[5].Name = "Institucion";
            datos_datagridview.Columns[6].Name = "Modalidad";
            datos_datagridview.Columns[7].Name = "Estacion";
            Contador = 1;
            Num_maquina = 0;
        }

        public void Procesar_datos_orden(string valor, string tipo_buscar, string institucion, string modalidad, int num_maquina)
        {
            Equipos equi = base_datos.procesar_datos_equipos(valor, tipo_buscar);
            if (equi.Placa != null)
            {
                if (Verificar_datos(valor, tipo_buscar))
                {
                    Validar_registroDatos(equi, institucion, modalidad, num_maquina);
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
            datos_datagridview.FirstDisplayedScrollingRowIndex = datos_datagridview.RowCount - 1;

        }
        private bool Verificar_datos(string valor, string tipo_buscar)
        {

            bool estado = true;
            if (datos_datagridview.Rows.Count != 1)
            {
                datos_datagridview.AllowUserToAddRows = false;
                foreach (DataGridViewRow item in datos_datagridview.Rows)
                {

                    if (item.Cells[tipo_buscar].Value.ToString().Equals(valor))
                    {
                        estado = false;
                    }
                }   
                datos_datagridview.AllowUserToAddRows = true;
            }
            return estado;
        }
        private void Validar_registroDatos(Equipos equi,string institucion,string modalidad, int num_maquina)
        {
            if (equi.Tipo_equipo.Equals("PORTATIL"))
            {
                Contador++;
                datos_datagridview.Rows.Add(equi.Placa, equi.Serie, equi.Marca, equi.Modelo, equi.Tipo_equipo, institucion,modalidad, num_maquina);
                num_maquina = Contador;
            }
            else
            {
                datos_datagridview.Rows.Add(equi.Placa, equi.Serie, equi.Marca, equi.Modelo, equi.Tipo_equipo, institucion, equi.Tipo_equipo, 000);
            }
        }
        public void Guardar_datos_orden(string orden_trabajo,string institucion,string tipo_orden, bool cambio)
        {
            datos_datagridview.AllowUserToAddRows = false;
            try
            {
                
                base_datos.Verificar_Conexion();
                bool estado_ope = true;
                base_datos.Crear_Accion(Convert.ToInt32(orden_trabajo), institucion, tipo_orden);
                Equipos_Reequipamiento equi_requi = new Equipos_Reequipamiento();
                foreach (DataGridViewRow item in datos_datagridview.Rows)
                {

                    if (!string.IsNullOrEmpty(item.Cells[Var_Name.Serie].Value.ToString()))
                    {
                        equi_requi.Accion = Convert.ToInt32(orden_trabajo);
                        string serie = item.Cells[Var_Name.Serie].Value.ToString();
                        if (serie.StartsWith("MP1") && serie.Length > 8)
                        {
                            equi_requi.Serie = serie.Substring(0, 8);
                        }
                        else
                        {
                            equi_requi.Serie = serie;
                        }

                        equi_requi.Placa = item.Cells[Var_Name.Placa].Value.ToString();
                        equi_requi.Institucion = item.Cells[Var_Name.Institucion].Value.ToString();
                        equi_requi.Modalidad = item.Cells["Modalidad"].Value.ToString();
                        equi_requi.Numero_Maquina = Convert.ToInt32(item.Cells["Estacion"].Value.ToString());
                        equi_requi.Tipo_Equipo = item.Cells["Tipo_equipo"].Value.ToString();
                        estado_ope = Inventario_Equipos(equi_requi, Query.Insert);
                        if (cambio)
                        {
                            base_datos.Insertar_Cambios(equi_requi.Placa, equi_requi.Serie, equi_requi.Accion, "AGREGADO", equi_requi.Numero_Maquina);
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
            datos_datagridview.AllowUserToAddRows = true;
        }




        public void Cargar_orden_equipoNuevo()
        {
            datos_datagridview.ColumnCount = 5;
            datos_datagridview.Columns[0].Name = "Codigo Modelo";
            datos_datagridview.Columns[1].Name = "Placa";
            datos_datagridview.Columns[2].Name = "Serie";
            datos_datagridview.Columns[3].Name = "Tipo";
            datos_datagridview.Columns[4].Name = "Cartel";
        }

        public void Procesar_ingreso_equipoNuevo(string tipo,string placa, string serie,string nombre_tipo,string lote)
        {
            if (Verificar_datos(placa, Var_Name.Placa) && Verificar_datos(serie, Var_Name.Serie))
            {
                datos_datagridview.Rows.Add(tipo, placa, serie, nombre_tipo, lote);
            }
            else
            {
                MessageBox.Show("Equipo ya fue ingresado", "Registro de Equipos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Guardar_ingreso_equipoNuevo(string orden_trabajo,string descripcionorden,string nombre_tipo,string tipo_orden)
        {
            try
            {
                
                bool estado_ope = true;
                Equipos_Reequipamiento equi_requi = new Equipos_Reequipamiento();
                datos_datagridview.AllowUserToAddRows = false;
                foreach (DataGridViewRow item in datos_datagridview.Rows)
                {

                    if (!string.IsNullOrEmpty(item.Cells[Var_Name.Serie].Value.ToString()))
                    {
                        string Serie = item.Cells[Var_Name.Serie].Value.ToString();
                        string Placa = item.Cells[Var_Name.Placa].Value.ToString();
                        int Tipo_Equipo = Convert.ToInt32(item.Cells["Codigo Modelo"].Value.ToString());

                        string idCartel = item.Cells["Cartel"].Value.ToString();
                        estado_ope = base_datos.Ingresar_Equipo_Nuevo(Tipo_Equipo, Placa, Serie.ToUpper(), idCartel);
                        base_datos.Crear_Accion(Convert.ToInt32(orden_trabajo), descripcionorden, tipo_orden);

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
                        estado_ope = Inventario_Equipos(equi_requi, Query.Insert);

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
                datos_datagridview.AllowUserToAddRows = true;
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar los datos","Error de Ingreso",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void Limpiar_datos()
        {
            datos_datagridview.Rows.Clear();
            datos_datagridview.Refresh();
        }


        //Generar reporte y enviar por email
        public string SelectPedidoByOrden(string orden_txt,string tipo_pedido)
        {
            try
            {
                string path = string.Empty;
                Pedidos report = new Pedidos();
                try
                {
                    Datos_Reporte = new Manejo_Datos_Reportes
                    {
                        Reporte = report.GetReport(),
                        Nombre_Table_DataSource = "pedidos_db",
                        Report_Embed_Resourse = "InventarioFod.pedidos_email.rdlc",
                        Get_Parameters = new ReportParameter[]
                    {
                        new ReportParameter("fecha", DateTime.Now.ToString("dd/MM/yyyy")),
                        new ReportParameter("institucion",base_datos.Get_Descripcion_Orden_Trabajo(Convert.ToInt32(orden_txt)))
                    }
                    };
                    Datos_Reporte.Generar_Reporte_Pedidos(Convert.ToInt32(orden_txt), tipo_pedido);
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
        public string SelectOrdenTrabajo(string orden_txt)
        {
            try
            {
                string path = string.Empty;
                salida_materiales report = new salida_materiales();
                try
                {
                    int accion_num = Convert.ToInt32(orden_txt);
                    Datos_Reporte = new Manejo_Datos_Reportes
                    {
                        Reporte = report.GetReport(),
                        Nombre_Table_DataSource = "inventario_acciones",
                        Nombre_Table_DataSource_opcional = "materiales",
                        Report_Embed_Resourse = "InventarioFod.reporteacciones.rdlc",
                        Get_Parameters = new ReportParameter[]
                        {
                            new ReportParameter("accion",accion_num.ToString("D7")),
                            new ReportParameter("fecha",DateTime.Now.ToString("dd/MM/yyyy")),

                        }
                    };
                    if (!String.IsNullOrEmpty(orden_txt))
                    {
                        Datos_Reporte.Generar_Reporte_Acciones(Convert.ToInt32(orden_txt));
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

