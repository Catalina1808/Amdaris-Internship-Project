using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateReviewCommand;
using BookLoversProject.Application.Commands.Update.UpdateReviewCommand;
using BookLoversProject.Application.DTO.ReviewDTOs;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class ReviewProfile: Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewPutDTO, UpdateReviewCommand>();
            CreateMap<ReviewPostDTO, CreateReviewCommand>();
            CreateMap<Review, ReviewGetDTO>();
        }
    }
}
