using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SICCO.Models;

namespace SICCOTest
{
    [TestClass()]
    public class TesteModelo
    {

        private static GerenciadorModelo ger = new GerenciadorModelo();
        

        [TestMethod()]
        public void TestarInsercaoDeModelo()
        {

            Modelo modelo = new Modelo();
            modelo.id = 1;
            modelo.descricao = "Pálio Weekend 1.4";
            modelo.anoModelo = "2010/2010";
            modelo.categoiaModelo = "Carro";
            modelo.idMarca = 2;
            modelo.idTipoCompustivel = 1;
            modelo.tipoModelo = "Nacional";
            ger.Inserir(modelo);
            Modelo atual = ger.Obter(1);
            Assert.AreEqual(modelo,atual);
        }
        
        [TestMethod]
        public void TestarAtualizaoDeModelo()
        {
            Modelo modelo = ger.Obter(1);
            modelo.descricao = "Palio Weekend 1.8";
            ger.Atualizar(modelo);
            Modelo atual = ger.Obter(1);
            Assert.AreEqual(modelo, atual);

        }
 
        [TestMethod]
        public void TestarObterModelo()
        {
            Modelo modeloBanco = ger.Obter(1);
            Modelo modelo = new Modelo();
            modelo.id = 1;
            modelo.descricao = "Palio Weekend 1.8";
            modelo.anoModelo = "2010/2010";
            modelo.categoiaModelo = "Carro";
            modelo.idMarca = 2;
            modelo.idTipoCompustivel = 1;
            modelo.tipoModelo = "Nacional";
            Assert.AreEqual(modelo, modeloBanco);
        }

        [TestMethod]
        public void TestarRemoverModelo()
        {
            Modelo modelo = ger.Obter(1);
            ger.Remover(modelo);
            modelo = ger.Obter(1);
            Assert.IsNull(modelo);
            
        }


        [TestMethod]
        public void TestarTipoDeModeoPassandoValorCorreto()
        {
            bool result = ger.VerificaTipoModelo("Nacional");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestarTipoDeCorPassandoValorIncorreto()
        {
            bool result = ger.VerificaTipoModelo("Nova");
            Assert.IsFalse(result);
        }


    }
    }

