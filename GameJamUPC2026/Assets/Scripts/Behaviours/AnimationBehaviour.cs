using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class AnimationBehaviour : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetGrounded(bool isGrounded)
    {
        _animator.SetBool("IsGrounded", isGrounded);
    }

    public void SetBool(string parameterName, bool value)
    {
        _animator.SetBool(parameterName, value);
    }

    public void SetHorizontalSpeed(float horizontalSpeed)
    {
        _animator.SetFloat("HorizontalSpeed", horizontalSpeed);
    }
    public void SetVerticalSpeed(float verticalSpeed)
    {
        _animator.SetFloat("VerticalSpeed", verticalSpeed);
    }

    public void Trigger(string triggerName)
    {
        _animator.SetTrigger(triggerName);
    }

    public void FlipSprite(Vector2 direction)
    {
        if (_animator != null)
        {
            if (direction.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
        }
    }

    /*
    private static readonly int HorizontalSpeedHash = Animator.StringToHash("HorizontalSpeed");
    private static readonly int VerticalSpeedHash = Animator.StringToHash("VerticalSpeed");
    private static readonly int JumpHash = Animator.StringToHash("Jump");
    private static readonly int MeleeAttackHash = Animator.StringToHash("MeleeAttack");
    private static readonly int RangeAttackHash = Animator.StringToHash("RangeAttack");
    private static readonly int DashAttackHash = Animator.StringToHash("Dash");
    private static readonly int IsAimingHash = Animator.StringToHash("IsAiming");
    
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var velocity = _rigidbody.linearVelocity;
        var horizontalSpeed = new Vector2(velocity.x, 0);
        var verticalSpeed = new Vector2(0, velocity.y);
        
        _animator.SetFloat(HorizontalSpeedHash, horizontalSpeed.magnitude, 0.1f, Time.deltaTime);
        _animator.SetFloat(VerticalSpeedHash, verticalSpeed.magnitude, 0.1f, Time.deltaTime);
    }

    public void TriggerJump() => _animator.SetTrigger(JumpHash);
    public void TriggerMeleeAttack() => _animator.SetTrigger(MeleeAttackHash);
    public void TriggerRangeAttack() => _animator.SetTrigger(RangeAttackHash);
    public void TriggerDash() => _animator.SetTrigger(DashAttackHash);
    public void SetAiming(bool isAiming) => _animator.SetBool(IsAimingHash, isAiming);
    */
}
