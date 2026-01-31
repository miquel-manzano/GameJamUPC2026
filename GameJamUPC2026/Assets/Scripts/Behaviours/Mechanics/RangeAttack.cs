public class RangeAttack : IAttack
{
    private readonly AnimationBehaviour _animationBehaviour;

    public RangeAttack(AnimationBehaviour animationBehaviour)
    {
        _animationBehaviour = animationBehaviour;
    }

    public void Attack()
    {
        _animationBehaviour.TriggerRangeAttack();
    }
}
