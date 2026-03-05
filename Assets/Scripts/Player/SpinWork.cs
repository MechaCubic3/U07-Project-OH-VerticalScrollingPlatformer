using UnityEngine;

public class SpinWork : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        animator.SetBool("Awake", true);
    }

    private void OnDisable()
    {
        animator.SetBool("Awake", false);
    }
}
