using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Mvc;
using YouSearch.API.Models;
using YouSearch.Dominio.Entidades;
using YouSearch.Dominio.Interfaces.Servicos.Domain;

namespace YouSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisaController : ControllerBase
    {
        private ISearchResponseServico servico;
        private readonly IMapper mapper;

        public PesquisaController(ISearchResponseServico _servico, IMapper _mapper)
        {
            this.servico = _servico;
            this.mapper = _mapper;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<Retorno>> GetAsync(string termo, string PageToken = null)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyBhfVPYjLm2u4YTJzPW_5dySny5u8LzOog",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = termo;
            searchListRequest.MaxResults = 50;

            if(!string.IsNullOrEmpty(PageToken))
                searchListRequest.PageToken = PageToken;

            var searchListResponse = await searchListRequest.ExecuteAsync();

            Retorno retorno = new Retorno();
            retorno.ProximaPagina = searchListResponse.NextPageToken;

            foreach (var searchResult in searchListResponse.Items)
            {
                var search = mapper.Map<SearchResponse>(searchResult);


                retorno.Dados.Add(new Dados()
                    {
                        Descricao = search.Snippet.Description,
                        Imagem = search.Snippet.Thumbnails.High.Url,
                        Tipo = searchResult.Id.Kind,
                        Titulo = search.Snippet.Title
                    }
                );

                //await servico.AddAsync(search);
            }
            return retorno;
        }
    }
}