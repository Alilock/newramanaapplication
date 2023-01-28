using System;
using Application.DbContext;
using Domain.Entities;
using Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.CategoryModule
{
	public class CategoryAllQuery:IRequest<Response<ICollection<Category>>>
	{
        public class CategoryAllQueryHandler : IRequestHandler<CategoryAllQuery, Response<ICollection<Category>>>
        {
            private readonly AppDbContext db;

            public CategoryAllQueryHandler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<Response<ICollection<Category>>> Handle(CategoryAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Categories.Include(c=>c.Parent)
               .Where(m => m.DeletedDate == null)
               .ToListAsync(cancellationToken);

                return new Response<ICollection<Category>> { Data = data, StatusCode = 200 };
            }

         
        }
    }
}

