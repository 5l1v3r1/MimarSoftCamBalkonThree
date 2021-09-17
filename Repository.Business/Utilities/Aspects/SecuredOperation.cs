using Castle.DynamicProxy;
using Core.Utilities.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Repository.Business.Utilities.Constants;
using System;
using System.Linq;

namespace Repository.Business.Utilities.Aspects
{
    public class SecuredOperation : MethodInterception
    {
        private readonly string[] _roles;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider
                .GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor
                .HttpContext.User.ClaimRoles();

            if (_roles.Any(role =>
                roleClaims.Contains(role)))
                return;

            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}