using System;
using Application.DbContext;
using Domain.Entities;
using Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.CategoryModule
{
    public class CategoryTreeQuery : IRequest<Response<ICollection<Category>>>
    {
        public class CategoryTreeQueryHandler : IRequestHandler<CategoryTreeQuery, Response<ICollection<Category>>>
        {
            private readonly AppDbContext db;

            public CategoryTreeQueryHandler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<Response<ICollection<Category>>> Handle(CategoryTreeQuery request, CancellationToken cancellationToken)
            {

                var data = await db.Categories
                 .Include(c => c.Parent)
                 .Where(c=>c.Children!=null)
                 .Include(c => c.Children.Where(c => c.DeletedDate == null))
                 .Where(c => c.DeletedDate == null)
                 .ToListAsync(cancellationToken);

                return new Response<ICollection<Category>> { Data = data, StatusCode = 200 };

            }
        }
    }
}

