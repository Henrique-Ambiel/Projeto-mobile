using UnityEngine;

public static class AnimationHashes
{
    // Boy
    public static readonly int BoyIdle = Animator.StringToHash("BoyIdle");
    public static readonly int BoyXMovement = Animator.StringToHash("BoyXMovement");
    public static readonly int BoyYMovement = Animator.StringToHash("BoyYMovement");
    public static readonly int BoyYMovementDown = Animator.StringToHash("BoyYMovementDown");

    // Girl
    public static readonly int GirlIdle = Animator.StringToHash("GirlIdle");
    public static readonly int GirlXMovement = Animator.StringToHash("GirlXMovement");
    public static readonly int GirlYMovement = Animator.StringToHash("GirlYMovement");
    public static readonly int GirlYMovementDown = Animator.StringToHash("GirlYMovementDown");
}
