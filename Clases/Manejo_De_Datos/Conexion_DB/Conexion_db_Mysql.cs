using InventarioFod.Clases.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace InventarioFod.Clases
{
    class Conexion_db_Mysql
    {

        //Parametros de conexion para 
        private MySqlConnection conn = null;
        private string servidor = Var_Name.server;
        private string usuario = Var_Name.user;
        private string pass = Var_Name.pass;
        private string db = Var_Name.name_database;
        //Manejo de transacciones MYSQL
        MySqlTransaction trans;
        private Dictionary<string, string> totales;
        private MySqlCommand comando;
        //private MySqlDataReader lector;
        private MySqlDataAdapter adaptador;
        private static Conexion_db_Mysql base_datos = null;

        //Metodos para almacenar los valores con ccodigo y valor de la base de datos
        private Dictionary<string, int> total_tecnico = new Dictionary<string, int>();
        private Dictionary<string, int> total_ubicaciones = new Dictionary<string, int>();
        public List<string> Ubicaciones_Inventario { get; } = new List<string>();
        public List<string> carteles { get; } = new List<string>();
        public bool Estado_Tecnicos { get; set; }
        public string estado_con = "DISPONIBLE";
        public string mensaje_conexion = string.Empty;

        DataSet _source_acciones;
        private Conexion_db_Mysql()
        {
            totales = new Dictionary<string, string>();
            Establecer_Conexion();
            comando = new MySqlCommand();
            comando.Connection = conn;
            _source_acciones = new DataSet();
            NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(AvailabilityChangedCallback);
            
        }

        private void AvailabilityChangedCallback(object sender, NetworkAvailabilityEventArgs e)
        {
            if (e.IsAvailable)
            {
                //Internet Connection is available  
                estado_con = "DISPONIBLE";
                Verificar_Conexion();
            }
            else
            {
                estado_con = "NO DISPONIBLE";
            }
        }
        public static Conexion_db_Mysql Get_Instance
        {
            get
            {
                if (base_datos == null)
                {
                    base_datos = new Conexion_db_Mysql();
                    
                }
                
                return base_datos;
            }
        }
        public string Estado_Conexion()
        {
            return estado_con;
        }


        public void OnStateChange(object sender, StateChangeEventArgs e)
        {
            Verificar_Conexion();
        }
        public void Verificar_Conexion()
        {
            if (conn.State.ToString() == "Closed")
            {

                Establecer_Conexion();
            }


        }
        //Metodo encargado de establecer y cerrar la conexion a la db
        private void Establecer_Conexion()
        {
            try
            {
                string connexion = string.Empty;
                if (Var_Name.tipo_basedatos.Equals("sistema_nuevo"))
                {
                    connexion = "Server=" + servidor + ";Database=" + db + ";port=3306;User Id=" + usuario + ";password=" + pass; /*+ ";SslMode=none";*/
                }
                else
                {
                    connexion = "Server=" + servidor + ";Database=" + Var_Name.name_database_viejo + ";port=3306;User Id=" + usuario + ";password=" + pass; /*+ ";SslMode=none";*/
                }
                conn = new MySqlConnection(connexion);
                conn.Open();
                conn.StateChange += new StateChangeEventHandler(OnStateChange);
                mensaje_conexion = "CONECTADO";

            }
            catch (MySqlException)
            {
                //MessageBox.Show("Error de conexion: Verifique que este conectado a Internet", "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mensaje_conexion = "ERROR DE CONEXION";

            }

        }
        public void Cerrar_Conexion()
        {
            try
            {
                conn.Close();
                base_datos = null;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al cerrar la base de datos\n" + ex);
            }
        }

        public int Get_Codigo_Tecnico(string nombre)
        {
            return total_tecnico[nombre];
        }
        public int Get_Codigo_Ubicacion(string ubicacion)
        {

            return total_ubicaciones[ubicacion];
        }
        
        public void Guardar_Institucion(Institucion institucion)
        {
            //p_insertar_institucion
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "p_insertar_institucion";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("codigo", institucion.Codigo);
                    cmd.Parameters.AddWithValue("centro_educativo", institucion.Nombre);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public string Obtener_Institucion(string codigo, string peticion)
        {
            string institucion = string.Empty;
            string sql = "select Centro_educativo from instituciones where Codigo = '" + codigo + "'";
            comando = new MySqlCommand(sql, conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                if (lector.Read())
                {
                    if (peticion.Equals("consulta"))
                    {
                        institucion = lector["Centro_educativo"].ToString();
                    }
                    else
                    {
                        institucion = lector["Centro_educativo"].ToString() + "(" + codigo + ")";
                    }

                }
                else
                {
                    institucion = "No existe";
                }

                return institucion;
            }

        }
        

        public bool Insertar_Registros_Reequipamiento(int cod_mod, string serie, string placa, string query)
        {
            try
            {
                trans = conn.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    
                    cmd.CommandText = "INSERT INTO equipos VALUES('" + cod_mod + "','" + placa + "','" + serie + "')";
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();

                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Error\n" + ex);
                return false;

            }

        }
        public DataTable Obtener_Datos_reequipamiento()
        {
            try
            {
                DataTable tabla = new DataTable();
                string sql = "SELECT * FROM view_inventario_equipos";
                adaptador = new MySqlDataAdapter(sql, conn);
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void Aplicar_Estado_Listado(int lista, string estado_lista)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE lista_inventarios SET Estado_Listado = @val_lista WHERE Listado = @val_estadoLista;";
                cmd.Parameters.AddWithValue("@val_lista", lista);
                cmd.Parameters.AddWithValue("@val_estadoLista", estado_lista);
                cmd.BeginExecuteNonQuery();
            }
        }

        //******************************************************Metodos para los procesos de acciones****************************************************//
        public DataTable Obtener_Acciones(string comando, string accion)
        {
            DataTable tabla = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "p_buscar_equipos_acciones";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("comando", comando);
                    cmd.Parameters.AddWithValue("accion", accion);

                    adaptador = new MySqlDataAdapter(cmd);
                    adaptador.Fill(tabla);
                    return tabla;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }//Metodo sobrecargado para buscar equipos en las acciones ya sea por medio de la placa o la serie        
        //Metedo para cargar la accion segun su numero
        public DataTable Importar_DB_Acciones(string accion)
        {
            try
            {
                DataTable tabla = new DataTable();
                string consulta = "SELECT Serie,Placa,Codigo_Accion,Descripcion FROM equipo_acciones WHERE ";
                consulta += accion;
                adaptador = new MySqlDataAdapter(consulta, conn);
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (Exception)
            {

                throw;
            }
        }



        //*****************************************************************Peticiones App***************************************************//

        public void GET_Ubicaciones()//Metodo para obtener las ubicaciones para los inventarios de acciones y proveedor
        {
            string sql = "SELECT Codigo,Nombre FROM ubicacion";
            comando = new MySqlCommand(sql, conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    Ubicaciones_Inventario.Add(lector["Nombre"].ToString());
                    total_ubicaciones.Add(lector["Nombre"].ToString(), lector.GetInt32("Codigo"));

                }
            }
        }


        public void GET_Lotes()//Metodo para obtener las ubicaciones para los inventarios de acciones y proveedor
        {
            string sql = "SELECT id_cartel FROM carteles";
            carteles.Clear();
            comando = new MySqlCommand(sql, conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    carteles.Add(lector["id_cartel"].ToString());

                }
            }
        }
        public int GET_Siguiente_Codigo()//Metodo para obtener El siguiente Codigo del producto
        {
            string sql = "SELECT codigo_modelo FROM view_siguiente_codigo";
            int valor_codigo = 0;
            comando = new MySqlCommand(sql, conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    valor_codigo = Convert.ToInt32(lector["codigo_modelo"].ToString());
                }
            }
            return valor_codigo + 1;
        }

        public List<string> GET_Tipos_Equipos()//Metodo para obtener las ubicaciones para los inventarios de acciones y proveedor
        {
            List<string> lista = new List<string>();
            string sql = "SELECT * FROM acs_sistema.tipos_equipos";
            comando = new MySqlCommand(sql, conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    lista.Add(lector["id_tipo"].ToString() + "-" + lector["tipo_equipo"].ToString());

                }
            }
            return lista;
        }

        public bool Guardar_Modelos_equipos(int codigo, string marca,string modelo,string tipo)
        {
            try
            {
                trans = conn.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ingreso_modelo_equipos";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("codigo", codigo);
                    cmd.Parameters.AddWithValue("marca", marca);
                    cmd.Parameters.AddWithValue("modelo", modelo);
                    cmd.Parameters.AddWithValue("tipo", tipo);
                    cmd.ExecuteNonQuery();

                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Error\n" + ex);
                if (conn.State.ToString() == "Closed")
                {

                    Establecer_Conexion();
                }

                return false;

            }

        }

        public Equipos procesar_datos_equipos(string placa_serie, string tipo)
        {
            Equipos equipo = new Equipos();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.CommandText = "p_buscar_equipos";
                    cmd.Parameters.AddWithValue("buscar", placa_serie);
                    cmd.Parameters.AddWithValue("comando", tipo);
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
                    return equipo;
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
        public int get_num_acciones(string tipo_accion)
        {
            int num_accion = 0;
            string consulta = string.Empty;
            if (tipo_accion.Equals("orden_trabajo"))
            {
                consulta = "SELECT * FROM nueva_orden";
            }
            else
            {
                consulta = "SELECT * FROM nueva_orden_materiales";
            }
            
            comando = new MySqlCommand(consulta,conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    num_accion = Convert.ToInt32(lector["Codigo"]);
                }
            }
            return num_accion;
        }
        public int get_num_pedido()
        {
            int num_accion = 0;
            string consulta = consulta = "SELECT Codigo FROM nuevo_registro_pedido";
            
            comando = new MySqlCommand(consulta, conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    num_accion = Convert.ToInt32(lector["Codigo"]);
                }
            }
            return num_accion+1;
        }
        public bool Insertar_Registros_Inventarios(Equipos_Reequipamiento equi_requi, string query)
        {
            try
            {
                trans = conn.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "p_insertar_equipos_inventarios";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("serie", equi_requi.Serie);
                    cmd.Parameters.AddWithValue("placa", equi_requi.Placa);
                    cmd.Parameters.AddWithValue("institucion", equi_requi.Institucion);
                    cmd.Parameters.AddWithValue("modalidad", equi_requi.Modalidad);
                    cmd.Parameters.AddWithValue("accion", equi_requi.Accion);
                    cmd.Parameters.AddWithValue("numero_estacion", equi_requi.Numero_Maquina);
                    cmd.ExecuteNonQuery();

                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Error\n" + ex);
                if (conn.State.ToString() == "Closed")
                {

                    Establecer_Conexion();
                }
                
                return false;

            }

        }
        
        public DataSet Get_reporte_acciones(int accion)
        {
            _source_acciones.Clear();
            using (MySqlCommand cmd = new MySqlCommand())
            {

                cmd.CommandText = "SELECT * FROM lista_inventarios WHERE lista_inventarios.Accion = '"+accion+"'";
                cmd.Connection = conn;
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(_source_acciones);
                }
            }
            return _source_acciones;
        }
        public DataSet Get_reporte_pedido(int orden,string ubicacion)
        {
            _source_acciones.Clear();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "buscar_pedidos";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("orden", orden);
                    cmd.Parameters.AddWithValue("ubicacion",ubicacion);
                    cmd.Connection = conn;
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(_source_acciones);
                    }
                    return _source_acciones;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public DataSet Get_reporte_salida_materiales(int orden)
        {
            _source_acciones.Clear();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "b_salida_materiales";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("orden_buscar", orden);
                    cmd.Connection = conn;
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(_source_acciones);
                    }
                    return _source_acciones;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        

        public DataTable Obtener_Acciones(int accion)
        {
            try
            {
                string consulata = "SELECT * FROM lista_inventarios WHERE Accion = '" + accion + "'";
                DataTable tabla = new DataTable();
                adaptador = new MySqlDataAdapter(consulata, conn);
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (MySqlException)
            {

                throw;
            }
        }
        public void Crear_Accion(int accion, string descripcion,string tipo_orden)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                DateTime time = new DateTime();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "p_insertar_acciones";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("accion", accion);
                cmd.Parameters.AddWithValue("descripcion", descripcion);
                cmd.Parameters.AddWithValue("fecha", time);
                cmd.Parameters.AddWithValue("tipo_orden", tipo_orden);
                cmd.ExecuteNonQuery();
            }
            
        }


        //p_insertar_orden_materiales

        public void Crear_Orden_Materiales(int orden, string descripcion)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                DateTime time = new DateTime();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "p_insertar_orden_materiales";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("orden", orden);
                cmd.Parameters.AddWithValue("descripcion", descripcion);
                cmd.Parameters.AddWithValue("fecha", time);
                cmd.ExecuteNonQuery();
            }

        }
        public void Agregar_Materiales_Inventario(string descripcion,int cantidad,int orden)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                   
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "actualizar_inventarios_materiales";
                    cmd.Connection = conn;
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
        public int Obtener_Cantidad_Material(string descripcion)
        {
            try
            {
                int cantidad = 0;
                string sql = "SELECT cantidad FROM cantidad_stock_materiales WHERE descripcion = '" + descripcion + "'";
                comando = new MySqlCommand(sql, conn);
                using (MySqlDataReader lector = comando.ExecuteReader())
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
                return -1;
            }
        }


        public void Agregar_Materiales_Lista_Inventario(string descripcion, int cantidad, int orden,string tecnico)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "registro_inventarios_materiales_tecnicos";
                    cmd.Connection = conn;
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
        public void Registrar_Producto(string codigo,string descripcion)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "registrar_producto";
                    cmd.Connection = conn;
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
        public DataSet Get_Equipos_General()
        {
            DataSet data = new DataSet();
            try
            {
                string consulta = "SELECT * FROM reporte_general";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, conn))
                {

                    adapter.Fill(data);
                }
               
            }
            catch (Exception)
            {
                if (conn.State.ToString() == "Closed")
                {
                    
                    Establecer_Conexion();
                }
                
               
            }
            return data;
            
        }
        public DataTable Obtener_Estados_Acciones(int accion,string tipo)
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
                using (MySqlDataAdapter lector = new MySqlDataAdapter(consulta, conn))
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


        /*Obtener cambios Realizados*/
        public DataTable Obtener_Cambios_Ordenes(int orden, string tipo)
        {
            DataTable tabla = new DataTable();
            try
            {
                
                string consulta = "SELECT * FROM cambios where orden ='"+orden+"' AND estado ='"+tipo+"'";
                using (MySqlDataAdapter lector = new MySqlDataAdapter(consulta, conn))
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

        public DataTable Obtener_ordenes_materiales()
        {
            DataTable tabla = new DataTable();
            string consulta = "SELECT * FROM ordenes_materiales";

            using (MySqlDataAdapter lector = new MySqlDataAdapter(consulta, conn))
            {
                lector.Fill(tabla);
            }
            return tabla;
        }


        //
        public DataTable Obtener_Estados_Ordenes_produccion(string tipo)
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
            using (MySqlDataAdapter lector = new MySqlDataAdapter(consulta, conn))
            {
                lector.Fill(tabla);
            }
            return tabla;
        }
        public bool Actuallizar_Estado_Orden_Produccion(int orden, string estado_update)
        {
            try
            {
                bool estado = true;
                string sql = "UPDATE estado_orden_produccion SET estado= '"+ estado_update + "' WHERE id_estado_orden ='"+orden+"'";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                return estado;
            }
            catch (Exception)
            {
                if (conn.State.ToString() == "Closed")
                {

                    Establecer_Conexion();
                }
                return false;
            }
        }

        public void Aplicar_Acciones_Db(int accion, string estado)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "p_Aplicar_Estado_Accion";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("accion", accion);
                cmd.Parameters.AddWithValue("estado", Get_Codigo_Ubicacion(estado));
                cmd.ExecuteNonQuery();
            }
        }

        public void Ingresar_Factura(int numero, string detalle, double valor,string fecha,int orden,string tipo)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "insertar_factura";
                cmd.Connection = conn;
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

        public DataTable Obtener_Datos_Lista_instituciones(string comando, string accion)
        {
            DataTable tabla2 = new DataTable();
            try
            {

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.CommandText = "p_buscar_lista_inventarios";
                    cmd.Parameters.AddWithValue("comando", comando);
                    cmd.Parameters.AddWithValue("accion_usu", accion);
                    adaptador = new MySqlDataAdapter(cmd);
                    adaptador.Fill(tabla2);
                }

                return tabla2;
            }
            catch (Exception)
            {

                MessageBox.Show("Error al cargar vuelva a intentarlo", "Error al procesar Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return tabla2;
            }
            
        }
        public bool Ingresar_Equipo_Nuevo(int tipo,string placa, string serie,string cartel)
        {
            try
            {
                bool estado = true;

                //ingreso_equipos
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "ingreso_equipos";
                    cmd.Connection = conn;
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
                if (conn.State.ToString() == "Closed")
                {

                    Establecer_Conexion();
                }
                return false;
            }
            
        }
        public DataTable Get_Tipos_Equipos()//Metodo para obtener los tipos de invenarios y almacenarlos en un diccionario para conversiones
        {
            DataTable datos = new DataTable();
            string sql = "SELECT * FROM views_tipos_equipos;";
            using (MySqlDataAdapter adaptador = new MySqlDataAdapter(sql,conn))
            {
                adaptador.Fill(datos);
            }
            return datos;
        }
        public DataTable Get_Tipos_Materiales()//Metodo para obtener los tipos de invenarios y almacenarlos en un diccionario para conversiones
        {
            DataTable datos = new DataTable();
            string sql = "SELECT * FROM acs_sistema.view_lista_materiales;";
            using (MySqlDataAdapter adaptador = new MySqlDataAdapter(sql, conn))
            {
                adaptador.Fill(datos);
            }
            return datos;
        }

        public Equipos_Instalacion_Instituciones Get_Equipos_Instituciones(string codigo,string tipo,int orden)
        {
            Equipos_Instalacion_Instituciones equi = new Equipos_Instalacion_Instituciones();
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

                comando = new MySqlCommand(consulta, conn);
                using (MySqlDataReader lector = comando.ExecuteReader())
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


        /*obtenemos los registros*/
        public DataTable Get_Total_regitros_pedidos()
        {
            DataTable data_pedidos = new DataTable();
            string consulta = String.Empty;
            consulta = "SELECT * FROM buscar_pedido_equipos";
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, conn))
            {

                adapter.Fill(data_pedidos);
            }
            return data_pedidos;

        }
        public Equipos_Instalacion_Instituciones Get_Equipos_Verificacion_Pedido(int orden)
        {
            string consulta = string.Empty;
            Equipos_Instalacion_Instituciones equi = new Equipos_Instalacion_Instituciones();
            consulta = "SELECT * FROM equipos_instalacion_instituciones_final WHERE id_orden= '" + orden + "'";

            comando = new MySqlCommand(consulta, conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
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

        public bool Insertar_Institucion_Equipos_final(Equipos_Instalacion_Instituciones equi,string orden,string encargado,string num_pedido)
        {
            try
            {
                trans = conn.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.CommandText = "insertar_orden_preparacion_equipos";
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
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();

                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Error\n" + ex);
                return false;

            }

        }
        public void Insertar_Cambios(string placa, string serie, int accion,string estado,int estacion)
        {
            try
            {
                //insertar_cambios
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.CommandText = "insertar_cambios";
                    cmd.Parameters.AddWithValue("placa",placa);
                    cmd.Parameters.AddWithValue("serie",serie);
                    cmd.Parameters.AddWithValue("orden",accion);
                    cmd.Parameters.AddWithValue("tipo", estado);
                    cmd.Parameters.AddWithValue("estacion", estacion);
                    cmd.Parameters.AddWithValue("fecha",Var_Name.Fecha_Actual);
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Registro ya existe "+ex, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool Eliminar_Equipo_Nuevo(string placa, string serie, int accion, int Numero_Estacion)
        {
            try
            {
                bool estado = true;
                string sql = @"DELETE FROM lista_inventarios WHERE Placa = '"+placa+"' AND Accion = '"+accion+"'";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                Insertar_Cambios(placa,serie,accion,"ELIMINADO",Numero_Estacion);
                return estado;
            }
            catch (Exception EX)
            {
                MessageBox.Show("Error al guardar Registros "+EX, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public List<string> Obtener_Lista_Materiales()
        {
            List<string> materiales = new List<string>();

            string sql = "SELECT descripcion FROM seleccionar_materiales";
            comando = new MySqlCommand(sql, conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    materiales.Add(lector["descripcion"].ToString());
                }
            }
            return materiales;
        }
        public List<string> Obtener_Tecnicos()
        {
            List<string> tecnicos = new List<string>();

            string sql = "SELECT nombre FROM obtener_tecnicos";
            comando = new MySqlCommand(sql, conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    tecnicos.Add(lector["nombre"].ToString());
                }
            }
            return tecnicos;
        }
        public int Get_Codigo_Tecnico()//Metodo para obtener El siguiente Codigo del producto
        {
            string sql = "SELECT codigo_tecnico FROM view_get_codigotecnico";
            int valor_codigo = 0;
            comando = new MySqlCommand(sql, conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    valor_codigo = Convert.ToInt32(lector["codigo_tecnico"].ToString());
                }
            }
            return valor_codigo + 1;
        }
        public bool Save_Tecnicos(string nombreTecnico)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    int codigo = Get_Codigo_Tecnico();
                    cmd.CommandText = "INSERT INTO tecnicos VALUES('"+codigo+"','"+ nombreTecnico + "')";
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public DataTable Get_Facturas_Materiales(string tipo)
        {
            DataTable datos = new DataTable();
            string consulta = string.Empty;
            if (tipo.Equals("Facturas Equipos"))
            {
                consulta = "SELECT * FROM factura_ordenes;";
            }
            else
            {
                consulta = "SELECT * FROM factura_materiales;";
            }
            using (MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conn))
            {
                adaptador.Fill(datos);
            }
            return datos;
        }
        public DataTable Get_Inventario_Materiales()
        {
            DataTable datos = new DataTable();
            string consulta = string.Empty;
             consulta = "SELECT * FROM materiales_en_inventario;";
            
            using (MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conn))
            {
                adaptador.Fill(datos);
            }
            return datos;
        }
        public bool Insertar_Materiales_Costo_Unidad(string num_fact,string detalle, double costo, string codigo_equipo,string tipo)
        {
            try
            {
                trans = conn.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.CommandText = "insertar_factura_costo_unidad";
                    cmd.Parameters.AddWithValue("num_fac", num_fact);
                    cmd.Parameters.AddWithValue("detalle", detalle);
                    cmd.Parameters.AddWithValue("valor", costo);
                    cmd.Parameters.AddWithValue("codigo_equipo", codigo_equipo);
                    cmd.Parameters.AddWithValue("tipo", tipo);
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();

                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Error\n" + ex);
                return false;

            }

        }
        public List<string> Get_Danos()//Metodo para obtener listado de Daños de la base de datos
        {
            List<string> danos = new List<string>();
            string sql = "SELECT dano FROM danos";
            comando = new MySqlCommand(sql, conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    danos.Add(lector["dano"].ToString());
                }
            }

            return danos;
        }
        public DataTable Get_Equipos_Danados()
        {
            DataTable datos = new DataTable();
            string consulta = string.Empty;
            consulta = "SELECT * FROM view_equipos_reparacion;";

            using (MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conn))
            {
                adaptador.Fill(datos);
            }
            return datos;
        }
        public bool Insertar_Equipos_Danos(string placa, string serie, string dano, string estado)
        {
            try
            {
                trans = conn.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.CommandText = "insertar_equipos_reparacion";
                    cmd.Parameters.AddWithValue("placa_equi", placa);
                    cmd.Parameters.AddWithValue("serie_equi", serie);
                    cmd.Parameters.AddWithValue("danos", dano);
                    cmd.Parameters.AddWithValue("estado_equi", estado);

                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();

                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Error\n" + ex);
                return false;

            }

        }
        public string obtener_login_usuario(string user, string password)
        {
            try
            {
                string rol = string.Empty;

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string sql = "SELECT rol_user FROM usuarios WHERE nom_user = '"+user+"' AND pass_user= '"+password+"'";
                    comando = new MySqlCommand(sql, conn);
                    using (MySqlDataReader lector = comando.ExecuteReader())
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
        //GENERAR REPORTE EQUIPOS GARANTIA
        public DataSet Get_Equipos_Garantia(string tipo)
        {
            string consulta = string.Empty;
            DataSet data = new DataSet();
            try
            {
                if (tipo.Equals("GENERAL"))
                {
                    consulta = "SELECT * FROM view_equipos_reparacion";
                }
                else
                {
                    consulta = "SELECT * FROM view_equipos_reparacion WHERE ESTADO ='"+tipo+"'" ;
                }
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, conn))
                {

                    adapter.Fill(data);
                }

            }
            catch (Exception)
            {
                if (conn.State.ToString() == "Closed")
                {

                    Establecer_Conexion();
                }


            }
            return data;

        }


        public string Get_Descripcion_Salida_Materiales(int orden)
        {
            string descrip = string.Empty;

            try
            {
                
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string sql = "SELECT descripcion FROM ordenes_materiales WHERE codigo = '"+orden+"'";
                    comando = new MySqlCommand(sql, conn);
                    using (MySqlDataReader lector = comando.ExecuteReader())
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
                if (conn.State.ToString() == "Closed")
                {

                    Establecer_Conexion();
                    descrip = "Error al procersar los datos";
                }


            }
            return descrip;

        }
        public string Get_Descripcion_Orden_Trabajo(int orden)
        {
            string descrip = string.Empty;

            try
            {

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string sql = "SELECT Descripcion FROM acciones WHERE Codigo = '" + orden + "'";
                    comando = new MySqlCommand(sql, conn);
                    using (MySqlDataReader lector = comando.ExecuteReader())
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
                if (conn.State.ToString() == "Closed")
                {

                    Establecer_Conexion();
                    descrip = "Error al procersar los datos";
                }


            }
            return descrip;

        }
        public List<string> Get_Roles()
        {
            List<string> roles = new List<string>();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string sql = "SELECT id_rol from roles";
                    comando = new MySqlCommand(sql, conn);
                    using (MySqlDataReader lector = comando.ExecuteReader())
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
                if (conn.State.ToString() == "Closed")
                {

                    Establecer_Conexion();
                }


            }
            return roles;

        }
        public bool Insertar_Usuarios(string user,string pass,string rol)
        {
            try
            {
                trans = conn.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "INSERT INTO usuarios VALUES ('" + user + "','" + pass + "','" + rol + "')";
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();

                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Error\n" + ex);
                return false;

            }

        }
        public Instalaciones Get_Datos_Instalaciones(string codigo)
        {
            Instalaciones insta = new Instalaciones();
            string sql = "SELECT codigo_institucion,cantidad_instalada,descripcion,fecha_registro,documento FROM acs_sistema.instalaciones_cableado WHERE codigo_institucion='" + codigo + "'";
            comando = new MySqlCommand(sql, conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
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
        public string Get_Orden_Pendientes()
        {
            string num_accion = string.Empty;
            string consulta = "SELECT * FROM cantidad_pendientes";
            comando = new MySqlCommand(consulta, conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    num_accion = lector["Total"].ToString();
                }
            }
            return num_accion;
        }

        //Registrar Carteles Nuevos
        public bool Registrar_Cartel(string codigo, string descripcion, string fecha)
        {
            try
            {
                trans = conn.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "INSERT INTO carteles VALUES ('" + codigo + "','" + descripcion + "','" + fecha + "')";
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();

                }
                trans.Commit();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }


}
