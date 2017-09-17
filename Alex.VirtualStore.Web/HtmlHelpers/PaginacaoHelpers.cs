using System;
using System.Text;
using System.Web.Mvc;
using Alex.VirtualStore.Web.Models;

namespace Alex.VirtualStore.Web.HtmlHelpers
{
    public static class PaginacaoHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, Paginacao paginacao, Func<int, string> paginaUrl)
        {
            var resultado = new StringBuilder();

            for (int i = 0; i < paginacao.TotalPagina; i++)
            {
                var tag = new TagBuilder("a");

                tag.MergeAttribute("href", paginaUrl(i));

                tag.InnerHtml = i.ToString();

                if (i == paginacao.PaginaAtual)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }

                tag.AddCssClass("btn btn-default");
                resultado.Append(tag);
            }

            return MvcHtmlString.Create(resultado.ToString());
        }
    }
}