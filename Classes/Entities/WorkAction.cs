using System;

namespace SystemIventory.Entidades
{
    class WorkAction
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public WorkAction(int codigo, string descripcion, DateTime fecha)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Fecha = fecha;
        }
    }
}
