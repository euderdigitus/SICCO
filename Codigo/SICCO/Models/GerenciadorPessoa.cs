using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SICCO.Database;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace SICCO.Models
{
    public class GerenciadorPessoa
    {
        private static MySqlConnection conexao { get; set; }

        public void Inserir(Pessoa pessoa)
        {
            string consulta = "insert into tb_pessoa() values(" + pessoa.id
                + ",'" + pessoa.nome + "','" + pessoa.sobreNome + "','" + pessoa.cpfCnpj +
                "','" + pessoa.rg + "','" + pessoa.email + "','" + pessoa.cidade +
                "','" + pessoa.estado + "','" + pessoa.cep + "','" + pessoa.fone +
                "','" + pessoa.celular + "','" + pessoa.sexo + "','" + pessoa.nascimento +
                "','" + pessoa.endereco + "','" + pessoa.idEmpresa + "','" + pessoa.idTipoPessoa + "')";
            MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

            adapt.ExecuteNonQuery();

            FechaBanco();

        }

        public Pessoa Obter(int id)
        {
            Pessoa pes = new Pessoa();
            string consulta = "select * from tb_pessoa where id =" + id;

            MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

            MySqlDataReader ler = adapt.ExecuteReader();

            if (ler.HasRows)
            {

                while (ler.Read())
                {
                    pes.id = (int)(ler["id"]);
                    pes.nome = (string)(ler["nome"]);
                    pes.celular = (string)(ler["celular"]);
                    pes.cep = (string)(ler["cep"]);
                    pes.cidade = (string)(ler["cidade"]);
                    pes.cpfCnpj = (string)(ler["cpfCnpj"]);
                    pes.email = (string)(ler["email"]);
                    pes.endereco = (string)(ler["endereco"]);
                    pes.estado = (string)(ler["estado"]);
                    pes.fone = (string)(ler["fone"]);
                    pes.idEmpresa = (int)(ler["idEmpresa"]);
                    pes.idTipoPessoa = (int)(ler["idTipoPessoa"]);
                    pes.nascimento = (string)(ler["nascimento"]);
                    pes.rg = (string)(ler["rg"]);
                    pes.sexo = (string)(ler["sexo"]);
                    pes.sobreNome = (string)(ler["sobreNome"]);
                }
            }
            else
            {
                pes = null;
            }

            FechaBanco();

            return pes;
        }



        public void Atualizar(Pessoa pes)
        {
            string consulta = "update tb_pessoa set nome ='" + pes.nome + "', sobreNome ='" + pes.sobreNome +
                "', cpfCnpj ='" + pes.cpfCnpj + "', rg ='" + pes.rg + "', email ='" + pes.email +
                "', cidade ='" + pes.cidade + "', estado ='" + pes.estado + "', cep ='" + pes.cep +
                "', fone ='" + pes.fone + "', celular ='" + pes.celular + "', sexo ='" + pes.sexo +
                "', nascimento ='" + pes.nascimento + "', endereco ='" + pes.endereco +
                "', idEmpresa =" + pes.idEmpresa + ", idTipoPessoa =" + pes.idTipoPessoa + " where id =" + pes.id;

            MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

            adapt.ExecuteNonQuery();

            FechaBanco();
        }

        public void Remover(Pessoa pes)
        {

            string consulta = "delete from tb_pessoa where id =" + pes.id;
            MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

            adapt.ExecuteNonQuery();

            FechaBanco();
        }


        public bool ValidaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }


        public static bool ValidaCnpj(string cnpj)
		{
			int[] multiplicador1 = new int[12] {5,4,3,2,9,8,7,6,5,4,3,2};
			int[] multiplicador2 = new int[13] {6,5,4,3,2,9,8,7,6,5,4,3,2};
			int soma;
			int resto;
			string digito;
			string tempCnpj;

			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

			if (cnpj.Length != 14)
			   return false;

			tempCnpj = cnpj.Substring(0, 12);

			soma = 0;
			for(int i=0; i<12; i++)
			   soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

			resto = (soma % 11);
			if ( resto < 2)
			   resto = 0;
			else
			   resto = 11 - resto;

			digito = resto.ToString();

			tempCnpj = tempCnpj + digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
			   soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

			resto = (soma % 11);
			if (resto < 2)
			    resto = 0;
			else
			   resto = 11 - resto;

			digito = digito + resto.ToString();

			return cnpj.EndsWith(digito);
		}


        public static MySqlConnection ConexaoBanco()
        {
            conexao = new MySqlConnection(@"server=localhost; user id=root; password=root; database=sicco");

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            return conexao;
        }

        public static void FechaBanco()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}