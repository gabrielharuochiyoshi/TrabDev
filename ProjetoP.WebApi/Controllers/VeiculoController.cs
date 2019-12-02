using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoP.WebApi.Controllers.Model;
using ProjetoP.WebApi.Data;

namespace ProjetoP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase

    {
        public readonly DataContext _context;

        public VeiculoController(DataContext context)
    {
        _context = context;
    }

        //Veiculos dummy para teste
        Veiculo[] veiculos = new Veiculo[]
        {
            new Veiculo { Id = 1, Categoria = "Carro", Marca = "Fiat", Modelo = "Argo", AnoFabricacao = 2019, AnoModelo = 2020},
            new Veiculo { Id = 2, Categoria = "Carro", Marca = "Chevrolet", Modelo = "Onix", AnoFabricacao= 2018, AnoModelo = 2019},
            new Veiculo { Id = 3, Categoria = "Carro", Marca = "Hyundai", Modelo = "HB20", AnoFabricacao= 2019, AnoModelo = 2019}
        };

        //GET api/veiculo
        [HttpGet]
        public async Task<IActionResult> GetAllVeiculos()
        {
            try
            {
                var result = await _context.Veiculo.ToListAsync();
                return Ok(result);
            }
            catch (System.Exception)
            {
                var status500 = StatusCodes.Status500InternalServerError;
                var messageErro = "Erro no Banco de Dados";
                return this.StatusCode(status500, messageErro);
                throw;
            }
        }

        //GET api/veiculo/2
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVeiculoById(int id)
        {
            var veiculo = await _context.Veiculo.FirstOrDefaultAsync((v) => v.Id ==id);
            if (veiculo == null)
        {
            var status404 = StatusCodes.Status404NotFound;
            var messageError = "Não foi encontrado um veiculo com o Id = " + id;
            return this.StatusCode(status404, messageError);
        }
        return Ok(veiculo);
        }

        //GET api/veiculo/categoria/carro
        [HttpGet("categoria/{categoria}")]
        public async Task<IActionResult> GetVeiculosByCategoria(string categoria)
        {
            var veiculos = await _context.Veiculo.ToListAsync();
            var caterogias = veiculos.Where(
                (v) => string.Equals(v.Categoria, categoria,
                    StringComparison.OrdinalIgnoreCase));
            return Ok(categoria);
                    
            
        }

    }
}