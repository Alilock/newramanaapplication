using Application.AppCode.Extensions;
using Application.DbContext;
using Domain.Entities;
using Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.GenderModule
{
    public class GenderCreateCommand :IRequest<Response<Gender>>

    {
        public string Name { get; set; } = null!;
        public string? ImageaPath { get; set; }
        public IFormFile? Imaage { get; set; }

        public class GenderCreateCommandHandler : IRequestHandler<GenderCreateCommand, Response<Gender>>
        {
            private readonly AppDbContext db;

            public GenderCreateCommandHandler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<Response<Gender>> Handle(GenderCreateCommand request, CancellationToken cancellationToken)
            {
                Gender gender = new Gender();
                gender.Name = request.Name;
                if (gender.ImagePath!=null)
                {
                    request.ImageaPath = request.Imaage?.GetRandomImagePath("product");
                }
                await db.Genders.AddAsync(gender, cancellationToken);

                await db.SaveChangesAsync(cancellationToken);

                return new Response<Gender> { StatusCode = 201, Message = "created", Data = gender };

            }
        }
    }
}
