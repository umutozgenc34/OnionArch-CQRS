

using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Pipelines.Login;

public class LoginBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
where TRequest : IRequest<TResponse>, ILoginRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public LoginBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user == null || !user.Identity.IsAuthenticated)
        {
            throw new AuthorizationException("Kullanıcı oturum açmadı.");
        }
        TResponse response = await next();
        return response;
    }
}
