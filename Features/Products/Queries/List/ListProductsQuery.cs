using CQRSProject.Features.Products.DTOs;
using MediatR;

namespace CQRSProject.Features.Products.Queries.List
{
    public record ListProductsQuery : IRequest<List<ProductDto>>;
}
