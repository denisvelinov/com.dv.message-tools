using System.Collections;
using UnityEngine;
using TMPro;

namespace DV.MessageTools
{
    public class SnackbarCreator : MonoBehaviour
    {
        [SerializeField] private MessagesManager messageManager;
        private bool isActive = false;
        [SerializeField] private TMP_Text snackbarMessage;
        [SerializeField] private float messageDisplayTime = 5;

        public void Show(string displayMessage)
        {
            if (!isActive)
            {
                isActive = true;
                this.gameObject.SetActive(true);
                snackbarMessage.text = displayMessage;
                StartCoroutine(ToastLifetimeRoutine());
            }
        }

        public void Hide()
        {
            isActive = false;
            this.gameObject.SetActive(false);
            messageManager.Dequeue();
        }

        IEnumerator ToastLifetimeRoutine()
        {
            yield return new WaitForSeconds(messageDisplayTime);

            if (isActive)
            {
                Hide();
            }
        }
    }
}

