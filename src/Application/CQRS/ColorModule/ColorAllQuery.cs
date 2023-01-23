using Application.DbContext;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ColorModule
{
    public class ColorAllQuery:IRequest<ICollection<Color>>
    {
        public class ColorAllQueryHandler : IRequestHandler<ColorAllQuery, ICollection<Color>>
        {
            private readonly AppDbContext _db;
            public ColorAllQueryHandler(AppDbContext db)
            {
                _db = db;
            }
            public async Task<ICollection<Color>> Handle(ColorAllQuery request, CancellationToken cancellationToken)
            {
                var data =await _db.Colors.Where(c => c.DeletedDate == null).ToListAsync(cancellationToken);
                return data;
            }
        }
    }
}
