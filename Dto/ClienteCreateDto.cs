using System.ComponentModel.DataAnnotations;

namespace IntegraCliente.Dto
{
    public class ClienteCreateDto
    {

        public long Id { get; set; }
        
        [MaxLength(60)]
        public string Nome { get; set; }

        [MaxLength(64)]
        public string Codigo { get; set; }
        
        [MaxLength(4)]
        public string TpDoc { get; set; }

        [MaxLength(14)]
        public string Cgc { get; set; }

        [MaxLength(60)]
        public string Fantasia { get; set; }

        [MaxLength(20)]
        public int Cep { get; set; }

    }
}
