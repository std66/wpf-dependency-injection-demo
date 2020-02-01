using System.Threading.Tasks;

namespace WpfApp3.BusinessLogic {
    interface IVirtualMoneyDataManager {
        Task<int> GetAmountAsync();
        Task SaveAmountAsync(int amount);
    }
}
