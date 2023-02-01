using System;
using Application.CQRS.GenderModule;
using Application.DbContext;
using Domain.Entities;
using Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.MaterialModule
{
	public class MaterialAllQuery : IRequest<Response<ICollection<Material>>>
	{
        public class MaterialAllQueryHandler : IRequestHandler<MaterialAllQuery, Response<ICollection<Material>>>
        {
            private readonly AppDbContext db;

            public MaterialAllQueryHandler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<Response<ICollection<Material>>> Handle(MaterialAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Materials.Where(g => g.DeletedDate == null).ToListAsync(cancellationToken);
                var response = new Response<ICollection<Material>>();

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

