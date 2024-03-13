using System.Collections;
using UnityEngine;

public class SmoothlyHealthBar : HealthBar
{
    [SerializeField] private float _maxDelta;

    private Coroutine _setHealthBarSmoothlyCoroutine;

    protected override void SetHealthBarValue()
    {
        if(_setHealthBarSmoothlyCoroutine != null)
        {
            StopCoroutine(_setHealthBarSmoothlyCoroutine);
        }

        _setHealthBarSmoothlyCoroutine = StartCoroutine(SetHealthBarSmoothly());
    }

    private IEnumerator SetHealthBarSmoothly()
    {
        float barValue = Health.CurrentHealth / Health.MaxHealth;

        while (HealthImage.fillAmount != barValue)
        {
            HealthImage.fillAmount = Mathf.MoveTowards(HealthImage.fillAmount, barValue, _maxDelta);
            yield return null;
        }
    }
}
