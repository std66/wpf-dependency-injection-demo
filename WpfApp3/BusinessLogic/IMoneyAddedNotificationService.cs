using System.Threading.Tasks;

namespace WpfApp3.BusinessLogic {
    interface IMoneyAddedNotificationService {
        Task Notify(int amountAdded, int currentAmount);
    }
}
