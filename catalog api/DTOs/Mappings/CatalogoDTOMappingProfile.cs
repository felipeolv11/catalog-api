using AutoMapper;
using catalog_api.Models;

namespace catalog_api.DTOs.Mappings;

public class CatalogoDTOMappingProfile : Profile
{
    public CatalogoDTOMappingProfile()
    {
        CreateMap<Produto, ProdutoDTO>().ReverseMap();
        CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        CreateMap<Produto, ProdutoDTOUpdateRequest>().ReverseMap();
        CreateMap<Produto, ProdutoDTOUpdateResponse>().ReverseMap();
    }
}
