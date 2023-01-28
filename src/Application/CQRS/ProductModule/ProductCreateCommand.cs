//using System;
//using Application.AppCode.Extensions;
//using Application.DbContext;
//using Domain.Entities;
//using Domain.Responses;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Hosting;

//namespace Application.CQRS.ProductModule
//{
//	public class ProductCreateCommand :IRequest<Response<Product>>
//	{
//		public string Name { get; set; } = string.Empty;
//		public string Description { get; set; } = string.Empty;
//		public int StockKeepingUnit { get; set; }
//        public decimal? Price { get; set; }
//        public int CategoryId { get; set; }

//        public ICollection<IFormFile>? Images { get; set; }
//		public int GenderId { get; set; }
//		public ICollection<int> MaterialIds { get; set; } = null!;
//		public ICollection<int> ColorIds { get; set; } = null!;

//        public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Response<Product>>
//        {
//            private readonly AppDbContext db;
//            private readonly IHostEnvironment env;

//            public ProductCreateCommandHandler(AppDbContext db, IHostEnvironment env)
//            {
//                this.db = db;
//                this.env = env;
//            }

//            public async Task<Response<Product>> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
//            {
//                var product = new Product();
//                product.Name = request.Name;
//                product.Description = request.Description;
//                product.CategoryId = request.CategoryId;
//                product.GenderId = request.GenderId;

//                if (request.MaterialIds != null)
//                {
//                    product.Materials = new List<ProductMaterials>();
//                    foreach (var item in product.Materials)
//                    {
//                        product.Materials.Add(new()
//                        {
//                            MaterialId = item.MaterialId,
//                            Product = product
//                        });
//                    }
//                }
//                if (request.ColorIds != null)
//                {
//                    product.Colors = new List<ProductColors>();
//                    foreach (var item in product.Colors)
//                    {
//                        product.Colors.Add(new()
//                        {
//                            ColorId = item.ColorId,
//                            Product = product
//                        });
//                    }
//                }

//                if (request.Images!=null)
//                {
//                    foreach (var image in request.Images)
//                    {
//                        product.ImagePath = image.GetRandomImagePath("category");
//                        await env.SaveAsync(image, category.ImagePath, cancellationToken);
//                    }

//                }

//                await db.AddAsync(product, cancellationToken);
//                await db.SaveChangesAsync(cancellationToken);

//                return new Response<Product> { Data = product, StatusCode = 200, Message = "created" };
//            }
//        }
//    }
//}

