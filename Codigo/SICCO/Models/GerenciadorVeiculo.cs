using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SICCO.Database;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace SICCO.Models
{
    public class GerenciadorVeiculo
    {
        private static MySqlConnection conexao { get; set; }

        public void Inserir(Veiculo veiculo)
        {
            if (ValidaPLacaVeiculoNacional(veiculo.placa))
            {
                string consulta = "insert into tb_veiculo() values(" + veiculo.id
                    + ", '" + veiculo.placa + "' , '" + veiculo.chassi + "' ," + veiculo.idModelo + "," + veiculo.idCor +
                    "," + veiculo.idBem + "," + veiculo.idEmpresa + "," + veiculo.lote + ")";

                MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

                adapt.ExecuteNonQuery();

                FechaBanco();
            }
        }

        public Veiculo Obter(int id)
        {
            Veiculo veiculo = new Veiculo();
            string consulta = "select * from tb_veiculo where id =" + id;

            MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

            MySqlDataReader ler = adapt.ExecuteReader();

            if (ler.HasRows)
            {

                while (ler.Read())
                {
                    veiculo.id = (int)(ler["id"]);
                    veiculo.placa = (string)(ler["placa"]);
                    veiculo.idBem = (int)(ler["idBem"]);
                    veiculo.idCor = (int)(ler["idCor"]);
                    veiculo.idEmpresa = (int)(ler["idEmpresa"]);
                    veiculo.idModelo = (int)(ler["idModelo"]);
                    veiculo.chassi = (string)(ler["chassi"]);
                    veiculo.lote = (int)(ler["lote"]);
                }
            }
            else
            {
                veiculo = null;
            }

            FechaBanco();

            return veiculo;
        }



        public void Atualizar(Veiculo veiculo)
        {
            if (ValidaPLacaVeiculoNacional(veiculo.placa))
            {
                string consulta = "update tb_veiculo set placa ='" + veiculo.placa + "', chassi ='" + veiculo.chassi
                    + "', idModelo = " + veiculo.idModelo + ", idCor = " + veiculo.idCor +
                    ", idBem = " + veiculo.idBem + ", idEmpresa = " + veiculo.idEmpresa +
                    ", lote = " + veiculo.lote + " where id =" + veiculo.id;
                MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

                adapt.ExecuteNonQuery();

                FechaBanco();
            }
        }

        public void Remover(Veiculo veiculo)
        {

            string consulta = "delete from tb_veiculo where id =" + veiculo.id;
            MySqlCommand adapt = new MySqlCommand(consulta, ConexaoBanco());

            adapt.ExecuteNonQuery();

            FechaBanco();
        }

        public bool ValidaPLacaVeiculoNacional(string value)
        {
            Regex regex = new Regex(@"^[a-zA-Z]{3}\d{4}$");

            if (regex.IsMatch(value))
            {
                return true;
            }

            return false;
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