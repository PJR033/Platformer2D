using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : HealthChangeSubscriber
{
    protected Image HealthImage;

    private void Awake()
    {
        HealthImage = GetComponent<Image>();
    }

    protected override void SetHealthBarValue()
    {
        float barValue = Health.CurrentHealth / Health.MaxHealth;

        HealthImage.fillAmount = barValue;
    }
}
