namespace SystemIventory.Classes.Entities
{
    public class Equipos_Reequipamiento
    {
        
        public string Serie { get; set; }
        public string Placa { get; set; }
        public int Numero_Maquina { get; set; }
        public int Accion { get; set; }
        public string Institucion { get; set; }
        public string Modalidad { get; set; }
        public string Tipo_Equipo { get; set; }

        public Equipos_Reequipamiento(int listado, string serie, string placa, int numero_Paquete, int nUmero_Maquina, int accion, string institucion, string modalidad, string estado, string fecha, string tecnico, string estado_Listado)
        {
            Serie = serie;
            Placa = placa;
            
            Accion = accion;
            Institucion = institucion;
            Modalidad = modalidad;
        }
        public Equipos_Reequipamiento() { }
    }
}
