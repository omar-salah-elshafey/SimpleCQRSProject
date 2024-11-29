using CQRSProject.Domain;
using CQRSProject.Persistence;
using MediatR;
using System;

namespace CQRSProject.Features.Products.Commands.Create
{
    public class CreateProductCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product(command.Name, command.Description, command.Price);
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return product.Id;
        }
    }
}
