using CQRSProject.Features.Products.DTOs;
using CQRSProject.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace CQRSProject.Features.Products.Queries.List
{
    public class ListProductsQueryHandler(ApplicationDbContext context) : IRequestHandler<ListProductsQuery, List<ProductDto>>
    {
        public async Task<List<ProductDto>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            return await context.Products
                .Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price))
                .ToListAsync();
        }
    }
}
