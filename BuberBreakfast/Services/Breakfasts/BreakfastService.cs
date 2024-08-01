using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.ServiceErrors;
using ErrorOr;

namespace BuberBreakfast.Services.Breakfasts;

public class BreakfastService : IBreakfastService
{
    private static readonly Dictionary<Guid, Breakfast> _breakfasts = new();

    public ErrorOr<Created> CreateBreakfast(Breakfast breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);

        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteBreakfast(Guid id)
    {
        _breakfasts.Remove(id);

        return Result.Deleted;
    }

    public ErrorOr<List<Breakfast>> GetAllBreakfasts()
    {
        if (_breakfasts.Count > 0)
        {
            return _breakfasts.Values.ToList(); 
        }
        return Errors.Breakfast.NotFound;
    }

    public ErrorOr<Breakfast> GetBreakfast(Guid id)
    {
        if (_breakfasts.TryGetValue(id, out var breakfast))
        {
            return breakfast;
        }

        return Errors.Breakfast.NotFound;
    }

    public ErrorOr<Breakfast> RenameBreakfast(Guid id, Breakfast newBreakfast)
    {
        if (_breakfasts.ContainsKey(id))
        {
            _breakfasts[id] = newBreakfast;
            return newBreakfast;
        }

        return Errors.Breakfast.NotFound;
    }
    public ErrorOr<List<Breakfast>> SearchBreakfasts(string query)
    {
        List<Breakfast> result = new List<Breakfast>();
        if (_breakfasts.Count > 0)
        {
            List<Breakfast> allBreakfasts = _breakfasts.Values.ToList();
            foreach (var breakfast in allBreakfasts)
            {
                if (breakfast.Name.Contains(query))
                {
                    result.Add(breakfast);
                }
            }
            
            if (result.Count == 0)
            {
                 return Errors.Breakfast.NoBreakfastsFound;
            }
            
            return result;
        }
        
        return Errors.Breakfast.Empty;
    }

    public ErrorOr<UpsertedBreakfast> UpsertBreakfast(Breakfast breakfast)
    {
        var isNewlyCreated = !_breakfasts.ContainsKey(breakfast.Id);
        _breakfasts[breakfast.Id] = breakfast;

        return new UpsertedBreakfast(isNewlyCreated);
    }
}
