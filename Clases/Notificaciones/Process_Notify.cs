
namespace InventarioFod.Clases.Notificaciones
{
    class Process_Notify
    {
        private Conexion_db_Mysql _base_datos;
        private PeticionesApp peticionesApp;

        public Process_Notify()
        {
            _base_datos = Conexion_db_Mysql.Get_Instance;
            peticionesApp = new PeticionesApp();
        }


        //Metodos listos para implementar
        public string SelectByAction(int orden)
        {
            return string.Empty;
            
        }
        public string SelectByList(int list)
        {
            return string.Empty;
        }
    }
        
}
