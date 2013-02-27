using System;
using GalaSoft.MvvmLight.Messaging;

namespace DarvinAppTest.Presentation.Mock
{
    public class MessengerMock:IMessenger
    {
        private object gotMessage;
        public object MessageGot
        {
            get { return gotMessage; }
        }
        public void Register<TMessage>(object recipient, Action<TMessage> action)
        {
            throw new NotImplementedException();
        }

        public void Register<TMessage>(object recipient, object token, Action<TMessage> action)
        {
            throw new NotImplementedException();
        }

        public void Register<TMessage>(object recipient, object token, bool receiveDerivedMessagesToo, Action<TMessage> action)
        {
            throw new NotImplementedException();
        }

        public void Register<TMessage>(object recipient, bool receiveDerivedMessagesToo, Action<TMessage> action)
        {
            throw new NotImplementedException();
        }

        public void Send<TMessage>(TMessage message)
        {
            gotMessage = message;
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
            throw new NotImplementedException();
        }

        public void Unregister<TMessage>(object recipient)
        {
            throw new NotImplementedException();
        }

        public void Unregister<TMessage>(object recipient, object token)
        {
            throw new NotImplementedException();
        }

        public void Unregister<TMessage>(object recipient, Action<TMessage> action)
        {
            throw new NotImplementedException();
        }

        public void Unregister<TMessage>(object recipient, object token, Action<TMessage> action)
        {
            throw new NotImplementedException();
        }
    }
}