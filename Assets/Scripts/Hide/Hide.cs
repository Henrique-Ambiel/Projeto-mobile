using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hide : MonoBehaviour
{
    public GameObject hideUIButton;
    public TextMeshProUGUI hideButtonText; // Texto do botão, opcional
    private PlayerManager playerManager;

    private void Start()
    {
        hideUIButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerManager = other.GetComponent<PlayerManager>();
            if (playerManager != null)
            {
                hideUIButton.SetActive(true);

                // Garante que o botão esteja limpo e adiciona a ação correta
                Button btn = hideUIButton.GetComponent<Button>();
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(ToggleHide);

                UpdateButtonText();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerManager != null && playerManager.IsHidden())
                playerManager.Unhide();

            hideUIButton.SetActive(false);
            playerManager = null;
        }
    }

    private void ToggleHide()
    {
        if (playerManager == null) return;

        if (playerManager.IsHidden())
        {
            playerManager.Unhide();
        }
        else
        {
            playerManager.Hide();
        }

        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        if (hideButtonText != null)
        {
            hideButtonText.text = playerManager.IsHidden() ? "Sair" : "Esconder";
        }
    }
}
