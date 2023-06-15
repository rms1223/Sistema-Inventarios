namespace SystemIventory.Classes.Entities
{
    class Institution
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public Institution() { }
        public Institution(string codigo, string nombre)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
        }
    }
}
