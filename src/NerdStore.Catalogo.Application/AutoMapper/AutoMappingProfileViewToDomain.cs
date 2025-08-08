﻿using AutoMapper;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class AutoMappingProfileViewToDomain : Profile
    {
        public AutoMappingProfileViewToDomain()
        {
            CreateMap<ProdutoViewModel, Produto>()
                .ConstructUsing(p => new Produto( p.Nome,
                    p.Descricao,
                    p.Ativo,
                    p.Valor,
                    p.CategoriaId,
                    p.DataCadastro,
                    p.Imagem,
                    new Dimensoes(p.Altura, p.Largura, p.Profundidade)));

            CreateMap<CategoriaViewModel, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));
        }
    }

}
