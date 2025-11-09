using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Examen.Entity.DTOs;
using Examen.Entity.Entities;
using Examen.Entity.Interfaces;

namespace Examen.Business.Services
{
    public class ArticuloService: IArticuloService
    {
        private readonly IArticuloRepository _articuloRepository;
        private readonly IMapper _mapper;

        public ArticuloService(IArticuloRepository articuloRepository, IMapper mapper)
        {
            _articuloRepository = articuloRepository;
            _mapper = mapper;
        }

        public async Task<ArticuloResponseDto> CreateArticleAsync(CrearArticuloDto crearArticuloDto)
        {
            var articulo = new Articulo
            {
                Codigo = crearArticuloDto.Codigo,
                Descripcion = crearArticuloDto.Descripcion,
                Precio = crearArticuloDto.precio,
                Stock = crearArticuloDto.stock
            };

            var createArticle = await _articuloRepository.CreateAsync(articulo);

            List<ArticuloTienda> articuloTiendas = new List<ArticuloTienda>();

            foreach (var item in crearArticuloDto.TiendasIDs)
            {
                articuloTiendas.Add(new ArticuloTienda { ArticuloID = createArticle.Id, TiendaID =item, Fecha=DateTime.Now });
            }

            await _articuloRepository.CreateAsyncArticuloTienda(articuloTiendas);

            return _mapper.Map<ArticuloResponseDto>(createArticle);
        }

        public async Task<ArticuloResponseDto> GetArticleByIdAsync(int id)
        {
            var articulo = await _articuloRepository.GetByIdAsync(id);

            if (articulo == null)
                throw new KeyNotFoundException($"Artículo no encontrado");

            return _mapper.Map<ArticuloResponseDto>(articulo);
        }

        public async Task<IEnumerable<ArticleTiendaResponseDto>> getTiendasArticulo(int id)
        {
            var articuloT = await _articuloRepository.getTiendasArticulo(id);

            if (articuloT == null)
                throw new KeyNotFoundException($"Artículo no encontrado");

            return _mapper.Map<IEnumerable<ArticleTiendaResponseDto>>(articuloT);
        }

        public async Task updateTiendasArticulo(List<ArticleTiendaResponseDto> conjunto)
        {
            await _articuloRepository.updateTiendasArticulo(conjunto);
        }



        public async Task<IEnumerable<ArticuloResponseDto>> GetAllArticlesAsync()
        {
            var articulos = await _articuloRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ArticuloResponseDto>>(articulos);
        }

        public async Task DeleteArticleByIdAsync(int id)
        {
            await _articuloRepository.DeleteAsync(id);
        }

        public async Task UpdateArticleByIdAsync(Articulo articulo)
        {
            await _articuloRepository.UpdateAsync(articulo);
        }

        public async Task<IEnumerable<TiendaResponseDto>> GetStoresByArticleIdAsync(int id)
        {
            var tiendas = await _articuloRepository.GetStoresByArticleIdAsync(id);
            return _mapper.Map<IEnumerable<TiendaResponseDto>>(tiendas);
        }


    }
}
