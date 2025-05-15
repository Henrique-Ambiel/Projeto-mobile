using UnityEngine;

public class PlayerSkinLoader : MonoBehaviour
{
    public RuntimeAnimatorController animatorControllerBoy;
    public RuntimeAnimatorController animatorControllerGirl;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // L� a escolha do jogador (assumimos que foi salva antes)
        string skin = PlayerPrefs.GetString("skinSelecionada", "Menino"); // valor padr�o: Menino

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

