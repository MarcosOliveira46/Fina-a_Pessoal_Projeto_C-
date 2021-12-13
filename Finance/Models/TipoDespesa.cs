using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Finance.Models
{
    public class TipoDespesa
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Despesa> Despesa{ get; set; }
    }
}                                                                 