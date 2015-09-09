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
    public class GerenciadorMarca
    {
        private static MySqlConnection conexao { get; set; }

        public void Inserir(Marca marca)
        {
            if (VerificaTipoMarca(marca.tipo))
            {
                string consulta = "insert into tb_marca() values(" + marca.id
                    + ",'" + marca.tipo + "','" + marca.marca + "')";
                MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

                adapt.ExecuteNonQuery();

                FechaBanco();
            }
        }

        public Marca Obter(int id)
        {
            Marca marca = new Marca();
            string consulta = "select * from tb_marca where id =" + id;

            MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

            MySqlDataReader ler = adapt.ExecuteReader();

            if (ler.HasRows)
            {

                while (ler.Read())
                {
                    marca.id = (int)(ler["id"]);
                    marca.marca = (string)(ler["marca"]);
                    marca.tipo = (string)(ler["tipo"]);
                }
            }
            else
            {
                marca = null;
            }

            FechaBanco();

            return marca;
        }

        public Boolean VerificaTipoMarca(string tipo)
        {
            if (tipo.Equals("Importada", StringComparison.OrdinalIgnoreCase) ||
                tipo.Equals("Nacional", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Atualizar(Marca marca)
        {
            if (VerificaTipoMarca(marca.tipo))
            {
                string consulta = "update tb_marca set marca ='" + marca.marca + "', tipo ='" + marca.tipo + "' where id =" + marca.id;
                MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

                adapt.ExecuteNonQuery();

                FechaBanco();
            }
        }

        public void Remover(Marca marca)
        {

            string consulta = "delete from tb_marca where id =" + marca.id;
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