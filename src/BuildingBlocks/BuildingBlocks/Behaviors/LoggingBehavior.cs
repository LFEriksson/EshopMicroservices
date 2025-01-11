using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors;

public class LoggingBehavior<TRequest, TResponse>
    (ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation("[START] Handle request {Request} - Response={Response} - RequestData={ReequstData}",
            typeof(TRequest).Name, typeof(TResponse).Name, request);

        var startTime = Stopwatch.GetTimestamp();
        var response = await next();
        var deltatime = Stopwatch.GetElapsedTime(startTime);

        if (deltatime.TotalSeconds > 3)
        {
            logger.LogWarning
                ("[PREFORMANCE] Long execution time for {Request} - {ElapsedMilliseconds}ms - RequestData={RequestData}", typeof(TRequest).Name, deltatime.TotalMilliseconds, request);
        }

        logger.LogInformation("[End] Handle request={Request} - Response={Respose} - RequestData={RequestData}",
            typeof(TRequest).Name, typeof(TRequest).Name, request);

        return response;
    }
}
