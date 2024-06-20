using FurnApp_API.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FurnApp_API.Med.Commands
{
    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, ApiResponse<Color>>
    {
        private readonly FurnAppContext db;

        public CreateColorCommandHandler(FurnAppContext db)
        {
            this.db = db;
        }

        public async Task<ApiResponse<Color>> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            if (request.ColorName == null)
            {
                var apiResponse2 = new ApiResponse<Color>()
                {
                    Data = null,
                    Message = "Required field is empty!",
                    Success = false
                };
                return apiResponse2;
            }
            var color = new Color() { ColorName = request.ColorName };
            await db.Colors.AddAsync(color);
            await db.SaveChangesAsync();
            return new ApiResponse<Color>
            {
                Data = null,
                Success = true,
                Message = "Color was added!"
            };
        }
    }
}
