using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 1.5f;
    [SerializeField] private float velocityMultiplier = 8f;
    [SerializeField] private float jumpForce = 5f;
    

    private void Awake() => _rb = GetComponent<Rigidbody2D>();

    public void MoveCharacter(Vector2 direction)
    {
        var newVelocityX = direction.normalized.x * velocityMultiplier;
        var currentVelocityY = _rb.linearVelocity.y;

        _rb.linearVelocity = new Vector2(newVelocityX, currentVelocityY);
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0);
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    
    public bool IsGrounded()
    {
        var hit = Physics2D.Raycast(transform.position, -transform.up, groundCheckDistance, groundLayer);       
        return hit.collider != null;
    }
}
