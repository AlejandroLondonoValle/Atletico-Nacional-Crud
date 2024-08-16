using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtleticoNacionalCRUD.Models
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Posicion { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string PieHabil { get; set; }
        public string Nacionalidad { get; set; }
        
    }
}