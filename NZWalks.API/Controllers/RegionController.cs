
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZwalks.Core.Domain.Entities;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Dtos;
using NZWalks.API.ServiceContracts;
using System.Text.Json;

namespace NZWalks.API.Controllers
{

    public class RegionController : BaseController
    {
        private readonly IServiceContract _Contact;
        private readonly IMapper _mapper;
        private readonly ILogger<RegionController> _logger;

        public RegionController(IServiceContract contact, IMapper mapper, ILogger<RegionController> logger)
        {
            _Contact = contact;
            _mapper = mapper;
            _logger = logger;
        }

        [Route("Retrive_all_Regions")]
        [HttpGet]
        //[Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetAllRegions()
        {
            try
            {
                _logger.LogInformation("Get All Regions Actions Method was Invoked");
                var regions = await _Contact.GetAllRegions();
                if (regions == null)
                {
                    return NotFound();
                }

                _logger.LogInformation($"Finishd GetAllRegions request with data: {JsonSerializer.Serialize(regions)}");

                var regionresp = _mapper.Map<List<RegionResponse>>(regions);

                return Ok(regionresp);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw;

            }

        }


        [HttpPost("EnterRegion")]
        [ValidateModel]
        //  [Authorize(Roles = "Writer")]
        public async Task<IActionResult> AddRegion([FromBody] AddRegionDto addRegionDto)
        {
            if (ModelState.IsValid)
            {

                var regions = _mapper.Map<Region>(addRegionDto);

                await _Contact.AddRegion(regions);

                return Ok(regions);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet("region/{regionid:Guid}")]
        // [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid regionid)
        {

            var regions = await _Contact.GetRegionById(regionid);
            if (regions == null)
            {
                return NotFound();
            }

            if (regions == null)
            {
                return NotFound();
            }
            var region = _mapper.Map<AddRegionDto>(regions);
            return Ok(region);
        }

        [HttpPut]
        // [Authorize(Roles = "Writer")]
        [Route("updateRegion/{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDto updateRegionDto)
        {
            if (ModelState.IsValid)
            {

                var region = await _Contact.GetRegionById(id);
                if (region == null)
                {
                    return NotFound();
                }
                region.RegionImageUrl = updateRegionDto.RegionImageUrl;
                region.Code = updateRegionDto.Code;
                region.Name = updateRegionDto.Name;
                await _Contact.UpdateRegion(region);
                AddRegionDto regionUpdate = new AddRegionDto
                {
                    Name = updateRegionDto.Name,
                    Code = updateRegionDto.Code,
                    RegionImageUrl = updateRegionDto.RegionImageUrl

                };
                return Ok(regionUpdate);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpDelete("Delete_Region/{regionid:Guid}")]
        // [Authorize(Roles = "Writer")]
        public async Task<IActionResult> RevomeRegion(Guid regionid)
        {
            var regiond = await _Contact.DeleteRegion(regionid);
            if (!regiond)
            {
                return NotFound(new { Message = "region has be deleted or not found" });
            }
            return Ok(new { Message = "Region deleted sucessfully" });
        }
    }
}
