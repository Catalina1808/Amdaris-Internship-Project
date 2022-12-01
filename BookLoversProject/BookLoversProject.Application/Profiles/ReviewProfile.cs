using AutoMapper;
using BookLoversProject.Application.Queries.GetReviewsByBookId;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class ReviewProfile: Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDTO>();
        }
    }
}
