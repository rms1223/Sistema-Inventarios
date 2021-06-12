namespace InventarioFod.Clases.Entidades
{
    class Equipo_Acciones
    {
        public int Codigo_Accion { get; set; }
        public string Serie { get; set; }
        public string Placa { get; set; }
        public string Descripcion { get; set; }

        public Equipo_Acciones(int codigo_Accion, string serie, string placa, string descripcion)
        {
            Codigo_Accion = codigo_Accion;
            Serie = serie;
            Placa = placa;
            Descripcion = descripcion;
        }
    }
}
