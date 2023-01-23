using System;
using Application.DbContext;
using Domain.Responses;
using MediatR;

namespace Application.CQRS.GenderModule
{
	public class GenderDeleteCommand:IRequest<Response<int>>
	{
		public int Id { get; set; }

        public class GenderDeleteCommandHandler : IRequestHandler<GenderDeleteCommand, Response<int>>
        {
            private readonly AppDbContext db;

            public GenderDeleteCommandHandler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<Response<int>> Handle(GenderDeleteCommand request, CancellationToken cancellationToken)
            {
                var entity = db.Genders
                  .FirstOrDefault(m => m.Id == request.Id && m.DeletedDate == null);
                if (entity == null)
                {
                    return new Response<int>
                    {
                        StatusCode = 404,
                        Message = "Cant find"
                    };
                }

                entity.DeletedDate = DateTime.UtcNow.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);

                return new Response<int> { Message = "Silindi", StatusCode = 200 };
            }
        }
    }
}

