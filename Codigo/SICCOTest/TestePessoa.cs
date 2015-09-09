using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SICCO.Models;

namespace SICCOTest
{
    [TestClass]
    public class TestePessoa
    {
       static GerenciadorPessoa ger = new GerenciadorPessoa();
        [TestMethod()]
        public void TestarInsercaoDePessoa()
        {

            Pessoa pessoa = new Pessoa();
            pessoa.id = 1;
            pessoa.celular = "7998584251";
            pessoa.cep = "4916000";
            pessoa.cidade = "Aracaju";
            pessoa.cpfCnpj = "05874125897";
            pessoa.email = "guivitu93@gmail.com";
            pessoa.endereco = "Av: L";
            pessoa.estado = "SE";
            pessoa.idEmpresa = 1;
            pessoa.idTipoPessoa = 1;
            pessoa.nascimento = "29/06/1993";
            pessoa.nome = "Guilherme";
            pessoa.rg = "34205445";
            pessoa.sexo = "M";
            pessoa.fone = "225478";
            pessoa.sobreNome = "Alves";
            ger.Inserir(pessoa);
            Pessoa atual = ger.Obter(1);
            Assert.AreEqual(pessoa, atual);
        }

        [TestMethod]
        public void TestarAtualizaoDePessoa()
        {
            Pessoa pessoa = ger.Obter(1);
            pessoa.nome = "Guilherme Bruno";
            pessoa.sobreNome = "Viturino Alves";
            ger.Atualizar(pessoa);
            Pessoa atual = ger.Obter(1);
            Assert.AreEqual(pessoa, atual);

        }

        [TestMethod]
        public void TestarObterPessoa()
        {
            Pessoa pessoaBanco = ger.Obter(1);
            Pessoa pessoa = new Pessoa();
            pessoa.id = 1;
            pessoa.celular = "7998584251";
            pessoa.cep = "4916000";
            pessoa.cidade = "Aracaju";
            pessoa.cpfCnpj = "05874125897";
            pessoa.email = "guivitu93@gmail.com";
            pessoa.endereco = "Av: L";
            pessoa.estado = "SE";
            pessoa.idEmpresa = 1;
            pessoa.idTipoPessoa = 1;
            pessoa.fone = "225478";
            pessoa.nascimento = "29/06/1993";
            pessoa.nome = "Guilherme Bruno";
            pessoa.rg = "34205445";
            pessoa.sexo = "M";
            pessoa.sobreNome = "Viturino Alves";
            Assert.AreEqual(pessoa, pessoaBanco);
        }

        [TestMethod]
        public void TestarRemoverPessoa()
        {
            Pessoa pes = ger.Obter(1);
            ger.Remover(pes);
            pes = ger.Obter(1);
            Assert.IsNull(pes);

        }


       [TestMethod]
        public void TestarValidacaoDeCpfPassandoCpfCorreto()
        {
            bool result = ger.ValidaCpf("05055816554");
            Assert.IsTrue(result);

        }

       [TestMethod]
       public void TestarValidacaoDeCpfPassandoCpfIncorreto()
       {
           bool result = ger.ValidaCpf("05055816553");
           Assert.IsFalse(result);

       }
        /*
       [TestMethod]
       public void TestarValidacaoDeCnpjPassandoCnpjCorreto()
       {
           bool result = ger.ValidaCpf("10409486000170");
           Assert.IsTrue(result);

       }

       [TestMethod]
       public void TestarValidacaoDeCnpjPassandoCnpjIncorreto()
       {
           bool result = ger.ValidaCpf("86647883000152");
           Assert.IsFalse(result);

       }*/

    }
}
