using System;
using Application.AppCode.Extensions;
using Application.DbContext;
using Domain.Entities;
using Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Application.CQRS.CategoryModule
{
	public class CategoryCreateCommand :IRequest<Response<Category>>
	{

        public string Name { get; set; } = null!;
        public IFormFile Image { get; set; } = null!;
        public int? ParentId { get; set; }
        public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Response<Category>>
        {
            private readonly AppDbContext db;
            private readonly IHostEnvironment env;

            public CategoryCreateCommandHandler(IHostEnvironment env, AppDbContext db)
            {
                this.env = env;
                this.db = db;
            }

            public async Task<Response<Category>> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
            {
                var category = new Category
                {
                    Name = request.Name,
                };
                if (request.ParentId!=null)
                {
                    category.ParentId = request.ParentId;
                }
                category.ImagePath = request.Image.GetRandomImagePath("category");
                await env.SaveAsync(request.Image, category.ImagePath, cancellationToken);

                await db.AddAsync(category, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);

                return new Response<Category> { Data = category, Message = "Category created", StatusCode = 200 };
            }   
        }
    }
}

