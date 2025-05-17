using UnityEngine;
using System.Collections.Generic;

// Classe responsável por controlar as animações do jogador
public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator; // Referência ao componente Animator
    private Dictionary<string, int> animationBools; // Dicionário que armazena os hashes das animações booleanas
    private string prefix; // Prefixo do personagem ("Boy" ou "Girl") para acessar as animações corretas

    // Método de inicialização do controlador de animação
    public void Init(Animator animatorRef, string characterPrefix)
    {
        animator = animatorRef; // Define o animator recebido como referência
        prefix = characterPrefix; // Define o prefixo do personagem

        animationBools = new Dictionary<string, int>(); // Inicializa o dicionário de animações

        // Associa os nomes das animações aos hashes correspondentes de acordo com o prefixo (Boy ou Girl)
        if (prefix == "Boy")
        {
            animationBools["Idle"] = AnimationHashes.BoyIdle;
            animationBools["XMovement"] = AnimationHashes.BoyXMovement;
            animationBools["YMovement"] = AnimationHashes.BoyYMovement;
            animationBools["YMovementDown"] = AnimationHashes.BoyYMovementDown;
        }
        else if (prefix == "Girl")
        {
            animationBools["Idle"] = AnimationHashes.GirlIdle;
            animationBools["XMovement"] = AnimationHashes.GirlXMovement;
            animationBools["YMovement"] = AnimationHashes.GirlYMovement;
            animationBools["YMovementDown"] = AnimationHashes.GirlYMovementDown;
        }

        Debug.Log("Init chamado com prefixo: " + characterPrefix);
    }

    // Método que define qual animação deve ser ativada com base nos valores de movimento horizontal e vertical
    public void SetMovement(float horizontal, float vertical)
    {
        ResetAllBools(); // Desativa todas as animações antes de ativar a correta

        // Ativa a animação com base na direção do movimento
        if (horizontal != 0)
        {
            animator.SetBool(animationBools["XMovement"], true);
        }
        else if (vertical > 0)
        {
            animator.SetBool(animationBools["YMovement"], true);
        }
        else if (vertical < 0)
        {
            animator.SetBool(animationBools["YMovementDown"], true);
        }
        else
        {
            animator.SetBool(animationBools["Idle"], true); // Ativa a animação de idle se não houver movimento
        }
    }

    // Método auxiliar que desativa todas as animações booleanas
    private void ResetAllBools()
    {
        foreach (var hash in animationBools.Values)
        {
            animator.SetBool(hash, false); // Define todos os bools de animação como false
        }
    }
}

