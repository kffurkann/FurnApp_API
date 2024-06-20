using FurnApp_API.DTO;
using FurnApp_API.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FurnApp_API.Med.Commands
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, ApiResponse<PaymentDTO2>>
    {
        private readonly FurnAppContext _db;

        public CreatePaymentCommandHandler(FurnAppContext db)
        {
            _db = db;
        }

        public async Task<ApiResponse<PaymentDTO2>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FindAsync(request.ProductId);

            if (product == null)
            {
                return new ApiResponse<PaymentDTO2>
                {
                    Data = null,
                    Message = "Product not found!",
                    Success = false
                };
            }

            if (product.ProductStock < request.Quantity)
            {
                return new ApiResponse<PaymentDTO2>
                {
                    Data = null,
                    Message = "Not enough stock!",
                    Success = false
                };
            }

            product.ProductStock -= request.Quantity;

            if (product.ProductStock < 0)
            {
                return new ApiResponse<PaymentDTO2>
                {
                    Data = null,
                    Message = "Insufficient stock!",
                    Success = false
                };
            }

            var payment = new Payment
            {
                CreditCardNo = request.CreditCardNo,
                CardName = request.CardName,
                CardMonth = request.CardMonth,
                CardYear = request.CardYear,
                CardCvv = request.CardCvv,
                CargoPrice = request.CargoPrice,
                UsersId = request.UsersId,
                CargoCompany = request.CargoCompany
            };

            await _db.Payment.AddAsync(payment);
            await _db.SaveChangesAsync();

            // Ürün stoğunu güncelle
            await _db.SaveChangesAsync();

            var paymentDto = new PaymentDTO2
            {
                CreditCardNo = request.CreditCardNo,
                CardName = request.CardName,
                CardMonth = request.CardMonth,
                CardYear = request.CardYear,
                CardCvv = request.CardCvv,
                CargoPrice = request.CargoPrice,
                UsersId = request.UsersId,
                CargoCompany = request.CargoCompany
            };

            return new ApiResponse<PaymentDTO2>
            {
                Data = paymentDto,
                Message = "Payment and stock update successful!",
                Success = true
            };
        }
    }
}
