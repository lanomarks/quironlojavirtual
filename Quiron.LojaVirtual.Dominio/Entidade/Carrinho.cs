using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class Carrinho
    {
        private readonly List<ItensCarrinho> _itensCarrinho = new List<ItensCarrinho>();

        #region [-- Adicionar --]

        public void AdicionarItem(Produtos produto, int quantidade)
        {
            var item = _itensCarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            if (item == null)
            {
                _itensCarrinho.Add(new ItensCarrinho
                    {
                        Produto = produto,
                        Quantidade = quantidade
                    });
            }
            else
            {
                item.Quantidade += quantidade;
            }
        }

        #endregion

        #region [-- Remover --]

        public void RemoverItem(Produtos produto)
        {
            _itensCarrinho.RemoveAll(l => l.Produto.ProdutoId == produto.ProdutoId);
        }

        #endregion

        #region [-- Valor Total --]

        public decimal? ValorTotal()
        {
            return _itensCarrinho.Sum(e => e.Produto.Preco * e.Quantidade);
        }

        #endregion

        #region [-- Limpar Carrinho --]

        public void LimparCarrinho()
        {
            _itensCarrinho.Clear();
        }

        #endregion

        #region [-- Itens do Carrinho --]

        public IEnumerable<ItensCarrinho> ItensCarrinho
        {
            get
            {
                return _itensCarrinho;
            }
        }

        #endregion
    }
}
