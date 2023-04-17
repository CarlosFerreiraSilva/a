using AngleSharp.Html.Parser;
using CoderCarrer.Domain;
using CoderCarrer.Models;
using HtmlAgilityPack;
using static System.Net.WebRequestMethods;
using MySql.Data.MySqlClient;
using AngleSharp.Dom;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using CoderCarrer.Context;

namespace CoderCarrer.DAL
{
    public class TrabalhaBrasilDAO : IExtratorVaga
    {
        private readonly Contexto _context;

        public TrabalhaBrasilDAO(Contexto context)
        {
            _context = context;
        }

        List<Vaga> _lista;
        public List<Vaga> getVagas()
        {
            ExtrairDados().Wait();
            return _lista;
        }

        private async Task<List<Vaga>> ExtrairDados()
        {

            var parser = new HtmlParser();
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync("https://www.trabalhabrasil.com.br/");
            var document = await parser.ParseDocumentAsync(content);
            var doc = new HtmlDocument();
            doc.LoadHtml(document.DocumentElement.OuterHtml);


            var body = doc.DocumentNode.SelectSingleNode("/html/body");
            var titulo = body.SelectNodes("//h2[contains(@class, 'job__name')]").Select(x => x.InnerText.Trim());
            var salario = body.SelectNodes("//h3[contains(@class, 'job__detail')]").Select(x => x.InnerText.Trim());
            var empresa = body.SelectNodes("//h3[contains(@class, 'job__company')]").Select(x => x.InnerText.Trim());
            var descricao = body.SelectNodes("//p[contains(@class, 'job__description')]").Select(x => x.InnerText.Trim());
            var url = doc.DocumentNode.SelectNodes("//a[contains(@class, 'job__vacancy   highlighted ')]").Select(x => x.GetAttributeValue("href", ""));
            //string empresastring = empresaras;
            //string descricaostring = descricao;
            //string salariostring= detalhe;

            //IEnumerable<string> minhaColecao = new List<string> { $"{descricao}", $"{detalhe}", $"{empresaras}" };
            //string empresa = minhaColecao.LastOrDefault();  
            //string detalhe = minhaColecao.LastOrDefault();
            //string destrincaotxt = minhaColecao.FirstOrDefault();

            //IEnumerable<string> minhaColecao = new List<string> { $"{empresaras}" ,$"{descricao}", $"{detalhe}"};
            //string detalhestring = string.Join(",", minhaColecao);








            _lista = new List<Vaga>();

                for (int i = 0; i < titulo.Count(); i++)
                {
                    Vaga newVaga = new Vaga();

                    newVaga.titulo = titulo.ToArray()[i];
                    newVaga.empresa = empresa.ToArray()[i];
                    newVaga.descricao_vaga = descricao.ToArray()[i];
                    newVaga.salario = salario.ToArray()[i];
                    newVaga.url = "https://www.trabalhabrasil.com.br/" + url.ToArray()[i];

                    _lista.Add(newVaga);
      
                    _context.Add(newVaga);
                    _context.SaveChangesAsync();

                }

                return _lista;


        }




    }
}