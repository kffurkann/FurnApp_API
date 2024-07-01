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
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, ApiResponse<List<User>>>
    {
        private readonly FurnAppContext db;
        public GetUsersQueryHandler(FurnAppContext db)
        {
            this.db = db;
        }
        public async Task<ApiResponse<List<User>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var Users = await db.Users.Where(o => o.UsersAuthorization == 0).ToListAsync();
            return new ApiResponse<List<User>>
            {
                Data = Users,
                Success = true,
                Message = "Users were came successfully!"
            };
        }
    }
}