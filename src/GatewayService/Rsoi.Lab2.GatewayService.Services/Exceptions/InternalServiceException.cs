namespace Rsoi.Lab2.GatewayService.Services.Exceptions;

public class InternalServiceException : Exception
{
    public string ServiceName { get; set; }
    
    public int ErrorCode { get; set; }
    
    public string Description { get; set; }

    public InternalServiceException(string serviceName, int errorCode, string description) : base()
    {
        ServiceName = serviceName;
        ErrorCode = errorCode;
        Description = description;
    }
    
    public InternalServiceException(string message, string serviceName, int errorCode, string description) : base(message)
    {
        ServiceName = serviceName;
        ErrorCode = errorCode;
        Description = description;
    }
}