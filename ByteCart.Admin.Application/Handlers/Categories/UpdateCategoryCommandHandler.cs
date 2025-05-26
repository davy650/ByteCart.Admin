using ByteCart.Admin.Application.Commands.Categories;
using ByteCart.Admin.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryEntity = await _context.Categories
            .Include(c => c.SubCategories)
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (categoryEntity == null)
        {
            return false;
        }

        if (request.ParentCategoryId.HasValue && request.ParentCategoryId.Value == request.Id)
        {
            throw new ApplicationException("A category cannot be its own parent.");
        }

        // TODO: Ensure that category doesnt become a child of one of its own subcategories

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