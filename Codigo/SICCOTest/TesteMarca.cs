using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SICCO.Models;

namespace SICCOTest
{
    [TestClass]
    public class TesteMarca
    {

        private static GerenciadorMarca ger = new GerenciadorMarca();


        [TestMethod()]
        public void TestarInsercaoDeMarca()
        {

            Marca marca = new Marca();
            marca.id = 1;
            marca.marca = "WolksWagen";
            marca.tipo = "Nacional";
            ger.Inserir(marca);
            Marca atual = ger.Obter(1);
            Assert.Equals(marca, atual);
        }

        [TestMethod]
        public void TestarAtualizaoDeMarca()
        {
            Marca marca = ger.Obter(1);
            marca.marca = "GM";
            ger.Atualizar(marca);
            Marca atual = ger.Obter(1);
            Assert.AreEqual(marca, atual);

        }

        [TestMethod]
        public void TestarObterMarca()
        {
            Marca marcaBanco = ger.Obter(1);
            Marca marca = new Marca();
            marca.id = 1;
            marca.marca = "GM";
            marca.tipo = "Nacional";
            Assert.AreEqual(marca, marcaBanco);
        }

        [TestMethod]
        public void TestarRemoverMarca()
        {
            Marca marca = ger.Obter(1);
            ger.Remover(marca);
            marca = ger.Obter(1);
            Assert.IsNull(marca);

        }


        [TestMethod]
        public void TestarTipoDeMarcaPassandoValorCorreto()
        {
            bool result = ger.VerificaTipoMarca("Importada");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestarTipoDeMarcaPassandoValorIncorreto()
        {
            bool result = ger.VerificaTipoMarca("Nova");
            Assert.IsFalse(result);
        }

    }
}
