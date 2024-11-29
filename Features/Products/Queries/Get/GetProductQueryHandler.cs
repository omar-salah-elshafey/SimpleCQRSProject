using CQRSProject.Features.Products.DTOs;
using CQRSProject.Persistence;
using MediatR;

namespace CQRSProject.Features.Products.Queries.Get
{
    public class GetProductQueryHandler(ApplicationDbContext context)
    : IRequestHandler<GetProductQuery, ProductDto?>
    {
        public async Task<ProductDto?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FindAsync(request.Id);
            if (product == null) throw new ArgumentException($"Product with ID {request.Id} not found.");
            return new ProductDto(product.Id, product.Name, product.Description, product.Price);
        }
    }
}
