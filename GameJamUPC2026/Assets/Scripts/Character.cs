using UnityEngine;

[RequireComponent(typeof(MoveBehaviour))]
[RequireComponent(typeof(AnimationBehaviour))]
[RequireComponent(typeof(AttackBehaviour))]
public class Character : MonoBehaviour
{
    protected MoveBehaviour _moveBehaviour;
    protected AnimationBehaviour _animationBehaviour;
    protected AttackBehaviour _attackBehaviour;

    private void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _animationBehaviour = GetComponent<AnimationBehaviour>();
        _attackBehaviour = GetComponent<AttackBehaviour>();
    }
}