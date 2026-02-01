using UnityEditor.Animations;
using UnityEngine;

public class AnimationControllerSoul : MonoBehaviour
{

    [SerializeField] private GameObject soulShield;
    [SerializeField] private GameObject soulIdle;
    [SerializeField] private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void ActiveShield()
    {
        _animator.SetBool("ActivateShield", true);
        soulIdle.SetActive(false);
        soulShield.SetActive(true);
    }
    public void DesactivateShield()
    {
        _animator.SetBool("ActivateShield", false);
        soulIdle.SetActive(true);
        soulShield.SetActive(false);
    }
}
