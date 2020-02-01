using System;
using System.Threading.Tasks;

namespace WpfApp3.BusinessLogic {
    class ScheduledMoneyAddingService : IBackgroundService {
        private readonly IVirtualMoneyService virtualMoneyService;
        private readonly int amount;
        private readonly TimeSpan interval;

        public ScheduledMoneyAddingService(IVirtualMoneyService virtualMoneyService, int amount, TimeSpan interval) {
            this.virtualMoneyService = virtualMoneyService;
            this.amount = amount;
            this.interval = interval;
        }

        public void Start() {
            DoWork().ConfigureAwait(false);
        }

        private async Task DoWork() {
            while (true) {
                await this.virtualMoneyService.AddVirtualMoneyAsync(amount);
                await Task.Delay(interval);
            }
        }
    }
}
