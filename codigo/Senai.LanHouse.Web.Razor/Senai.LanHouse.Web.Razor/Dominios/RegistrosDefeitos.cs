using System;
using System.ComponentModel.DataAnnotations;

namespace Senai.LanHouse.Web.Razor.Dominios
{
    public partial class RegistrosDefeitos
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Informe uma data")]
        [Display(Name = "Data do Defeito")]
        public DateTime DataDefeito { get; set; }
        [Display(Name = "Tipo do Equipamento")]
        public int TipoEquipamentoId { get; set; }
        [Display(Name = "Tipo do Defeito")]
        public int TipoDefeitoId { get; set; }
        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Display(Name = "Tipo do Defeito")]
        public TiposDefeitos TipoDefeito { get; set; }

        [Display(Name = "Tipo do Equipamento")]
        public TiposEquipamentos TipoEquipamento { get; set; }
    }
}
