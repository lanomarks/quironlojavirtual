using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidade;
using System.Diagnostics;
using System.Linq;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTestCarrinhoCompras
    {

        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {
            #region [-- Arrande --]

            Produtos produto01 = new Produtos
               {
                   ProdutoId=1,
                   Nome="teste 1"
               };

            Produtos produto02 = new Produtos
            {
                ProdutoId = 2,
                Nome = "teste 2"
            };

            Produtos produto03 = new Produtos
            {
                ProdutoId = 3,
                Nome = "teste 3"
            };

            Carrinho carrinho = new Carrinho();

            #endregion

            #region [-- Action --]

            carrinho.AdicionarItem(produto01, 2);
            carrinho.AdicionarItem(produto02, 3);
            carrinho.AdicionarItem(produto03, 5);

            ItensCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            #endregion

            #region [-- Assert --]

            Assert.AreEqual(itens.Length, 3);
            Assert.AreEqual(itens[0].Produto, produto01);
            Assert.AreEqual(itens[1].Produto, produto02);

            #endregion
        }
    }
}
