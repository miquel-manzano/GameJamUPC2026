using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class AnimationBehaviour : MonoBehaviour
{
    private static readonly int HorizontalSpeedHash = Animator.StringToHash("HorizontalSpeed");
    private static readonly int VerticalSpeedHash = Animator.StringToHash("VerticalSpeed");
    private static readonly int JumpHash = Animator.StringToHash("Jump");
    private static readonly int MeleeAttackHash = Animator.StringToHash("MeleeAttack");
    private static readonly int RangeAttackHash = Animator.StringToHash("RangeAttack");
    private static readonly int DashAttackHash = Animator.StringToHash("Dash");
    
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
}
