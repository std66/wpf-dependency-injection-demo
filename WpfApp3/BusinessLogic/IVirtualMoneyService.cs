using System.Threading.Tasks;

namespace WpfApp3.BusinessLogic {
    interface IVirtualMoneyService {
        Task AddVirtualMoneyAsync(int amount);
    }
}