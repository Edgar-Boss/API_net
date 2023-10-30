using API_.Models;
using API_.Recursos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Text.Json.Serialization;

namespace API_.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route ("Listar")]
        public dynamic ListarCliente()
        {
            
            DataTable tabla =  DBDatos.Listar("sp_getdoctores");

            string jsonhosp = JsonConvert.SerializeObject(tabla);
            
           
            return new
            {
                success = true,
                message = "exito",
                result = new
                {
                    categoria = JsonConvert.DeserializeObject<List<Doctor>>(jsonhosp)
                }
            };
        }

        
        [HttpGet]
        [Route("Listarbyid")]
        public dynamic ListarClientebyid(int _id)
        {


            DataTable tabla = DBDatos.Listar("sp_getdoctoresbyid","@id",_id);

            string jsonhosp = JsonConvert.SerializeObject(tabla);


            return new
            {
                success = true,
                message = "exito",
                result = new
                {
                    categoria = JsonConvert.DeserializeObject<List<Doctor>>(jsonhosp)
                }
            };

        }

        

        [HttpPost]
        [Route("guardar")]
        public dynamic GuardarCliente(Doctor doctor)
        {
            List<Parametros> parametros = new List<Parametros>
            {
               
                new Parametros("@nombre",doctor.Nombre),
                new Parametros("@apaterno", doctor.Apaterno),
                new Parametros("@amaterno",doctor.Amaterno),
                new Parametros("@edad",doctor.Edad.ToString()),
                new Parametros("@telefono", doctor.Telefono.ToString()),
                new Parametros("@urlfoto",doctor.Urlfoto),
                new Parametros("@consultorio",doctor.Consultorio_id)
            };
            bool exito = DBDatos.Ejecutar("sp_insertdoctores",parametros);

            return new
            {
                success = exito,
                message = exito ? "exito" : "Error al guardar",
                result = ""
            };


        }



    }
}
