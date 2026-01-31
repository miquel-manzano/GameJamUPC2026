using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveBehaviour : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 1.5f;
    [SerializeField] private float velocityMultiplier = 8f;
    [SerializeField] private float jumpForce = 5f;
    
    private Rigidbody2D _rb;
    private int _jumpCount;
    
    private void Awake() => _rb = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        // Reset jump count when grounded and falling/standing (not moving up significantly)
        if (IsGrounded() && _rb.linearVelocity.y <= 0.1f)
        {
            _jumpCount = 0;
        }
    }

    public void MoveCharacter(Vector2 direction)
    {
        var newVelocityX = direction.normalized.x * velocityMultiplier;
        var currentVelocityY = _rb.linearVelocity.y;

        _rb.linearVelocity = new Vector2(newVelocityX, currentVelocityY);
    }

    public void Jump()
    {
        // Allow jump if jump count is less than 2 (0 or 1)
        if (_jumpCount < 2)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0);
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _jumpCount++;
        }
    }

    public float GetHorizontalVelocity() => _rb.linearVelocity.x;
    public float GetVerticalVelocity() => _rb.linearVelocity.y;

    public void Flip(float xDirection)
    {
        if (xDirection > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (xDirection < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private bool IsGrounded()
    {
        var hit = Physics2D.Raycast(transform.position, -transform.up, groundCheckDistance, groundLayer);
        return hit.collider != null;
    }
}