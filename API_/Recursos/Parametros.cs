namespace API_.Recursos
{
    public class Parametros
    {
        public Parametros(string nombre, string valor)
        {
            Nombre = nombre;
            Valor = valor;
        }
        public string Nombre { get; set; }
        public string Valor { get; set; }
    }
}
