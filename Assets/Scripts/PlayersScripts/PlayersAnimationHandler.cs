using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayersMovement))]
[RequireComponent(typeof(PlayersAttacker))]
[RequireComponent(typeof(Health))]

public class PlayersAnimationHandler : MonoBehaviour
{
    private int _isRunning = Animator.StringToHash("isRunning");
    private int _attack = Animator.StringToHash("attack");
    private int _hurted = Animator.StringToHash("hurted");
    private int _isJumping = Animator.StringToHash("isJumping");
    private int _isDead = Animator.StringToHash("isDead");

    private Animator _animator;
    private PlayersMovement _playersMovement;
    private PlayersAttacker _playersAttacker;
    private Health _playersHealth;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playersMovement = GetComponent<PlayersMovement>();
        _playersAttacker = GetComponent<PlayersAttacker>();
        _playersHealth = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _playersMovement.JumpHappened += StartJumpingAnimation;
        _playersMovement.MovementHappened += StartRunningAnimation;
        _playersMovement.MovementStoped += StopRunningAnimation;
        _playersAttacker.AttackStarted += StartAttackAnimation;
        _playersHealth.ObjectDead += StartDeathAnimation;
        _playersHealth.HealthHurted += StartHurtedAnimation;
    }

    private void OnDisable()
    {
        _playersMovement.JumpHappened -= StartJumpingAnimation;
        _playersMovement.MovementHappened -= StartRunningAnimation;
        _playersMovement.MovementStoped -= StopRunningAnimation;
        _playersAttacker.AttackStarted -= StartAttackAnimation;
        _playersHealth.ObjectDead -= StartDeathAnimation;
        _playersHealth.HealthHurted -= StartHurtedAnimation;
    }

    private void StartRunningAnimation()
    {
        _animator.SetBool(_isRunning, true);
    }

    private void StopRunningAnimation()
    {
        _animator.SetBool(_isRunning, false);
    }

    private void StartDeathAnimation()
    {
        _animator.SetBool(_isDead, true);
    }

    private void StartJumpingAnimation()
    {
        _animator.SetTrigger(_isJumping);
    }

    private void StartAttackAnimation()
    {
        _animator.SetTrigger(_attack);
    }

    private void StartHurtedAnimation()
    {
        _animator.SetTrigger(_hurted);
    }
}
