using System;
using System.Threading.Tasks;
using WpfApp3.BusinessLogic;

namespace WpfApp3 {
    public class MoneyAddedNotificationToEventAdapter : IMoneyAddedNotificationService, IEventNotification<MoneyAddedNotificationToEventAdapter.MoneyAddedEventArgs> {
        public class MoneyAddedEventArgs : EventArgs {
            public MoneyAddedEventArgs(int amountAdded, int currentAmount) {
                AmountAdded = amountAdded;
                CurrentAmount = currentAmount;
            }

            public int AmountAdded { get; }
            public int CurrentAmount { get; }
        }

        public event EventHandler<MoneyAddedEventArgs> NotificationReceived;

        public Task Notify(int amountAdded, int currentAmount) {
            NotificationReceived?.Invoke(this, new MoneyAddedEventArgs(amountAdded, currentAmount));
            return Task.CompletedTask;
        }
    }
}
