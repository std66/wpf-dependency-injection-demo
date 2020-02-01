using System;

namespace WpfApp3 {
    public interface IEventNotification<T>
        where T: EventArgs {
        event EventHandler<T> NotificationReceived;
    }
}