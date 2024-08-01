namespace BuberBreakfast.Contracts.Breakfast;

public record RenameBreakfastRequest(
    string Name, Guid id);