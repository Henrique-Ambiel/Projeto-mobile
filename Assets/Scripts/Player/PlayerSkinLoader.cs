using UnityEngine;

public class PlayerSkinLoader : MonoBehaviour
{
    public RuntimeAnimatorController animatorControllerBoy;
    public RuntimeAnimatorController animatorControllerGirl;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Lê a escolha do jogador (assumimos que foi salva antes)
        string skin = PlayerPrefs.GetString("skinSelecionada", "Menino"); // valor padrão: Menino

        if (skin == "Menina")
        {
            animator.runtimeAnimatorController = animatorControllerGirl;
        }
        else
        {
            animator.runtimeAnimatorController = animatorControllerBoy;
        }
    }
}

