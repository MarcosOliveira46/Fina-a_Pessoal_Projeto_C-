using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Models
{
    public class Despesa
    {
        
        [Key]
        public int Despesa_Id { get; set; }

        [Display(Name ="Data")]
        public DateTime Data_Despesa { get; set; }

        [Display(Name = "Valor")]
        public double  Despesa_Valor { get; set; }

        [ForeignKey("TipoDespesas")]
        public int TipoDespesaId { get; set; }
        public TipoDespesa TipoDespesas{ get; set; }
    }

   
}