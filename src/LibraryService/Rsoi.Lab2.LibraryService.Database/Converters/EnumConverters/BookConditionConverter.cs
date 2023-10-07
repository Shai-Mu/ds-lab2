using DbBookCondition = Rsoi.Lab2.LibraryService.Database.Models.Enums.BookCondition;
using CoreBookCondition = Rsoi.Lab2.LibraryService.Core.Models.Enums.BookCondition;

namespace Rsoi.Lab2.LibraryService.Database.Converters.EnumConverters;

public static class BookConditionConverter
{
    public static DbBookCondition Convert(CoreBookCondition coreBookCondition)
    {
        return coreBookCondition switch
        {
            CoreBookCondition.Bad => DbBookCondition.Bad,
            CoreBookCondition.Excellent => DbBookCondition.Excellent,
            CoreBookCondition.Good => DbBookCondition.Good,
            _ => throw new ArgumentOutOfRangeException(nameof(coreBookCondition), coreBookCondition, "")
        };
    }
    
    public static CoreBookCondition Convert(DbBookCondition coreBookCondition)
    {
        return coreBookCondition switch
        {
            DbBookCondition.Bad => CoreBookCondition.Bad,
            DbBookCondition.Excellent => CoreBookCondition.Excellent,
            DbBookCondition.Good => CoreBookCondition.Good,
            _ => throw new ArgumentOutOfRangeException(nameof(coreBookCondition), coreBookCondition, "")
        };
    }
}