using AutoMapper;
using YouSearch.Dominio.Entidades;

namespace YouSearch.API.Mapeamentos
{
    public class MapeamentoProfile : Profile
    {
        public MapeamentoProfile()
        {
            CreateMap<Google.Apis.YouTube.v3.Data.SearchResult, SearchResponse>().
                ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<SearchResponse, Google.Apis.YouTube.v3.Data.SearchResult>().
                ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Google.Apis.YouTube.v3.Data.SearchResultSnippet, SearchResultSnippet>().
                ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<SearchResultSnippet, Google.Apis.YouTube.v3.Data.SearchResultSnippet>();

            CreateMap<Google.Apis.YouTube.v3.Data.ThumbnailDetails, ThumbnailDetails>().
                ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<ThumbnailDetails, Google.Apis.YouTube.v3.Data.ThumbnailDetails>();

            CreateMap<Google.Apis.YouTube.v3.Data.Thumbnail, Thumbnail>().
                ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Thumbnail, Google.Apis.YouTube.v3.Data.Thumbnail>();
        }
    }
}
