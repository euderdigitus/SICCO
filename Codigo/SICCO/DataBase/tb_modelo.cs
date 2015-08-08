//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SICCO.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class tb_modelo
    {
        public tb_modelo()
        {
            this.tb_veiculo = new HashSet<tb_veiculo>();
        }
    
        public int id { get; set; }
        [Required(ErrorMessage = "O preenchimento deste campo � obrigat�rio")]
        public string categoiaModelo { get; set; }
        [Required(ErrorMessage = "O preenchimento deste campo � obrigat�rio")]
        public string tipoModelo { get; set; }
        [Required(ErrorMessage = "O preenchimento deste campo � obrigat�rio")]
        public string descricao { get; set; }
        [Required(ErrorMessage = "O preenchimento deste campo � obrigat�rio")]
        public string anoModelo { get; set; }
        public int idMarca { get; set; }
        public int idTipoCompustivel { get; set; }
    
        public virtual tb_marca tb_marca { get; set; }
        public virtual tb_tipocombustivel tb_tipocombustivel { get; set; }
        public virtual ICollection<tb_veiculo> tb_veiculo { get; set; }
    }
}
