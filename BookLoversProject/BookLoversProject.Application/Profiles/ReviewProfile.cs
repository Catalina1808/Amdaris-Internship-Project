using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateReviewCommand;
using BookLoversProject.Application.Commands.Update.UpdateReviewCommand;
using BookLoversProject.Application.DTO;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class ReviewProfile: Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewPutPostDTO, UpdateReviewCommand>();
            CreateMap<ReviewPutPostDTO, CreateReviewCommand>();
            CreateMap<Review, ReviewGetDTO>();
        }
    }
}
