using UnityEngine;

public abstract class HealthChangeSubscriber : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.HealthChanged += SetHealthBarValue;
    }

    private void OnDisable()
    {
        Health.HealthChanged -= SetHealthBarValue;
    }

    protected abstract void SetHealthBarValue();
}
