using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using turipaq.Database;

namespace turipaq.entities_model
{
   public class Cliente : PersonaBase
    {
        public int ClienteId { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public bool Admin {  get; set; }
    }
}
