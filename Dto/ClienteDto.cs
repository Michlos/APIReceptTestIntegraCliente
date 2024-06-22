using System.ComponentModel.DataAnnotations;

namespace IntegraCliente.Dto
{
    public class ClienteDto
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Fantasia { get; set; }
        public string TpDoc { get; set; }
        public string Cgc { get; set; }
    }
}
