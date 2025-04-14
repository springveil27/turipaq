using turipaq.Database;
using turipaq.entities_model;

namespace turipaq.Login
{
    public class LogicLogin
    {
   public static Cliente UsuarioIniciado {  get; set; }
        public static bool Login(string usuario, string contrasena)
        {
           var context = new DataContext();
            var cliente = context.Clientes.Where(u => u.Usuario == usuario && u.Contrasena == contrasena).FirstOrDefault();
            if (cliente != null) {
                UsuarioIniciado = cliente;
                return true;
                }
            {
                return false;
            }
            return false;
        }

        public static void Logout() => UsuarioIniciado = null;

        public static bool EsAdmin() => UsuarioIniciado != null && UsuarioIniciado.Admin;
        
    }
}

