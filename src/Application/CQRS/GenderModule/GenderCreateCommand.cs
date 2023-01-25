using Application.AppCode.Extensions;
using Application.DbContext;
using Domain.Entities;
using Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Application.CQRS.GenderModule
{
    public class GenderCreateCommand :IRequest<Response<Gender>>
    {
        public string Name { get; set; } = null!;
        public string? ImageaPath { get; set; }
        public IFormFile? Image { get; set; }

        public class GenderCreateCommandHandler : IRequestHandler<GenderCreateCommand, Response<Gender>>
        {
            private readonly AppDbContext db;
            private readonly IHostEnvironment env;


            public GenderCreateCommandHandler(AppDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }

            public async Task<Response<Gender>> Handle(GenderCreateCommand request, CancellationToken cancellationToken)
            {
                Gender gender = new Gender();
                gender.Name = request.Name;
                if (request.Image!=null)
                {
                    gender.ImagePath = request.Image.GetRandomImagePath("product");
                    await env.SaveAsync(request.Image, gender.ImagePath, cancellationToken);
                }
                await db.Genders.AddAsync(gender, cancellationToken);

                await db.SaveChangesAsync(cancellationToken);

                return new Response<Gender> { StatusCode = 201, Message = "created", Data = gender };
            }
        }
    }
}
