using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyApi.Dto;
using StudyApi.Models;
using StudyApi.Services.Opinion;

namespace StudyApi.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class OpinionController : ControllerBase
    {
        private readonly IOpinionInterface _opinionInterface;

        public OpinionController(IOpinionInterface opinionInterface)
        {
            _opinionInterface = opinionInterface;
        }

        [HttpGet("opinions")]
        public async Task<ActionResult<ResponseModel<List<OpinionModel>>>> ListOpinions()
        {
            var opinions = await _opinionInterface.ListOpinions();
            return Ok(opinions);
        }

        [HttpGet("opinions/id/{id}")]
        public async Task<ActionResult<ResponseModel<OpinionModel>>> SearchOpinionById(int id)
        {
            var opinions = await _opinionInterface.SearchOpinionById(id);
            return Ok(opinions);

        }
        [HttpGet("opinions/user/{username}")]
        public async Task<ActionResult<ResponseModel<OpinionModel>>> SearchOpinionByUserUsername(string username)
        {
            var opinions = await _opinionInterface.SearchOpinionByUserUsername(username);
            return Ok(opinions);

        }

        [HttpPost("opinions")]
        public async Task<ActionResult<ResponseModel<List<OpinionModel>>>> CreateUser(OpinionDto OpinionDto)
        {
            var opinions = await _opinionInterface.CreateOpinion(OpinionDto);
            return Ok(opinions);
        }

        [HttpPut("opinions")]
        public async Task<ActionResult<ResponseModel<List<OpinionModel>>>> EditOpinion(EditOpinionDto EditOpinionDto)
        {
            var opinions = await _opinionInterface.EditOpinion(EditOpinionDto);
            return Ok(opinions);
        }

        [HttpDelete("opinions")]
        public async Task<ActionResult<ResponseModel<List<OpinionModel>>>> DeleteOpinion(int id)
        {
            var opinions = await _opinionInterface.DeleteOpinion(id);
            return Ok(opinions);

        }
    }
}