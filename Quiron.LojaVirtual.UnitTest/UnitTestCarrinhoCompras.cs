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
            #region [-- Arrange --]

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

        [TestMethod]
        public void AdicionarProdutoExistenteAoCarrinho()
        {
            #region [-- Arrange --]

            Produtos produto01 = new Produtos
            {
                ProdutoId = 1,
                Nome = "teste 1"
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
            carrinho.AdicionarItem(produto01, 7);

            ItensCarrinho[] itens = carrinho.ItensCarrinho.OrderBy(c => c.Produto.ProdutoId).ToArray();

            #endregion

            #region [-- Assert --]

            Assert.AreEqual(itens.Length, 3);
            Assert.AreEqual(itens[0].Produto, produto01);
            Assert.AreEqual(itens[1].Produto, produto02);
            Assert.AreEqual(itens[0].Quantidade, 9);

            #endregion
        }

        [TestMethod]
        public void RemoverItensCarrinho()
        {
            #region [-- Arrange --]

            Produtos produto01 = new Produtos
            {
                ProdutoId = 1,
                Nome = "teste 1"
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
            carrinho.AdicionarItem(produto01, 7);

            carrinho.RemoverItem(produto02);

            #endregion

            #region [-- Assert --]

            Assert.AreEqual(carrinho.ItensCarrinho.Where(c => c.Produto == produto02).Count(), 0);
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 2);

            #endregion
        }

        [TestMethod]
        public void CalcularVlorTotal()
        {
            #region [-- Arrange --]

            Produtos produto01 = new Produtos
            {
                ProdutoId = 1,
                Nome = "teste 1",
                Preco=100M
            };

            Produtos produto02 = new Produtos
            {
                ProdutoId = 2,
                Nome = "teste 2",
                Preco=50M
            };

            Carrinho carrinho = new Carrinho();

            #endregion

            #region [-- Action --]

            carrinho.AdicionarItem(produto01, 1);
            carrinho.AdicionarItem(produto02, 1);
            carrinho.AdicionarItem(produto01, 4);

            decimal? result = carrinho.ValorTotal();

            #endregion

            #region [-- Assert --]

            Assert.AreEqual(result, 550M);

            #endregion
        }

        [TestMethod]
        public void LimparItensCarrinho()
        {
            #region [-- Arrange --]

            Produtos produto01 = new Produtos
            {
                ProdutoId = 1,
                Nome = "teste 1",
                Preco = 100M
            };

            Produtos produto02 = new Produtos
            {
                ProdutoId = 2,
                Nome = "teste 2",
                Preco = 50M
            };

            Carrinho carrinho = new Carrinho();

            #endregion

            #region [-- Action --]

            carrinho.AdicionarItem(produto01, 1);
            carrinho.AdicionarItem(produto02, 1);
            carrinho.AdicionarItem(produto01, 4);

            decimal? result = carrinho.ValorTotal();

            carrinho.LimparCarrinho();

            #endregion

            #region [-- Assert --]

            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 0);

            #endregion
        }
    }
}
