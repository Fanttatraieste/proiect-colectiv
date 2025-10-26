using ProiectColectiv.Application.Common;

namespace ProiectColectiv.Application.Interfaces
{
    public interface IRequestHandler<in TRequest, TResponse> where TRequest : BaseRequest<TResponse> where TResponse : BaseResponse
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
