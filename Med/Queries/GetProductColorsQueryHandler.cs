using FurnApp_API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FurnApp_API.Med.Queries
{
    public class GetProductColorsQueryHandler : IRequestHandler<GetProductColorsQuery, ApiResponse<List<ProductColor>>>
    {
        private readonly FurnAppContext db;
        public GetProductColorsQueryHandler(FurnAppContext db)
        {
            this.db = db;
        }
        public async Task<ApiResponse<List<ProductColor>>> Handle(GetProductColorsQuery request, CancellationToken cancellationToken)
        {
            var ProductColors = await db.ProductColors.ToListAsync();
            return new ApiResponse<List<ProductColor>>
            {
                Data = ProductColors,
                Success = true,
                Message = "ProductColors were came successfully!"
            };
        }
    }
}