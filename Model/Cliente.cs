using System.ComponentModel.DataAnnotations;

namespace IntegraCliente.Model
{
    public class Cliente
    {
        public long Id { get; set; }

        [MaxLength(60)]
        public string Nome { get; set; }

        [MaxLength(64)]
        public string Codigo { get; set; }

        [MaxLength(122)]
        public string? Integracao { get; set; }

        [MaxLength(4)]
        public string TpDoc { get; set; }

        [MaxLength(14)]
        public string Cgc { get; set; }

        [MaxLength(60)]
        public string Fantasia { get; set; }

        [MaxLength(20)]
        public string? Fone { get; set; }

        public int Cep { get; set; }

        [MaxLength(60)]
        public string? Logradouro { get; set; }

        [MaxLength(10)]
        public string? Numero { get; set; }

        [MaxLength(30)]
        public string? Bairro { get; set; }

        [MaxLength(30)]
        public string? Cidade { get; set; }

        [MaxLength(2)]
        public string? Uf { get; set; }

    }
}
