using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using ErrorOr;

namespace BuberBreakfast.Services.Breakfasts;

public interface IBreakfastService
{
    ErrorOr<Created> CreateBreakfast(Breakfast breakfast);
    ErrorOr<Breakfast> GetBreakfast(Guid id);
    ErrorOr<UpsertedBreakfast> UpsertBreakfast(Breakfast breakfast);
    ErrorOr<Deleted> DeleteBreakfast(Guid id);
    ErrorOr<List<Breakfast>> GetAllBreakfasts();
    ErrorOr<List<Breakfast>> SearchBreakfasts(string query);
    ErrorOr<Breakfast> RenameBreakfast(Guid id, Breakfast updatedNameBreakfast);
}