using AutoMapper;
using MagicVilla.API.CustomActionFilters;
using MagicVilla.API.Models.Domains;
using MagicVilla.API.Models.DTOs;
using MagicVilla.API.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
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
        [Route("AllVilla")]
        [Authorize(Roles ="Writer,Reader")]
        // GET: /api/villa?filterOn=Name&filterQuery=Track&isAscending=true

        public async Task<IActionResult> GetAllVilla([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool?isAscending, [FromQuery]int pageNumber = 1, [FromQuery]int pageSize=100)
        {
            var villas = await villaRepository.GetAllAsync(filterOn,filterQuery,sortBy,isAscending??true,pageNumber,pageSize);
            return Ok(mapper.Map<List<VillaDto>>(villas));


        }
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles ="Writer,Reader")]

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
        [Authorize(Roles ="Writer")]

        public async Task<IActionResult> CreateVilla([FromBody] CreateVillaDto createVillaDto)
        {
            var villa = mapper.Map<Villa>(createVillaDto);
            await villaRepository.CreateVillaAsync(villa);
            return Ok(mapper.Map<VillaDto>(villa));
        }
        [HttpPut]
        [Route("{id}")]
        [ValidateModel]
        [Authorize(Roles ="Writer")]


        public async Task<IActionResult> UpdateVilla([FromRoute ]Guid id , [FromBody]UpdateVillaDto updateVillaDto)
        {
            var villa = mapper.Map<Villa>(updateVillaDto);
            var result =await villaRepository.UpdateVillaAsync(id, villa);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles ="Writer")]

        public async Task<IActionResult> DeleteVilla([FromRoute]Guid id)
        {
            var villa = await villaRepository.DeleteByIdAsync(id);
            if(villa is null)
            {
                return NotFound("Villa not found");
            }
            return Ok("Villa Deleted Successfuly");
        }

        [HttpDelete]
        [Authorize(Roles ="Writer")]

        public async Task<IActionResult> DeleteAllVilla()
        {
            await villaRepository.DeleteAllVillaAsync();
            return NoContent();
        }
        
    }
}
