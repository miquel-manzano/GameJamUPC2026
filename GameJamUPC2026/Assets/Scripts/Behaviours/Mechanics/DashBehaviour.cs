using UnityEngine;

public class DashBehaviour : MonoBehaviour
{
    [Header("Dash Settings")]
    [SerializeField] private float dashForce = 20f;
    [SerializeField] private float dashDuration = 0.15f;
    [SerializeField] private float dashCooldown = 3f;

    private AnimationBehaviour _animationBehaviour;
    private Rigidbody2D rb;
    private bool isDashing = false;
    private bool canDash = true;

    private Vector2 dashDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animationBehaviour = GetComponent<AnimationBehaviour>();
    }

    public void Dash(Vector2 direction)
    {
        Debug.Log("Dash");
        if (!canDash || isDashing)
            return;

        dashDirection = direction.normalized;
        StartCoroutine(DashRoutine());
    }

    private System.Collections.IEnumerator DashRoutine()
    {
        canDash = false;
        isDashing = true;

        float timer = 0f;

        while (timer < dashDuration)
        {
            rb.linearVelocity = dashDirection * dashForce;
            timer += Time.deltaTime;
            yield return null;
        }

        isDashing = false;

        // Esperar cooldown
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}