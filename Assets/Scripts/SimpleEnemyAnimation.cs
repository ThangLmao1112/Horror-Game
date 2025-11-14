using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemyAnimation : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animation anim;

    [Header("Animation Clips")]
    public AnimationClip idleClip;
    public AnimationClip runningClip;
    public AnimationClip attackClip;

    [Header("Settings")]
    public float speedThreshold = 0.1f;

    private string currentAnimation = "";

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animation>();

        // Play Idle ban đầu
        if (idleClip != null)
        {
            PlayAnimation(idleClip.name);
        }
    }

    void Update()
    {
        if (agent == null || anim == null) return;

        float speed = agent.velocity.magnitude;

        // Chạy
        if (speed > speedThreshold)
        {
            if (runningClip != null && currentAnimation != runningClip.name)
            {
                PlayAnimation(runningClip.name);
            }
        }
        // Đứng yên
        else
        {
            if (idleClip != null && currentAnimation != idleClip.name)
            {
                PlayAnimation(idleClip.name);
            }
        }
    }

    void PlayAnimation(string animName)
    {
        if (anim[animName] != null)
        {
            anim.CrossFade(animName, 0.2f);
            currentAnimation = animName;
        }
    }

    public void PlayAttack()
    {
        if (attackClip != null)
        {
            anim.CrossFade(attackClip.name, 0.1f);
        }
    }
}