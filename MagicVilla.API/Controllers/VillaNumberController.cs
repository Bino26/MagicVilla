using AutoMapper;
using MagicVilla.API.Models.Domains;
using MagicVilla.API.Models.DTOs;
using MagicVilla.API.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        private readonly IVillaNumberRepository villaNumberRepository;
        private readonly IMapper mapper;

        public VillaNumberController(IVillaNumberRepository villaNumberRepository, IMapper mapper)
        {
            this.villaNumberRepository = villaNumberRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("AddVillaNumber")]

        public async Task<IActionResult> AddVillaNumber(AddVillaNumberDto addVillaNumberDto)
        {
            var villa = mapper.Map<VillaNumber>(addVillaNumberDto);
            var result = await villaNumberRepository.AddNumberAsync(villa);
            return Ok(mapper.Map<VillaNumberDto>(result));
        }
        [HttpGet]

        public async Task<IActionResult> GetVillaNumber()
        {
            var villa = villaNumberRepository.GetAllNumbersAsync();
            return Ok(mapper.Map<List<VillaNumberDto>>(villa));
        }
        [HttpGet]

        public async Task<IActionResult> GetVillaNumberById(int id)
        {
            var villa = await villaNumberRepository.GetVillaNumberByIdAsync(id);
            return Ok(mapper.Map<VillaNumberDto>(villa));
        }
    }
}
