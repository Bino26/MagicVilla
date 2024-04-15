using AutoMapper;
using MagicVilla.API.CustomActionFilters;
using MagicVilla.API.Models.Domains;
using MagicVilla.API.Models.DTOs;
using MagicVilla.API.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly IVillaRepository villaRepository;
        private readonly IMapper mapper;

        public VillaController(IVillaRepository villaRepository, IMapper mapper)
        {
            this.villaRepository = villaRepository;
            this.mapper = mapper;
        }


        [HttpGet]

        public async Task<IActionResult> GetVilla()
        {
            var villas = await villaRepository.GetAllAsync();
            return Ok(mapper.Map<List<VillaDto>>(villas));


        }
        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetVillaById([FromRoute]Guid id)
        {
            var villa = await villaRepository.GetByIdAsync(id);
            if(villa is null)
            {
                return NotFound("Villa not found");
            }
           return Ok( mapper.Map<VillaDto>(villa));
        }
        [HttpPost]
        [Route("createvilla")]
        [ValidateModel]

        public async Task<IActionResult> CreateVilla([FromBody] CreateVillaDto createVillaDto)
        {
            var villa = mapper.Map<Villa>(createVillaDto);
            await villaRepository.CreateVillaAsync(villa);
            return Ok(mapper.Map<VillaDto>(villa));
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> DeleteVilla([FromRoute]Guid id)
        {
            var villa = await villaRepository.DeleteByIdAsync(id);
            if(villa is null)
            {
                return NotFound("Villa not found");
            }
            return Ok("User Deleted Successfuly");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteAllVilla()
        {
            await villaRepository.DeleteAllVillaAsync();
            return NoContent();
        }
        
    }
}
