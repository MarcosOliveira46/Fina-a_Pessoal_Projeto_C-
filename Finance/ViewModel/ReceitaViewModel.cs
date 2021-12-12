using Finance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finance.ViewModel
{
    public class ReceitaViewModel
    {
        DataContext ctx = new DataContext();
        public ReceitaViewModel()
        {
            TipoDespesas = CarregaTipos("");
        }
        #region Propriedades
        public int ReceitaId { get; set; }
        public DateTime Data_Entrada { get; set; }
        public double Receita_Valor { get; set; }
        public int IdTipoDespesa { get; set; } 
        public List<SelectListItem> TipoDespesas { get; set; }
        #endregion

        #region Métodos
        public List<SelectListItem> CarregaTipos(string descricao)
        {
            var lista = new List<SelectListItem>();
            var tipos = ctx.TipoDespesas.ToList();

            try 
            {
                foreach(var item in tipos)
                {
                    var option = new SelectListItem()
                    {
                        Text = item.Descricao,
                        Value = item.Descricao,
                        Selected = (item.Descricao == descricao)
                    };
                    lista.Add(option);
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return lista;
        }
        #endregion
    }
}