using System.Threading.Tasks;
using WpfApp3.BusinessLogic;

namespace WpfApp3.DataManagement {
    class InMemoryVirtualMoneyDataManager : IVirtualMoneyDataManager {
        private int amount;

        public Task<int> GetAmountAsync() {
            return Task.FromResult(amount);
        }

        public Task SaveAmountAsync(int amount) {
            this.amount = amount;
            return Task.CompletedTask;
        }
    }
}
