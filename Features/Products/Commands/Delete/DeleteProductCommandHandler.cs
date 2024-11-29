using CQRSProject.Persistence;
using MediatR;
using System;

namespace CQRSProject.Features.Products.Commands.Delete
{
    public class DeleteProductCommandHandler(ApplicationDbContext context) : IRequestHandler<DeleteProductCommand, Guid>
    {
        public async Task<Guid> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FindAsync(request.Id);
            if (product == null) throw new ArgumentException($"Product with ID {request.Id} not found.");
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return product.Id;
        }
    }
}
