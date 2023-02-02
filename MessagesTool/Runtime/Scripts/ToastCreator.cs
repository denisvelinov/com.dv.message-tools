using System.Collections;
using UnityEngine;
using TMPro;

namespace DV.MessageTools
{
    public class ToastCreator : MonoBehaviour
    {
        [SerializeField] private MessagesManager messageManager;
        private bool isActive = false;
        [SerializeField] private TMP_Text toastMessage;
        [SerializeField] private float messageDisplayTime = 3;

        public void Show(string displayMessage)
        {
            if (!isActive)
            {
                isActive = true;
                this.gameObject.SetActive(true);
                toastMessage.text = displayMessage;
                StartCoroutine(ToastLifetimeRoutine());
            }
        }

        private void Hide()
        {
            isActive = false;
            this.gameObject.SetActive(false);
            messageManager.Dequeue();
        }

        IEnumerator ToastLifetimeRoutine()
        {
            yield return new WaitForSeconds(messageDisplayTime);
            Hide();
        }
    }
}

