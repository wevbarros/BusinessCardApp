using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualCard.Models
{

    [Table("Contributor")]

    public class Contributor
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }


        [Column("Nome")]
        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Column("SurName")]
        [Display(Name = "SobreNome")]
        public string? SurName { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        public string? Email { get; set; }


        [Column("Cargo")]
        [Display(Name = "Cargo")]
        public string? Office { get; set; }

        [Column("Telefone")]
        [Display(Name = "Telefone")]
        public int Telephone { get; set; }


    }

}