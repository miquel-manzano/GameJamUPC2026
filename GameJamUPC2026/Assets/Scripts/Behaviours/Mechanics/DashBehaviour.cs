using System.Collections;
using UnityEngine;

public class DashBehaviour : MonoBehaviour
{
    [Header("Dash Settings")]
    [SerializeField] private float dashForce = 5000f;
    [SerializeField] private float dashDuration = 0.15f;
    [SerializeField] private float dashCooldown = 3f;

    private AnimationBehaviour _animationBehaviour;
    private Rigidbody2D rb;
    private bool isDashing = false;
    private bool canDash = true;
    public bool unlockDash = true;

    private Vector2 dashDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animationBehaviour = GetComponent<AnimationBehaviour>();
    }

    public void Dash(Vector2 direction)
    {
        if (unlockDash)
        {
            if (!canDash || isDashing)
                return;
            Debug.Log("Dash");
            StartCoroutine(DashRoutine(direction));
        }
    }

    private IEnumerator DashRoutine(Vector2 direction)
    {
        canDash = false;
        isDashing = true;

        /*
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        */

        // Resetear velocidad para que AddForce funcione bien
        //rb.linearVelocity = Vector2.zero;

        // Fuerza explosiva estilo Hollow Knight
        Debug.Log("Trying so hard aaaaa");
        rb.AddForce(direction * dashForce, ForceMode2D.Force);

        yield return new WaitForSeconds(dashDuration);

        // Frenar en seco
        /*
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = originalGravity;
        */
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

}