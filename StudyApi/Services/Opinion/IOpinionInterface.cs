using StudyApi.Dto;
using StudyApi.Models;

namespace StudyApi.Services.Opinion
{
    public interface IOpinionInterface
    {
        Task<ResponseModel<List<OpinionModel>>> ListOpinions();
        Task<ResponseModel<OpinionModel>> SearchOpinionById(int idOpinion);
        Task<ResponseModel<List<OpinionModel>>> SearchOpinionByUserUsername(string uUsername);
        Task<ResponseModel<List<OpinionModel>>> CreateOpinion(OpinionDto OpinionDto);

        Task<ResponseModel<List<OpinionModel>>> EditOpinion(EditOpinionDto EditOpinionDto);
        Task<ResponseModel<List<OpinionModel>>> DeleteOpinion(int idOpinion);
    }
}
