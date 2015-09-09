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
    public class GerenciadorCor
    {
        private static MySqlConnection conexao { get; set; }

        public void Inserir(Cor cor)
        {
            if (VerificaTipoCor(cor.tipoCor))
            {
                string consulta = "insert into tb_cor(id,tipoCor,cor) values(" + cor.codigo
                    + ",'" + cor.tipoCor + "','" + cor.descricao + "')";
                MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

                adapt.ExecuteNonQuery();

                FechaBanco();
            }
        }

        public Cor Obter(int id)
        {
            Cor cor = new Cor();
            string consulta = "select * from tb_cor where id =" + id;

            MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

            MySqlDataReader ler = adapt.ExecuteReader();

            if (ler.HasRows)
            {

                while (ler.Read())
                {
                    cor.codigo = (int)(ler["id"]);
                    cor.descricao = (string)(ler["cor"]);
                    cor.tipoCor = (string)(ler["tipoCor"]);
                }
            }
            else
            {
                cor = null;
            }

            FechaBanco();

            return cor;
        }

        public Boolean VerificaTipoCor(string tipo)
        {
            if (tipo.Equals("Metálica", StringComparison.OrdinalIgnoreCase) ||
                tipo.Equals("Comum", StringComparison.OrdinalIgnoreCase) ||
                tipo.Equals("Fosca", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Atualizar(Cor corAtual)
        {
            if (VerificaTipoCor(corAtual.tipoCor))
            {
                string consulta = "update tb_cor set cor ='" + corAtual.descricao + "', tipoCor ='" + corAtual.tipoCor + "' where id =" + corAtual.codigo;
                MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

                adapt.ExecuteNonQuery();

                FechaBanco();
            }
        }

        public void Remover(Cor cor)
        {

            string consulta = "delete from tb_cor where id =" + cor.codigo;
            MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

            adapt.ExecuteNonQuery();

            FechaBanco();
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