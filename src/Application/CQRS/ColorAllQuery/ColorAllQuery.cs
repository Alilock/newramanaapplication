using System;
using Application.CQRS.ColorModule;
using Application.DbContext;
using Domain.Entities;
using Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ColorAllQuery
{
	public class ColorAllQuery :IRequest<Response<ICollection<Color>>>
	{
        public class ColorAllQueryHandler : IRequestHandler<ColorAllQuery, Response<ICollection<Color>>>
        {
            private readonly AppDbContext db;

            public ColorAllQueryHandler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<Response<ICollection<Color>>> Handle(ColorAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Colors.Where(g => g.DeletedDate == null).ToListAsync(cancellationToken);
                var response = new Response<ICollection<Color>>();

                if (data == null)
                {
                    response.StatusCode = 404;
                    response.Message = "NotFound";
                    return response;
                }

                response.StatusCode = 200;
                response.Message = "Ok";
                response.Data = data;
                return response;

            }
        }
    }
}

