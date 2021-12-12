using System.ComponentModel.DataAnnotations;

namespace Finance.Models
{
    public class TipoDespesa
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public  Despesa Despesas { get; set; }
    }
}                                                                 