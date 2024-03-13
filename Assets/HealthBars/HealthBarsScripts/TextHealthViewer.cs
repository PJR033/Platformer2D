using TMPro;

public class TextHealthViewer : HealthChangeSubscriber
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        SetHealthBarValue();
    }

    protected override void SetHealthBarValue()
    {
        string currentHealth = Health.CurrentHealth.ToString();
        string maxHealth = Health.MaxHealth.ToString();

        _text.text = "Health - " + currentHealth + "/" + maxHealth;
    }
}
