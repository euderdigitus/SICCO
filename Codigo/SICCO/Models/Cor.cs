using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using SICCO.Database;

namespace SICCO.Models
{
    public class Cor
    {


        public int codigo { get; set; }
        public string descricao { get; set; }
        public string tipoCor { get; set; }



        public override bool Equals(Object obj)
        {
            if (obj is Object)
            {
                var that = obj as Cor;
                return this.codigo == that.codigo && this.descricao == that.descricao
                    && this.tipoCor == that.tipoCor;
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hashcode = codigo.GetHashCode();
            hashcode ^= descricao.GetHashCode();
            hashcode ^= tipoCor.GetHashCode();
            return hashcode;
        }


    }



}
