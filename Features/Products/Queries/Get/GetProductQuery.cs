using CQRSProject.Features.Products.DTOs;
using MediatR;

namespace CQRSProject.Features.Products.Queries.Get
{
    public record GetProductQuery(Guid Id) : IRequest<ProductDto>;
}
