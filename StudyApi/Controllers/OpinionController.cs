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

        [HttpGet("opinions/{idOpinion}")]
        public async Task<ActionResult<ResponseModel<OpinionModel>>> SearchOpinionById(int idOpinion)
        {
            var opinions = await _opinionInterface.SearchOpinionById(idOpinion);
            return Ok(opinions);

        }
        [HttpGet("opinions/{uUsername}")]
        public async Task<ActionResult<ResponseModel<OpinionModel>>> SearchOpinionByUserUsername(string uUsername)
        {
            var opinions = await _opinionInterface.SearchOpinionByUserUsername(uUsername);
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
        public async Task<ActionResult<ResponseModel<List<OpinionModel>>>> DeleteOpinion(int idOpinion)
        {
            var opinions = await _opinionInterface.DeleteOpinion(idOpinion);
            return Ok(opinions);

        }
    }
}