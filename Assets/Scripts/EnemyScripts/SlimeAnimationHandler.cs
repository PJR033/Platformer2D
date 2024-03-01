using UnityEngine;

[RequireComponent(typeof(Health))]
public class SlimeAnimationHandler : MonoBehaviour
{
    private int _isDead = Animator.StringToHash("isDead");
    private int _hurted = Animator.StringToHash("hurted");

    private Animator _animator;
    private Health _slimeHealth;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _slimeHealth = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _slimeHealth.ObjectDead += StartDeathAnimation;
        _slimeHealth.HealthHurted += StartHurtedAnimation;
    }

    private void OnDisable()
    {
        _slimeHealth.ObjectDead -= StartDeathAnimation;
        _slimeHealth.HealthHurted -= StartHurtedAnimation;
    }

    private void StartHurtedAnimation()
    {
        _animator.SetTrigger(_hurted);
    }

    private void StartDeathAnimation()
    {
        _animator.SetBool(_isDead, true);
    }
}
