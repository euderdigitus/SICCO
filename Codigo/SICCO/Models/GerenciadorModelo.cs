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
    public class GerenciadorModelo
    {
        private static MySqlConnection conexao { get; set; }

        public void Inserir(Modelo modelo)
        {
            if (VerificaTipoModelo(modelo.tipoModelo))
            {
                string consulta = "insert into tb_modelo() values(" + modelo.id
                    + ",'" + modelo.categoiaModelo + "','" + modelo.tipoModelo +
                    "','" + modelo.descricao + "','" + modelo.anoModelo +
                    "'," + modelo.idMarca + "," + modelo.idTipoCompustivel + ")";

                MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

                adapt.ExecuteNonQuery();

                FechaBanco();
            }
        }

        public Modelo Obter(int id)
        {
            Modelo modelo = new Modelo();
            string consulta = "select * from tb_modelo where id =" + id;

            MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

            MySqlDataReader ler = adapt.ExecuteReader();

            if (ler.HasRows)
            {

                while (ler.Read())
                {
                    modelo.id = (int)(ler["id"]);
                    modelo.descricao = (string)(ler["descricao"]);
                    modelo.anoModelo = (string)(ler["anoModelo"]);
                    modelo.categoiaModelo = (string)(ler["categoiaModelo"]);
                    modelo.idMarca = (int)(ler["idMarca"]);
                    modelo.idTipoCompustivel = (int)(ler["idTipoCompustivel"]);
                    modelo.tipoModelo = (string)(ler["tipoModelo"]);
                }
            }
            else
            {
                modelo = null;
            }

            FechaBanco();

            return modelo;
        }

        public Boolean VerificaTipoModelo(string tipo)
        {
            if (tipo.Equals("Nacional", StringComparison.OrdinalIgnoreCase) ||
                tipo.Equals("Importado", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Atualizar(Modelo modelo)
        {
            if (VerificaTipoModelo(modelo.tipoModelo))
            {
                string consulta = "update tb_modelo set descricao ='" + modelo.descricao + "', categoiaModelo ='" + modelo.categoiaModelo
                    + "', tipoModelo = '" + modelo.tipoModelo + "', anoModelo = '" + modelo.anoModelo +
                    "', idMarca = " + modelo.idMarca + ", idTipoCompustivel = " + modelo.idTipoCompustivel + " where id =" + modelo.id;
                MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

                adapt.ExecuteNonQuery();

                FechaBanco();
            }
        }

        public void Remover(Modelo modelo)
        {

            string consulta = "delete from tb_modelo where id =" + modelo.id;
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