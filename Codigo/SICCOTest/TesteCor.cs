using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SICCO.Models;

namespace SICCOTest
{
    [TestClass()]
    public class TesteCor
    {

        private static GerenciadorCor ger = new GerenciadorCor();
        

        [TestMethod()]
        public void TestarInsercaoDeCor()
        {
            
            Cor cor = new Cor();
            cor.codigo = 4;
            cor.descricao = "Laranja";
            cor.tipoCor = "Comum";
            ger.Inserir(cor);
            Cor atual = ger.Obter(4);
            Assert.AreEqual(cor,atual);
        }
        
        [TestMethod]
        public void TestarAtualizaoDeCor()
        {
            Cor cor = ger.Obter(4);
            cor.descricao = "Azul";
            cor.tipoCor = "Metálica";
            ger.Atualizar(cor);
            Cor atual = ger.Obter(4);
            Assert.AreEqual(cor, atual);

        }
 
        [TestMethod]
        public void TestarObterCor()
        {
            Cor corBanco = ger.Obter(4);
            Cor cor = new Cor();
            cor.codigo = 4;
            cor.descricao = "Azul";
            cor.tipoCor = "Metálica";
            Assert.AreEqual(cor, corBanco);
        }

        [TestMethod]
        public void TestarRemoverCor()
        {
            Cor cor = ger.Obter(4);
            ger.Remover(cor);
            cor = ger.Obter(4);
            Assert.IsNull(cor);
            
        }


        [TestMethod]
        public void TestarTipoDeCorPassandoValorCorreto()
        {
            bool result = ger.VerificaTipoCor("Metálica");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestarTipoDeCorPassandoValorIncorreto()
        {
            bool result = ger.VerificaTipoCor("Nova");
            Assert.IsFalse(result);
        }


    }
    }

