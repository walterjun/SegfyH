using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Mvc;
using YouSearch.Dominio.Entidades;
using YouSearch.Dominio.Interfaces.Servicos.Domain;

namespace YouSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ISearchResponseServico servico;
        private readonly IMapper mapper;

        public ValuesController(ISearchResponseServico _servico, IMapper _mapper)
        {
            this.servico = _servico;
            this.mapper = _mapper;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync(string termo, string PageToken = null)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyBhfVPYjLm2u4YTJzPW_5dySny5u8LzOog",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = termo; // Replace with your search term.
            searchListRequest.MaxResults = 50;

            if(!string.IsNullOrEmpty(PageToken))
                searchListRequest.PageToken = PageToken;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<string> listaRetorno = new List<string>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                var resposta = mapper.Map<SearchResponse>(searchResult);

                listaRetorno.Add(JsonSerializer.Serialize(searchResult));

                await servico.AddAsync(resposta);
            }
            return listaRetorno;
        }
    }
}