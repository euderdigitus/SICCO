using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICCO.Models
{
    public class Modelo
    {
        public int id { get; set; }
        public string categoiaModelo { get; set; }
        public string tipoModelo { get; set; }
        public string descricao { get; set; }
        public string anoModelo { get; set; }
        public int idMarca { get; set; }
        public int idTipoCompustivel { get; set; }



        public override bool Equals(Object obj)
        {
            if (obj is Object)
            {
                var that = obj as Modelo;
                return this.id == that.id && this.descricao == that.descricao
                    && this.anoModelo == that.anoModelo && this.categoiaModelo == that.categoiaModelo
                    && this.idMarca == that.idMarca && this.idTipoCompustivel == that.idTipoCompustivel
                    && this.tipoModelo == that.tipoModelo;
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hashcode = id.GetHashCode();
            hashcode ^= descricao.GetHashCode();
            hashcode ^= anoModelo.GetHashCode();
            hashcode ^= categoiaModelo.GetHashCode();
            hashcode ^= idMarca.GetHashCode();
            hashcode ^= idTipoCompustivel.GetHashCode();
            hashcode ^= tipoModelo.GetHashCode();
            return hashcode;
        }
    }
}