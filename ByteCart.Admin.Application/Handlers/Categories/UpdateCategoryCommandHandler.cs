using ByteCart.Admin.Application.Commands.Categories;
using ByteCart.Admin.Application.Interfaces;
using MediatR;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryEntity = await _context.Categories.FindAsync(request.Id);
        if (categoryEntity == null)
        {
            return false;
        }

        categoryEntity.Name = request.Name;
        categoryEntity.Description = request.Description;
        categoryEntity.ParentCategoryId = request.ParentCategoryId;
        categoryEntity.ModifiedAt = DateTime.UtcNow;
        categoryEntity.ModifiedBy = request.ModifiedBy;
        _context.Categories.Update(categoryEntity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}