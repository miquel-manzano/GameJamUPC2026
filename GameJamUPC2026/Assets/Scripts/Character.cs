using UnityEngine;

[RequireComponent(typeof(MoveBehaviour))]
[RequireComponent(typeof(AnimationBehaviour))]
public class Character : MonoBehaviour
{
    protected MoveBehaviour _moveBehaviour;
    protected AnimationBehaviour _animationBehaviour;

    private void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _animationBehaviour = GetComponent<AnimationBehaviour>();
    }
}