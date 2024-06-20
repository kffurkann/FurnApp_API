using FurnApp_API.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FurnApp_API.Med.Commands
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, ApiResponse<bool>>
    {
        private readonly FurnAppContext _db;

        public DeleteAddressCommandHandler(FurnAppContext db)
        {
            _db = db;
        }

        public async Task<ApiResponse<bool>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _db.Address.FindAsync(request.AddressId);
            if (address == null)
            {
                return new ApiResponse<bool>
                {
                    Data = false,
                    Message = "Address not found!",
                    Success = false
                };
            }

            _db.Address.Remove(address);
            await _db.SaveChangesAsync();

            return new ApiResponse<bool>
            {
                Data = true,
                Message = "Address deleted successfully!",
                Success = true
            };
        }
    }
}
