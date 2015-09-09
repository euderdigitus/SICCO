using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICCO.Models
{
    public class Veiculo
    {
        public int id { get; set; }
        public string placa { get; set; }
        public string chassi { get; set; }
        public int idModelo { get; set; }
        public int idCor { get; set; }
        public int idBem { get; set; }
        public int idEmpresa { get; set; }
        public Nullable<int> lote { get; set; }


        public override bool Equals(Object obj)
        {
            if (obj is Object)
            {
                var that = obj as Veiculo;
                return this.id == that.id && this.chassi == that.chassi
                    && this.idBem == that.idBem
                    && this.idCor == that.idCor && this.idEmpresa == that.idEmpresa
                    && this.idModelo == that.idModelo && this.lote == that.lote && this.placa == that.placa;
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hashcode = id.GetHashCode();
            hashcode ^= chassi.GetHashCode();
            hashcode ^= idBem.GetHashCode();
            hashcode ^= idCor.GetHashCode();
            hashcode ^= idEmpresa.GetHashCode();
            hashcode ^= idModelo.GetHashCode();
            hashcode ^= lote.GetHashCode();
            hashcode ^= placa.GetHashCode();
            return hashcode;
        }
    }
}