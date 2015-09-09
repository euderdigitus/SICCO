using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICCO.Models
{
    public class Pessoa
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobreNome { get; set; }
        public string cpfCnpj { get; set; }
        public string rg { get; set; }
        public string email { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
        public string fone { get; set; }
        public string celular { get; set; }
        public string sexo { get; set; }
        public string nascimento { get; set; }
        public string endereco { get; set; }
        public int idEmpresa { get; set; }
        public int idTipoPessoa { get; set; }

        public override bool Equals(Object obj)
        {
            if (obj is Object)
            {
                var that = obj as Pessoa;
                return this.id == that.id && this.celular == that.celular
                    && this.cep == that.cep && this.cidade == that.cidade
                    && this.cpfCnpj == that.cpfCnpj && this.email == that.email
                    && this.endereco == that.endereco && this.estado == that.estado
                    && this.fone == that.fone && this.idEmpresa == that.idEmpresa
                    && this.idTipoPessoa == that.idTipoPessoa && this.nascimento == that.nascimento
                    && this.nome == that.nome && this.rg == that.rg && this.sexo == that.sexo
                    && this.sobreNome == that.sobreNome;
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hashcode = id.GetHashCode();
            hashcode ^= nome.GetHashCode();
            hashcode ^= sobreNome.GetHashCode();
            hashcode ^= cpfCnpj.GetHashCode();
            hashcode ^= rg.GetHashCode();
            hashcode ^= email.GetHashCode();
            hashcode ^= cidade.GetHashCode();
            hashcode ^= estado.GetHashCode();
            hashcode ^= cep.GetHashCode();
            hashcode ^= fone.GetHashCode();
            hashcode ^= celular.GetHashCode();
            hashcode ^= sexo.GetHashCode();
            hashcode ^= nascimento.GetHashCode();
            hashcode ^= endereco.GetHashCode();
            hashcode ^= idEmpresa.GetHashCode();
            hashcode ^= idTipoPessoa.GetHashCode();

            return hashcode;
        }
    }
}