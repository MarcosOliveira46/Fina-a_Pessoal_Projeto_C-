using System;
using System.ComponentModel.DataAnnotations;

namespace Finance.Models
{
    public class Receita
    {
        [Key]
        public int ReceitaId { get; set; }
        [Display(Name = "Descrição")]
        public TipoReceita Receita_Nome { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Data")]
        public DateTime Data_Entrada { get; set; }

        [Display(Name = "Valor")]
        public double Receita_Valor { get; set; }
        public virtual TipoDespesa Tipo{ get; set; }
    }

    public enum TipoReceita
    {
        
        Salario,
        Extra
    }
}