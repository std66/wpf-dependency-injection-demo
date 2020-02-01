using System;
using WpfApp3.BusinessLogic;

namespace WpfApp3.Commands {
    class StartAddingMoneyCommand : IStartAddingMoneyCommand {
        public event EventHandler CanExecuteChanged;
        private bool triggered;
        private readonly IBackgroundService moneyAddService;

        public StartAddingMoneyCommand(IBackgroundService moneyAddService) {
            this.moneyAddService = moneyAddService;
        }

        public bool CanExecute(object parameter) {
            return !triggered;
        }

        public void Execute(object parameter) {
            triggered = true;
            this.moneyAddService.Start();
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
