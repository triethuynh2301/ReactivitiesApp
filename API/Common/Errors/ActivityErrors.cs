using ErrorOr;

namespace API.Common.Errors;

public static class ActivityErrors
{
    public static Error NotFound => Error.NotFound(
        code: "Activity.NotFound",
        description: "Activity not found");
    public static Error DatabaseError => Error.Failure(
        code: "Activity.DatabaseError",
        description: "Can't save activity to database");
}