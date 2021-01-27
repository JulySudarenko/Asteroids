using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class MessageBroker : IIinitialize, ICleanup
    {
        public Action<string> SendMessage;

        private ContactCenter _contactCenter;
        private DisplayInitialization _view;
        private SpaceshipHealthController _spaceshipHealthController;

        private ITimeRemaining _timeRemaining;
        private Queue<string> _queueMessages;
        private float _interval = 20.0f;
        private int _hunterScore = 0;

        public MessageBroker(ContactCenter contactCenter, DisplayInitialization displayInitialization,
            SpaceshipHealthController spaceshipHealthController)
        {
            _contactCenter = contactCenter;
            _view = displayInitialization;
            _spaceshipHealthController = spaceshipHealthController;
            _queueMessages = new Queue<string>();
        }

        public void AddMessage(Transform enemy)
        {
            if (enemy.name == NameManager.NAME_HUNTER)
            {
                _hunterScore++;
                string message = $" Hunters killed: {_hunterScore}";
                _queueMessages.Enqueue(message);
                _timeRemaining = new TimeRemaining(CreateSendingMessage, _interval);
                _timeRemaining.AddTimeRemaining();
            }
        }

        private void CreateSendingMessage()
        {
            SendMessage?.Invoke(_queueMessages.Dequeue());
        }

        public void Initialize()
        {
            _contactCenter.EnemyHit += AddMessage;
            SendMessage += _view.ShowHuntersDeathScore;
            _contactCenter.TransferPointsOnScreen += _view.ShowGameScore;
            _spaceshipHealthController.HeathOnScreen += _view.ShowPlayerHealth;
        }

        public void Cleanup()
        {
            _contactCenter.EnemyHit -= AddMessage;
            SendMessage -= _view.ShowHuntersDeathScore;
            _contactCenter.TransferPointsOnScreen -= _view.ShowGameScore;
        }
    }
}
