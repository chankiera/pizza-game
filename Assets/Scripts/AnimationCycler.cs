using UnityEngine;

public class AnimationCycler : MonoBehaviour
{
    private Animator animator;

    private string[] animations =
    {
        "Walking",
        "Catwalk Walking",
        "Standing Idle"
    };

    private int currentAnimation = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating(nameof(SwitchAnimation), 5f, 1f);
    }

    void SwitchAnimation()
    {
        animator.Play(animations[currentAnimation]);

        currentAnimation++;
        if (currentAnimation >= animations.Length)
        {
            currentAnimation = 0;
        }
    }
}