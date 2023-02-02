using System;
using Application.AppCode.Extensions;
using Application.DbContext;
using Domain.Entities;
using Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Application.CQRS.ProductModule
{
	public class ProductCreateCommand :IRequest<Response<Product>>
	{
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int StockKeepingUnit { get; set; }
        public decimal? Price { get; set; }
        public int CategoryId { get; set; }
        public ICollection<IFormFile>? Images { get; set; }
		public int GenderId { get; set; }
		public int[]? MaterialIds { get; set; }
		public int[]? ColorIds { get; set; } 

        public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Response<Product>>
        {
            private readonly AppDbContext db;
            private readonly IHostEnvironment env;

            public ProductCreateCommandHandler(AppDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }

            public async Task<Response<Product>> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
            {
                var product = new Product();
                product.Name = request.Name;
                product.Description = request.Description;
                product.CategoryId = request.CategoryId;
                product.GenderId = request.GenderId;
                product.Price = request.Price;
                product.StockKeepingUnit = request.StockKeepingUnit;
                if (request.MaterialIds != null)
                {
                    product.Materials = new List<ProductMaterials>();
                    foreach (var item in request.MaterialIds)
                    {
                        product.Materials.Add(new()
                        {
                            MaterialId = item,
                            Product = product
                        });
                    }
                }
                if (request.ColorIds != null)
                {
                    product.Colors = new List<ProductColors>();
                    foreach (var item in request.ColorIds)
                    {
                        product.Colors.Add(new()
                        {
                            ColorId = item,
                            Product = product
                        });
                    }
                }

                    List<ProductImage> images = new List<ProductImage>();
                if (request.Images!=null)
                {
                    foreach (var image in request.Images)
                    {
                        string path = image.GetRandomImagePath("product");
                        await env.SaveAsync(image, path, cancellationToken);
                        images.Add(new() { Path = path, ProductId = product.Id});
                    }
                }
                product.Images = images;
                await db.AddAsync(product, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);

                return new Response<Product> { Data = product, StatusCode = 200, Message = "created" };
            }
        }
    }
}

