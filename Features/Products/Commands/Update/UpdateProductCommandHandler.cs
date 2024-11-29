using CQRSProject.Persistence;
using MediatR;

namespace CQRSProject.Features.Products.Commands.Update
{
    public class UpdateProductCommandHandler(ApplicationDbContext context) : IRequestHandler<UpdateProductCommand, Guid>
    {
        public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FindAsync(request.Id);
            if (product == null) throw new ArgumentException($"Product with ID {request.Id} not found.");

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            await context.SaveChangesAsync(cancellationToken);

            return product.Id;

        }
    }
}
