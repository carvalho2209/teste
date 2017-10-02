using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Alex.VirtualStore.Dominio.Entidades;
using Alex.VirtualStore.Dominio.Repositorio;
using Alex.VirtualStore.Web.Models;

namespace Alex.VirtualStore.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutosRepositorio _produtosRepositorio;

        public RedirectToRouteResult Adicionar(int produtoId, string returnUrl)
        {
            _produtosRepositorio = new ProdutosRepositorio();

            Produto produto = _produtosRepositorio.Produtos.FirstOrDefault(v => v.ProdutoId == produtoId);

            if (produto != null)
            {
                ObterCarrinho().AdicionarItem(produto, 1);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        private Carrinho ObterCarrinho()
        {
            var carrinho = (Carrinho) Session["carrinho"];

            if (carrinho == null)
            {
                carrinho = new Carrinho();
                Session["carrinho"] = carrinho;
            }

            return carrinho;
        }

        public RedirectToRouteResult Remover(int produtoId, string returnUrl)
        {
            _produtosRepositorio = new ProdutosRepositorio();

            var produto = _produtosRepositorio.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto != null)
            {
                ObterCarrinho().RemoverItem(produto);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        public ViewResult Index(string returnurl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = ObterCarrinho(),
                ReturnUrl = returnurl
            });
        }

        public PartialViewResult Resumo()
        {
            var carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }


        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }

        [HttpPost]
        public ViewResult FecharPedido(Pedido pedido)
        {
            var carrinho = ObterCarrinho();

            EmailConfiguracoes email = new EmailConfiguracoes
            {
                EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"] ?? "false")
            };

            EmailPedido emailPedido = new EmailPedido(email);

            if (!carrinho.ItemCarrinhos.Any())
            {
                ModelState.AddModelError("", "Não foi possível concluir o pedido, seu carrinho está vazio!");
            }

            if (ModelState.IsValid)
            {
                emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }
            else
            {
                return View(pedido);
            }
        }

        public ViewResult PedidoConcluido()
        {
            return View();
        }
    }
}