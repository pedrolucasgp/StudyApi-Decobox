using Microsoft.EntityFrameworkCore;
using StudyApi.Data;
using StudyApi.Dto;
using StudyApi.Models;

namespace StudyApi.Services.Opinion
{
    public class OpinionService : IOpinionInterface
    {
        private readonly AppDbContext _context;
        public OpinionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<OpinionModel>>> CreateOpinion(OpinionDto OpinionDto)
        {
            ResponseModel<List<OpinionModel>> response = new ResponseModel<List<OpinionModel>>();

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == OpinionDto.User.Id);

                if (user == null)
                {
                    response.Message = "User not found";
                    response.Status = false;
                    return response;
                }

                var opinion = new OpinionModel()
                {
                    Title = OpinionDto.Title,
                    Feedback = OpinionDto.Feedback,
                    Rating = OpinionDto.Rating,
                    User = user
                };

                _context.Add(opinion);
                await _context.SaveChangesAsync();

                response.Data = await _context.Opinions.Include(u => u.User).ToListAsync();
                response.Message = "Opinion successfully created";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<OpinionModel>>> DeleteOpinion(int idOpinion)
        {
            ResponseModel<List<OpinionModel>> response = new ResponseModel<List<OpinionModel>>();

            try
            {
                var opinion = await _context.Opinions.FirstOrDefaultAsync(x => x.Id == idOpinion);


                if (opinion == null)
                {
                    response.Message = "Opinion not found";
                    response.Status = false;
                    return response;
                }

                _context.Remove(opinion);
                await _context.SaveChangesAsync();

                response.Data = await _context.Opinions.ToListAsync();
                response.Message = "Opinion successfully deleted";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<OpinionModel>>> EditOpinion(EditOpinionDto EditOpinionDto)
        {
            ResponseModel<List<OpinionModel>> response = new ResponseModel<List<OpinionModel>>();

            try
            {
                var opinion = await _context.Opinions.Include(u => u.User).FirstOrDefaultAsync(x => x.Id == EditOpinionDto.Id);

                if (opinion == null)
                {
                    response.Message = "Opinion not found";
                    response.Status = false;
                    return response;
                }

                opinion.Title = EditOpinionDto.Title;
                opinion.Feedback = EditOpinionDto.Feedback;
                opinion.Rating = EditOpinionDto.Rating;

                _context.Update(opinion);
                await _context.SaveChangesAsync();

                response.Data = await _context.Opinions.ToListAsync();
                response.Message = "Opinion successfully created";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<OpinionModel>>> ListOpinions()
        {
            ResponseModel<List<OpinionModel>> response = new ResponseModel<List<OpinionModel>>();

            try
            {
                var opinions = await _context.Opinions.Include(u => u.User).ToListAsync();

                response.Data = opinions;
                response.Message = "All opinions have been loaded";

                return response;


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<OpinionModel>> SearchOpinionById(int idOpinion)
        {
            ResponseModel<OpinionModel> response = new ResponseModel<OpinionModel>();
            try
            {
                var opinion = await _context.Opinions.Include(u => u.User).FirstOrDefaultAsync(x => x.Id == idOpinion);

                if (opinion == null)
                {
                    response.Message = "Opinion not found";
                    response.Status = false;

                    return response;
                }

                response.Data = opinion;
                response.Message = "Opinion found";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<OpinionModel>>> SearchOpinionByUserUsername(string uUsername)
        {
            ResponseModel<List<OpinionModel>> response = new ResponseModel<List<OpinionModel>>();
            try
            {
                var opinion = await _context.Opinions.Include(u => u.User).Where(o => o.User.Username == uUsername).ToListAsync();

                if (opinion == null)
                {
                    response.Message = "Opinion not found";
                    response.Status = false;

                    return response;
                }

                response.Data = opinion;
                response.Message = "Opinion found";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
