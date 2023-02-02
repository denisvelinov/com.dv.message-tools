using System.Collections;
using System;
using UnityEngine;

namespace DV.MessageTools
{
    public class MessagesManager : MonoBehaviour
    {
        //References UIManager, ToastCreator, SnackbarCreator
        [SerializeField] private ToastCreator toastCreator;
        [SerializeField] private SnackbarCreator snackbarCreator;

        private Queue messagesQueue;

        // Start is called before the first frame update
        void Start()
        {
            messagesQueue = new Queue();
        }

        private void Enqueue(string message)
        {
            if (messagesQueue.Count == 0)
            {
                messagesQueue.Enqueue(message);
                NextMessage();
            }
            else if (messagesQueue.Count <= 2)
            {
                messagesQueue.Enqueue(message);
            }
        }

        public void Dequeue()
        {
            messagesQueue.Dequeue();

            if (messagesQueue.Count != 0)
            {
                NextMessage();
            }
        }

        private void NextMessage()
        {
            char messageType = messagesQueue.Peek().ToString()[0];
            string messageToDisplay = messagesQueue.Peek().ToString().Remove(0, 1);

            if (messageType == '1')
            {
                CallToastMessage(messageToDisplay);
            }
            else
            {
                CallSnackbarMessage(messageToDisplay);
            }
        }

        private void CallToastMessage(string messageToDisplay)
        {
            toastCreator.Show(messageToDisplay);
        }

        private void CallSnackbarMessage(string messageToDisplay)
        {
            snackbarCreator.Show(messageToDisplay);
        }

        public void EnqueToastMessage(string messageToDisplay)
        {
            Enqueue(1 + messageToDisplay);
        }

        public void EnqueSnackbarMessage(string messageToDisplay)
        {
            Enqueue(2 + messageToDisplay);
        }
    }
}
