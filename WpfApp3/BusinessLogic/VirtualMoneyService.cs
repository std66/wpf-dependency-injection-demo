using System.Threading.Tasks;

namespace WpfApp3.BusinessLogic {
    class VirtualMoneyService : IVirtualMoneyService {
        private readonly IVirtualMoneyDataManager virtualMoneyDataManager;
        private readonly IMoneyAddedNotificationService notificationService;

        public VirtualMoneyService(IVirtualMoneyDataManager virtualMoneyDataManager, IMoneyAddedNotificationService notificationService) {
            this.virtualMoneyDataManager = virtualMoneyDataManager;
            this.notificationService = notificationService;
        }

        public async Task AddVirtualMoneyAsync(int amount) {
            int currentAmount = await virtualMoneyDataManager.GetAmountAsync();
            currentAmount += amount;
            await virtualMoneyDataManager.SaveAmountAsync(currentAmount);
            await notificationService.Notify(amount, currentAmount);
        }
    }
}
