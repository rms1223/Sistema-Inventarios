using System;

namespace InventarioFod.Clases.Entidades
{
    class Listado : Institucion
    {
        public int Lista { get; set; }
        public int Total_Maquinas { get; set; }
        public int Total_Paquetes { get; set; }
        public string Modalidad { get; set; }
        public string Tipo { get; set; }
        public string Equipo { get; set; }
        public string Cartel { get; set; }

        public Listado(string lista, string codigo,string institucion, string total_maquinas, string total_paquetes, string modalidad, string tipo, string equipo, string cartel)
            :base(codigo,institucion)
        {
            this.Codigo = codigo;
            this.Modalidad = modalidad;
            this.Tipo = tipo;
            this.Equipo = equipo;
            this.Cartel = cartel;
            Convert_val_to_int(lista,total_maquinas,total_paquetes);
        }
        public Listado()
            : base()
        { }

        private void Convert_val_to_int(string lista,string total_maquinas,string total_paquetes)
        {
            this.Lista = Convert.ToInt32(lista);
            this.Total_Maquinas = Convert.ToInt32(total_maquinas);
            this.Total_Paquetes = Convert.ToInt32(total_paquetes);
        }
    }
}
