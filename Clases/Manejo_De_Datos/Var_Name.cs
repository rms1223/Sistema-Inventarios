using System;

namespace InventarioFod.Clases
{
    public static class Var_Name
    {
        public static string Acciones {
            get
            {
                return "Acciones";
            }
        }
        public static string Serie {
            get
            {
                return "Serie";
            }
        }
        public static string Placa {
            get
            {
                return "Placa";
            }
        }
        public static string Nombre_Hoja
        {
            get
            {
                return "Hoja1";
            }
        }
        public static string Nombre_Hoja_Reequipamiento
        {
            get
            {
                return "Reequipamiento";
            }
        }
        public static string Descripcion
        {
            get
            {
                return "Descripcion";
            }
        }
        public static string Listado
        {
            get
            {
                return "Listado";
            }
        }
        public static string Lista
        {
            get
            {
                return "Lista";
            }
        }
        public static string ORDEN_ENTRADA
        {
            get
            {
                return "ENTRADA";
            }
        }
        public static string ORDEN_SALIDA
        {
            get
            {
                return "SALIDA";
            }
        }
        public static string Codigo_Institucion
        {
            get
            {
                return "Codigo Institucion";
            }
        }
        public static string Nombre_Institucion
        {
            get
            {
                return "Nombre Institucion";
            }
        }
        public static string Institucion
        {
            get
            {
                return "Institucion";
            }
        }
        public static string Tipo_Modalidad
        {
            get
            {
                return "Tipo Modalidad";
            }
        }
        public static string Tipo_Cartel
        {
            get
            {
                return "Tipo Cartel";
            }
        }
        public static string Tipo_Equipo
        {
            get
            {
                return "Tipo Equipo";
            }
        }
        public static string Total_Equipos
        {
            get
            {
                return "Total Equipos";
            }
        }
        public static string Accion
        {
            get
            {
                return "Accion";
            }
        }
        public static string Tecnico
        {
            get
            {
                return "Tecnico";
            }
        }
        public static string Total_Paquetes
        {
            get
            {
                return "Total Paquetes";
            }
        }

        public static string Modelo_Equipo
        {
            get
            {
                return "Modelo Equipo";
            }
        }

        public static string Codigo_Accion
        {
            get
            {
                return "Codigo_Accion";
            }
        }

        //Nombre de las variables para cargar el archivo
        //de Reequipamiento
        public static string Listado_Requi
        {
            get
            {
                return "Listado No";
            }
        }
        public static string Codigo_Requi
        {
            get
            {
                return "Código";
            }
        }
        public static string Institucion_Requi
        {
            get
            {
                return "Nombre del Centro Educativo";
            }
        }
        public static string Beneficiario_Requi
        {
            get
            {
                return "Beneficiado";
            }
        }
        public static string Cartel_Requi
        {
            get
            {
                return "Cartel";
            }
        }
        public static string Modelo_Requi
        {
            get
            {
                return "Modelo Equipamiento";
            }
        }
        public static string Apellido_Requi
        {
            get
            {
                return "Primer Apellido";
            }
        }


        //Nombre de las variables para la conexion 
        //con la base de datos 
        public static string server{ get; set; }
        public static string user{ get; set; }
        public static string pass{ get; set; }
        public static string name_database { get; set; }
        public static string name_database_viejo { get; set; }

        public static string tipo_basedatos { get; set; }
        //Varibales de los tipos de inventarios para los
        //Combobox
        public static string Proveedor
        {
            get
            {
                return "Proveedor";
            }
        }
        public static string Proveedor_Centro_Soporte
        {
            get
            {
                return "Proveedor EN CENTRO SOPORTE";
            }
        }
        public static string Proveedor_Buenas
        {
            get
            {
                return "PROVEEDOR BUENAS";
            }
        }
        public static string Proveedor_Malas
        {
            get
            {
                return "PROVEEDOR MALAS";
            }
        }
        public static string Proveedor_Bodega
        {
            get
            {
                return "PROVEEDOR BODEGA";
            }
        }

        /************************************Datos para almacenar lo del correo**********************************/
        public static string Mail_User
        {
            get
            {
                return "info@appcorporacionacs.info";
            }

        }
        public static string Mail_Pass {
            get
            {
                return "26262326RaMoSo@#$%";
            }
        }
        public static string SmtpHost
        {
            get
            {
                return "smtp-relay.gmail.com";
            }
        }
        public static string Email_from
        {
            get
            {
                return "info@appcorporacionacs.info";
            }
        }

        public static int SmtpPort
        {
            get
            {
                return 587;
            }

        }

        ///usuarios del sistema 
        public static string Usu_Bodega
        {
            get
            {
                
                return "ABI2019";
            }
        }
        public static string Usu_Administrativo
        {
            get
            {
                
                return "AAI2019";
            }
        }
        public static string Usu_Tecnicos
        {
            get
            {
               
                return "ATI2019";
            }
        }
        public static string Usu_Administrador
        {
            get
            {
                
                return "AADMIN2019";
            }
        }
        public static string Fecha_Actual
        {
            get
            {

                return DateTime.Now.ToString("dd/MM/yyyy");
            }
        }
        public static string Clave
        {
            get
            {

                return "acs_2020";
            }
        }
    }
}
