using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors;

public class LoggingBehavior<TRequst, TResponse>
    (ILogger<LoggingBehavior<TRequst, TResponse>> logger)
    : IPipelineBehavior<TRequst, TResponse>
    where TResponse : notnull, IRequest<TResponse>
    where TRequst : notnull
{
    public async Task<TResponse> Handle(TRequst request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation("[START] Handle request {Request} - Response={Response} - RequestData={ReequstData}",
            typeof(TRequst).Name, typeof(TResponse).Name, request);

        var startTime = Stopwatch.GetTimestamp();
        var response = await next();
        var deltatime = Stopwatch.GetElapsedTime(startTime);

        if (deltatime.TotalSeconds > 3)
        {
            logger.LogWarning
                ("[PREFORMANCE] Long execution time for {Request} - {ElapsedMilliseconds}ms - RequestData={RequestData}", typeof(TRequst).Name, deltatime.TotalMilliseconds, request);
        }

        logger.LogInformation("[End] Handle request={Request} - Response={Respose} - RequestData={RequestData}",
            typeof(TRequst).Name, typeof(TRequst).Name, request);

        return response;
    }
}
