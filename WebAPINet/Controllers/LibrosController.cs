using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPINet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibrosController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }

        [HttpGet("GetBienvenidoLector/{nombre}")]
        public string Get(string nombre)
        {
            return "Bienvenido al mundo de la lectura " + nombre;
        }

        private struct Usuario
        {
            public string nombre;
            public int id;
            public string edad;
        }

        [HttpGet("GetDatosLibro/{nombre}/{id}/{edad}")]
        public string Get(string nombre, int id, string edad) 
        {
            Usuario usuario = new Usuario();
            usuario.nombre = nombre;
            usuario.edad    = edad;
            usuario.id  = id;

            string respuesta = JsonConvert.SerializeObject(usuario);
            return respuesta;
        }

        public class LibrosPrestados
        {
            public int id { get; set; }
            public string nombre { get; set; }
        }

        [HttpPost("PostLibros")]
        public string Post(LibrosPrestados librosPrestados)
        {
            return JsonConvert.SerializeObject(librosPrestados);
        }
    }
}
