using Castle.DynamicProxy;
using Core.CrossCutting.Logging;
using Core.CrossCutting.Logging.Log4Net;
using Core.Utilities.Interceptors;
using System;
using System.Linq;

namespace Core.Utilities.Aspects
{
    public class LogAspect : MethodInterception
    {
        private readonly LoggerServiceBase _loggerServiceBase;

        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new Exception(AspectMessages.WrongLoggerType);
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase.Info(GetLogDetail(invocation));
        }

        private static LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = invocation.Arguments
                .Select((t, i) =>
                    new LogParameter
                    {
                        Name = invocation.GetConcreteMethod()
                            .GetParameters()[i].Name,
                        Value = t,
                        Type = t.GetType().Name
                    }).ToList();

            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetail;
        }
    }
}