using MediatR;

namespace CQRSProject.Features.Products.Commands.Delete
{
    public record DeleteProductCommand(Guid Id) : IRequest<Guid>;
}
