public class MeleeAttack : IAttack
{
    private readonly AnimationBehaviour _animationBehaviour;

    public MeleeAttack(AnimationBehaviour animationBehaviour)
    {
        _animationBehaviour = animationBehaviour;
    }

    public void Attack()
    {
        //_animationBehaviour.TriggerMeleeAttack();
    }
}
