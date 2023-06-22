using MediatR;
using OnionProject.Application.Dtos.Response;

namespace OnionProject.Application.Features.Queries.Product
{
    public class ProductQueryRequest:IRequest<Response<ProductQueryResponse>>
    {
    }
}
