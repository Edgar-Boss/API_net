namespace API_.Models
{
    public class Doctor
    {
        public int ID_Doctor { get; set; }
        public string Nombre { get; set; }
        public string Apaterno { get; set; }
        public string Amaterno { get; set; }
        public int Edad { get; set; }
        public  int Telefono { set; get; }
        public string Urlfoto { get; set; } 
        public string Consultorio_id { get; set; }
    }
}
