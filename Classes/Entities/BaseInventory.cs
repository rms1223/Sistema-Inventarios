namespace SystemIventory.Classes.Entities
{
    public class BaseInventory
    {
        public string Serie { get; set; }
        public string Placa { get; set; }
        public string Descripcion { get; set; }
        public int Accion { get; set; }
        public string Fecha { get; set; }
        public string Tecnico { get; set; }
        public string Danos { get; set; }

        public BaseInventory(string serie, string placa, string descripcion, int accion, string fecha, string tecnico, string danos)
        {
            Serie = serie;
            Placa = placa;
            Descripcion = descripcion;
            Accion = accion;
            Fecha = fecha;
            Tecnico = tecnico;
            Danos = danos;
        }

        public BaseInventory()
        {
        }
    }
}
