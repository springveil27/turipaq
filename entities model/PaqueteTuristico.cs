
namespace turipaq.entities_model
{
    public class PaqueteTuristico
    {
        public int PaqueteId { get; set; }
        public string Destino { get; set; }
        public string Duracion { get; set; }
        public int Precio { get; set; }
        public bool Disponibilidad { get; set; }
        public int ReservasActuales { get; set; }
        public string TipoViaje { get; set; }
    }
}
