﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turipaq.entities_model
{
        public abstract class PersonaBase
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string DocumentoIdentidad { get; set; }
            public string Telefono { get; set; }
            public string Correo { get; set; }


        }
    }

