using System;

namespace InventarioFod.Entidades
{
    class Ordenes
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public Ordenes(int codigo, string descripcion, DateTime fecha)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Fecha = fecha;
        }
    }
}
