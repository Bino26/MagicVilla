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
        [ValidateModel]

        public async Task<IActionResult> AddVillaNumber([FromBody]AddVillaNumberDto addVillaNumberDto)
        {
            var villa = mapper.Map<VillaNumber>(addVillaNumberDto);
            var result = await villaNumberRepository.AddDetailsAsync(villa);
            return Ok(mapper.Map<VillaNumberDto>(result));

        }
        [HttpGet]
        public async Task<IActionResult> GetAllVillaDetails()
        {
            var villa =await  villaNumberRepository.GetAllDetailsAsync();
            return Ok(mapper.Map<List<VillaNumberDto>>(villa));
        }
        [HttpGet]
        [Route("{no}")]

        public async Task<IActionResult> GetVillaDetailsByNo([FromRoute]int no)
        {
            var villa = await villaNumberRepository.GetVillaDetailsByNoAsync(no);
            return Ok(mapper.Map<VillaNumberDto>(villa));
        }
        [HttpPut]
        [Route("{no}")]
        [ValidateModel]

        public async Task<IActionResult> UpdateVillaDetails([FromRoute]int no, [FromBody]UpdateVillaNumberDto updateVillaNumberDto)
        {
            var villaDetails = mapper.Map<VillaNumber>(updateVillaNumberDto);
            var result = await villaNumberRepository.UpdateDetailsAsync(no, villaDetails); ;
            return Ok(result);

        }
    }
}
