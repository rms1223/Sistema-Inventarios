namespace InventarioFod.Clases.Entidades
{
    class Institucion
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public Institucion() { }
        public Institucion(string codigo, string nombre)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
        }
    }
}
