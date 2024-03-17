using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class VampicAura : MonoBehaviour
{
    [SerializeField] private float _auraRadius;
    [SerializeField] private float _vampiricDamage;
    [SerializeField] private LayerMask _layerMask;

    private Health _health;
    private float _duration = 6f;
    private float _damageDelay = 0.02f;
    private float _cooldown = 8f;
    private float _nextActionTime;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        Activate();
    }

    private void Activate()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= _nextActionTime)
        {
            StartCoroutine(StealHealth());
        }
    }

    private IEnumerator StealHealth()
    {
        WaitForSeconds cooldown = new WaitForSeconds(_cooldown);
        WaitForSeconds damageDelay = new WaitForSeconds(_damageDelay);
        float ticksCount = _duration / _damageDelay;

        for (int i = 0; i < ticksCount; i++)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _auraRadius, _layerMask);
            List<Collider2D> targetEnemies;

            targetEnemies = FindTargetEnemies(enemies);
            DealDamage(targetEnemies);

            yield return damageDelay;
        }

        _nextActionTime = Time.time + _cooldown;
        yield return cooldown;
    }

    private List<Collider2D> FindTargetEnemies(Collider2D[] enemies)
    {
        Dictionary<Collider2D, float> distanceEnemies = new Dictionary<Collider2D, float>();

        foreach (Collider2D enemy in enemies)
        {
            distanceEnemies.Add(enemy, Vector2.Distance(transform.position, enemy.transform.position));
        }

        float minDistance = distanceEnemies.Values.Min();
        List<Collider2D> targetEnemies = distanceEnemies.Where(enemy => enemy.Value == minDistance).Select(enemy => enemy.Key).ToList();
        return targetEnemies;
    }

    private void DealDamage(List<Collider2D> targetEnemies)
    {
        foreach (Collider2D enemy in targetEnemies)
        {
            if (enemy.TryGetComponent(out Health enemyHealth))
            {
                enemyHealth.TakeDamage(_vampiricDamage);
                _health.TakeHeal(_vampiricDamage);
            }
        }
    }
}
