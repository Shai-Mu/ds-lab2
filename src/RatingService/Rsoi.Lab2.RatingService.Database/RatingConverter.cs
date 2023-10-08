using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using DbRating = Rsoi.Lab2.RatingService.Database.Rating;
using CoreRating = Rsoi.Lab2.RatingService.Core.Rating;

namespace Rsoi.Lab2.RatingService.Database;

public static class RatingConverter
{
    [return: NotNullIfNotNull("dbRating")]
    public static CoreRating? Convert(DbRating? dbRating)
    {
        if (dbRating is null)
            return null;

        return new CoreRating(dbRating.Id, dbRating.Username, dbRating.Stars);
    }
}