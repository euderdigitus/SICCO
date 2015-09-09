using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    class Cor
    {
        public Cor(string descricao)
        {
            this.descricao = descricao;
        }

        public int codigo { get; set; }
        public string descricao { get; set; }
    }
}
