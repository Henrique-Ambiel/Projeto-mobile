using UnityEngine;
using System.Collections.Generic;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private Dictionary<string, int> animationBools;

    private string prefix;

    public void Init(Animator animatorRef, string characterPrefix)
    {
        animator = animatorRef;
        prefix = characterPrefix;

        animationBools = new Dictionary<string, int>();

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
    }

    public void SetMovement(float horizontal, float vertical)
    {
        ResetAllBools();

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
            animator.SetBool(animationBools["Idle"], true);
        }
    }

    private void ResetAllBools()
    {
        foreach (var hash in animationBools.Values)
        {
            animator.SetBool(hash, false);
        }
    }
}
