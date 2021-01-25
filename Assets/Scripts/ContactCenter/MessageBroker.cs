using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class MessageBroker
    {
        public Action<string> SendMessage;

        private ITimeRemaining _timeRemaining;
        private Queue<string> _queueMessages;
        private float _interval = 20.0f;
        private int _hunterScore = 0;


        public MessageBroker()
        {
            _queueMessages = new Queue<string>();
        }

        public void AddMessage(Transform enemy)
        {
            if (enemy.name == NameManager.NAME_HUNTER)
            {
                _hunterScore++;
                string message = $" Hunters killed: {_hunterScore}.\n Last {enemy.name} {enemy.GetInstanceID()}.";
                _queueMessages.Enqueue(message);
                _timeRemaining = new TimeRemaining(CreateSendingMessage, _interval);
                _timeRemaining.AddTimeRemaining();
            }
        }

        private void CreateSendingMessage()
        {
            SendMessage?.Invoke(_queueMessages.Dequeue());
        }
    }
}
