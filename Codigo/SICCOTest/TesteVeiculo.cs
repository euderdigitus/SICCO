using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SICCO.Models;

namespace SICCOTest
{
    [TestClass()]
    public class TesteVeiculo
    {

        private static GerenciadorVeiculo ger = new GerenciadorVeiculo();
        

        [TestMethod()]
        public void TestarInsercaoDeVeiculo()
        {

            Veiculo veiculo = new Veiculo();
            veiculo.id = 1;
            veiculo.chassi = "SDE252D288D";
            veiculo.idBem = 1;
            veiculo.idCor = 2;
            veiculo.idEmpresa = 1;
            veiculo.idModelo = 2;
            veiculo.placa = "IAO7855";
            veiculo.lote = 0;
            ger.Inserir(veiculo);
            Veiculo atual = ger.Obter(1);
            Assert.AreEqual(veiculo,atual);
        }
        
        [TestMethod]
        public void TestarAtualizaoDeVeiculo()
        {
           Veiculo veiculo = ger.Obter(1);
            veiculo.placa = "IAO7844";
            ger.Atualizar(veiculo);
            Veiculo atual = ger.Obter(1);
            Assert.AreEqual(veiculo, atual);

        }
 
        [TestMethod]
        public void TestarObterModelo()
        {
            Veiculo veiculoBanco = ger.Obter(1);
            Veiculo veiculo = new Veiculo();
            veiculo.id = 1;
            veiculo.chassi = "SDE252D288D";
            veiculo.idBem = 1;
            veiculo.idCor = 2;
            veiculo.idEmpresa = 1;
            veiculo.idModelo = 2;
            veiculo.placa = "IAO7844";
            veiculo.lote = 0;
            Assert.AreEqual(veiculo, veiculoBanco);
        }

        [TestMethod]
        public void TestarRemoverModelo()
        {
            Veiculo veiculo = ger.Obter(1);
            ger.Remover(veiculo);
            veiculo = ger.Obter(1);
            Assert.IsNull(veiculo);
            
        }

        [TestMethod]
        public void TestarValidacaoDePlacaoVeiculoNacionalComValorCorreto()
        {
            bool result = ger.ValidaPLacaVeiculoNacional("IAO7844");
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void TestarValidacaoDePlacaoVeiculoNacionalComValorIncorreto()
        {
            bool result = ger.ValidaPLacaVeiculoNacional("IA57A44");
            Assert.IsFalse(result);
        }


    


    }
    }

