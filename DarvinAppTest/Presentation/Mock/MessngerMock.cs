using System;
using GalaSoft.MvvmLight.Messaging;

namespace DarvinAppTest.Presentation.Mock
{
    public class MessengerMock : IMessenger
    {
        private object _gotMessage;

        public object MessageGot
        {
            get { return _gotMessage; }
        }

        public void Register<TMessage>(object recipient, Action<TMessage> action)
        {
        }

        public void Register<TMessage>(object recipient, object token, Action<TMessage> action)
        {
        }

        public void Register<TMessage>(object recipient, object token, bool receiveDerivedMessagesToo,
                                       Action<TMessage> action)
        {
        }

        public void Register<TMessage>(object recipient, bool receiveDerivedMessagesToo, Action<TMessage> action)
        {
        }

        public void Send<TMessage>(TMessage message)
        {
            _gotMessage = message;
        }

        public void Send<TMessage, TTarget>(TMessage message)
        {
            Send(message);
        }

        public void Send<TMessage>(TMessage message, object token)
        {
            Send(message);
        }

        public void Unregister(object recipient)
        {
        }

        public void Unregister<TMessage>(object recipient)
        {
        }

        public void Unregister<TMessage>(object recipient, object token)
        {
        }

        public void Unregister<TMessage>(object recipient, Action<TMessage> action)
        {
        }

        public void Unregister<TMessage>(object recipient, object token, Action<TMessage> action)
        {
        }
    }
}