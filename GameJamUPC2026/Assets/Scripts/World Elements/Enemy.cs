using UnityEngine;

[RequireComponent(typeof(MoveBehaviour))]
public class Enemy : MonoBehaviour
{
    private MoveBehaviour _mb;

    private bool isFacingRight;
    private Vector2 currentDirection;

    private void Awake()
    {
        _mb = GetComponent<MoveBehaviour>();

        isFacingRight = transform.localScale.x == 1;
        currentDirection = new Vector2(1f, 0);
    }
    private void Update()
    {
        _mb.MoveCharacter(currentDirection);
        if (DidHitHorizontal(0.5f, isFacingRight)) { currentDirection *= -1; }

        if (!isFacingRight && currentDirection.x > 0) 
        { 
            _mb.Flip(currentDirection.x);
            isFacingRight = true;
        }
        else if (isFacingRight && currentDirection.x < 0) 
        {
            _mb.Flip(currentDirection.x);
            isFacingRight = false;
        }
    }
    private bool DidHitHorizontal(float raycastDistance, bool rightCheck)
    {
        return rightCheck
            ? Physics2D.Raycast(transform.position, Vector2.right, raycastDistance, LayerMask.GetMask("Ground"))
            : Physics2D.Raycast(transform.position, Vector2.left, raycastDistance, LayerMask.GetMask("Ground"));
    }
}