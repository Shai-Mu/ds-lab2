using Rsoi.Lab2.GatewayService.HttpApi.Models.Enum;
using Rsoi.Lab2.LibraryService.Core.Models.Enums;
using static System.String;

namespace Rsoi.Lab2.GatewayService.HttpApi.Converters;

public static class BookConditionConverter
{
    public static Condition Convert(BookCondition bookCondition)
    {
        return bookCondition switch
        {
            BookCondition.Bad => Condition.Bad,
            BookCondition.Excellent => Condition.Excellent,
            BookCondition.Good => Condition.Excellent,
            _ => throw new ArgumentOutOfRangeException(nameof(bookCondition), bookCondition, Empty)
        };
    }
    
    public static BookCondition Convert(Condition bookCondition)
    {
        return bookCondition switch
        {
            Condition.Bad => BookCondition.Bad,
            Condition.Excellent => BookCondition.Excellent,
            Condition.Good => BookCondition.Excellent,
            _ => throw new ArgumentOutOfRangeException(nameof(bookCondition), bookCondition, Empty)
        };
    }
}