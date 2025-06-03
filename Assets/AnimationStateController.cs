using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    private float blend = 0.0f;
    private float acceleration = 2.0f;    // tốc độ tăng blend
    private float deceleration = 4.0f;    // tốc độ giảm blend
    private int blendHash;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on this GameObject.");
            return;
        }

        blendHash = Animator.StringToHash("Blend");
    }

    public void UpdateAnimationState(bool isMoving, bool isRunning)
    {
        float targetBlend = 0f;

        if (isMoving)
        {
            targetBlend = isRunning ? 1f : 0.5f;
        }

        if (blend < targetBlend)
        {
            blend += acceleration * Time.deltaTime;
        }

        if (blend > targetBlend && !isMoving)
        {
            blend -= deceleration * Time.deltaTime;
        }
        if(isMoving && blend < 0.0f)
        {
            blend = 0.0f;
        }

        animator.SetFloat(blendHash, blend);
    }
}
