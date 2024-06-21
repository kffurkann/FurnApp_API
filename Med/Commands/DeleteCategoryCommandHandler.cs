using FurnApp_API.Med.Commands;
using FurnApp_API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FurnApp_API.Commands.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ApiResponse<Category>>
    {
        private readonly FurnAppContext _db;

        public DeleteCategoryCommandHandler(FurnAppContext context)
        {
            _db = context;
        }

        public async Task<ApiResponse<Category>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _db.Categories
                                    .Include(c => c.Products)
                                    .FirstOrDefaultAsync(c => c.CategoryId == request.CategoryId);

            if (category == null)
            {
                return new ApiResponse<Category>
                {
                    Data = null,
                    Message = "Category not found!",
                    Success = false
                };
            }

            // İlgili kategorideki ürünleri sil
            _db.Products.RemoveRange(category.Products);

            // Kategoriyi sil
            _db.Categories.Remove(category);

            await _db.SaveChangesAsync();

            return new ApiResponse<Category>
            {
                Data = category,
                Message = "Category and related products were deleted!",
                Success = true
            };
        }
    }
}
