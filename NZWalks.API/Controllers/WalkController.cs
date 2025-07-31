using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZwalks.Core.Domain.Entities;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Dtos;
using NZWalks.API.ServiceContracts;

namespace NZWalks.API.Controllers
{

    public class WalkController : BaseController
    {
        private readonly IServiceContract _serviceContract;
        private readonly IMapper _mapper;

        public WalkController(IServiceContract serviceContract, IMapper mapper)
        {
            _serviceContract = serviceContract;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("Add_New_Walk")]
        [ValidateModel]
        public async Task<IActionResult> CreateWalksAstnc(AddWalksDto addWalksDto)
        {
            var mapwalk = _mapper.Map<Walk>(addWalksDto);
            await _serviceContract.CreateWalkAsync(mapwalk);
            var resonpseModel = _mapper.Map<WalkResponseDto>(mapwalk);
            return Ok(resonpseModel);
        }

        [HttpGet]
        [Route("Fetching_all_walks")]
        public async Task<IActionResult> GetAllWalksAsync([FromQuery] string? filterOn, [FromQuery] string? filterBy, [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walksDomain = await _serviceContract.GetAllWalksAsync(filterOn, filterBy, sortBy, isAscending ?? true, pageNumber, pageSize);

            var responsewalks = _mapper.Map<List<WalkResponseDto>>(walksDomain);
            return Ok(responsewalks);
        }

        [Route("getWalkById/{walkid:Guid}")]
        [HttpGet]
        public async Task<IActionResult> GetWalkByID(Guid walkid)
        {
            var machingwalk = await _serviceContract.GetWalk(walkid);
            if (machingwalk == null)
            {
                return NotFound();
            }
            var responsewalk = _mapper.Map<WalkResponseDto>(machingwalk);
            return Ok(responsewalk);
        }
        [Route("update_walks/{walkid:Guid}")]
        [HttpPut]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalksAsync(Guid walkid, UpdateWalksDto updatewalksDto)
        {
            var mappingUpdateRequest = _mapper.Map<Walk>(updatewalksDto);

            var result = await _serviceContract.UpdateWalks(walkid, mappingUpdateRequest);
            var responsewalk = _mapper.Map<WalkResponseDto>(mappingUpdateRequest);

            return Ok(responsewalk);
        }


        [Route("delete_walk/{id:Guid}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteWalksAsync(Guid id)
        {
            var wasDeleted = await _serviceContract.DeleteWalksAsync(id);

            if (!wasDeleted)
            {
                return NotFound(new { Message = "Walk not found or already deleted." });
            }

            return Ok(new { Message = "Walk deleted successfully." });
        }

    }
}
