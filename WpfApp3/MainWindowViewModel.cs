using System.ComponentModel;
using System.Windows.Input;
using WpfApp3.Commands;

namespace WpfApp3 {
    public class MainWindowViewModel : INotifyPropertyChanged {
        private readonly IEventNotification<MoneyAddedNotificationToEventAdapter.MoneyAddedEventArgs> moneyAddedEvent;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel() {

        }

        public MainWindowViewModel(IStartAddingMoneyCommand addMoneyCommand, IEventNotification<MoneyAddedNotificationToEventAdapter.MoneyAddedEventArgs> moneyAddedEvent) : this() {
            StartAddMoneyCommand = addMoneyCommand;
            this.moneyAddedEvent = moneyAddedEvent;

            this.moneyAddedEvent.NotificationReceived += MoneyAddedEvent_NotificationReceived;
        }

        private void MoneyAddedEvent_NotificationReceived(object sender, MoneyAddedNotificationToEventAdapter.MoneyAddedEventArgs e) {
            this.CurrentMoney = e.CurrentAmount;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentMoney)));
        }

        public ICommand StartAddMoneyCommand { get; }
        public int CurrentMoney { get; private set; }
    }
}
