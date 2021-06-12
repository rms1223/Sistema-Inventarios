namespace InventarioFod.Clases.Notificaciones
{
    class PeticionesApp
    {
        private Conexion_db_Mysql _conexion_Db; 
        public PeticionesApp()
        {
            _conexion_Db = Conexion_db_Mysql.Get_Instance;
        }



    }
}
