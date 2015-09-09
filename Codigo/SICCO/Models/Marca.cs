using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICCO.Models
{
    public class Marca
    {
        public int id { get; set; }
        public string marca { get; set; }
        public string tipo { get; set; }


        public override bool Equals(Object obj)
        {
            if (obj is Object)
            {
                var that = obj as Marca;
                return this.id == that.id && this.marca == that.marca
                    && this.tipo == that.tipo;
            }
            return false;
        }
        
        public override int GetHashCode()
        {
            var hashcode = id.GetHashCode();
            hashcode ^= marca.GetHashCode();
            hashcode ^= tipo.GetHashCode();
            return hashcode;
        }
    }
}