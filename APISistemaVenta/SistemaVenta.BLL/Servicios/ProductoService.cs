using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.Model;

namespace SistemaVenta.BLL.Servicios
{
    public class ProductoService : IProductoService
    {
        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;

        public ProductoService(IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<ProductoDTO> Crear(ProductoDTO modelo)
        {
            try
            {
                var productoCreado = await _productoRepository.Crear(_mapper.Map<Producto>(modelo));

                if (productoCreado.IdProducto == 0)
                    throw new TaskCanceledException("No se pudo crear el producto");

                return _mapper.Map<ProductoDTO>(productoCreado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Editar(ProductoDTO modelo)
        {
            try
            {
                var productoModelo = _mapper.Map<Producto>(modelo);
                var productoEncontrado = await _productoRepository.Obtener(x => x.IdProducto == productoModelo.IdProducto);

                if (productoEncontrado == null)
                    throw new TaskCanceledException("El producto no existe");

                productoEncontrado.Nombre = productoModelo.Nombre;
                productoEncontrado.Idcategoria = productoModelo.Idcategoria;
                productoEncontrado.Stock = productoModelo.Stock;
                productoEncontrado.Precio = productoModelo?.Precio;
                productoEncontrado.EsActivo = productoModelo?.EsActivo;

                bool respuesta = await _productoRepository.Editar(productoEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar el producto");

                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var productoEncotnrado = await _productoRepository.Obtener(x => x.IdProducto == id);
                if (productoEncotnrado == null) throw new TaskCanceledException("El producto no existe");

                bool respuesta = await _productoRepository.Eliminar(productoEncotnrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar el producto");

                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<ProductoDTO>> Lista()
        {
            try
            {
                var queryProducto = await _productoRepository.Consultar();
                var listaProductos = queryProducto.Include(categoria => categoria.IdcategoriaNavigation).ToList();

                return _mapper.Map<List<ProductoDTO>>(listaProductos).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
