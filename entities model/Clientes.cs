using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using turipaq.Database;

namespace turipaq.entities_model
{
   public class Cliente
    {
        public int ClienteId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? DocumentoIdentidad { get; set; }

        public string? Usuario { get; set; }
        public string Contrasena { get; set; }
        public bool? Admin {  get; set; }
    }
}
