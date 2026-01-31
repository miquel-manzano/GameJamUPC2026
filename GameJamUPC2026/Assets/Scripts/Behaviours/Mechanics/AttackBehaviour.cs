using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AnimationBehaviour))]
public class AttackBehaviour : MonoBehaviour
{
    private AnimationBehaviour _animationBehaviour;
    private IAttack _meleeAttack;
    private IAttack _rangeAttack;
    private IAttack _currentAttack;

    private void Awake()
    {
        var animationBehaviour = GetComponent<AnimationBehaviour>();
        _meleeAttack = new MeleeAttack(animationBehaviour);
        _rangeAttack = new RangeAttack(animationBehaviour);
        _currentAttack = _meleeAttack;
    }

    public void SetAiming(bool isAiming)
    {
        _currentAttack = isAiming ? _rangeAttack : _meleeAttack;
        //_animationBehaviour.SetAiming(isAiming);
    }

    public void PerformAttack()
    {
        _currentAttack?.Attack();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack input received");
    }
}