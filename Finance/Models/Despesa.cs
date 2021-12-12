using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Models
{
    public class Despesa
    {
        
        [Key]
        public int Despesa_Id { get; set; }

       
        public DateTime Data_Despesa { get; set; }
        public double  Despesa_Valor { get; set; }
        public TipoDespesa TipoDespesas{ get; set; }
    }

   
}