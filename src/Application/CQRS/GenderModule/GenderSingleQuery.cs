using System;
using Application.DbContext;
using Domain.Entities;
using Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.GenderModule
{
	public class GenderSingleQuery: IRequest<Response<Gender>>
	{
		public int Id { get; set; }

        public class GenderSingleQueryHandler : IRequestHandler<GenderSingleQuery, Response<Gender>>
        {
            private readonly AppDbContext db;

            public GenderSingleQueryHandler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<Response<Gender>> Handle(GenderSingleQuery request, CancellationToken cancellationToken)
            {
                var data =await db.Genders.Where(g => g.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
                var response = new Response<Gender>();  
                if (data==null)
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

