using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageVisibilityChanger : MonoBehaviour
{
    [SerializeField] private Health _health;

    private float _visibilityDuration = 5f;
    private Image _image;
    private Color _startImageColor;
    private Coroutine _changeVisibilityCoroutine;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _startImageColor = _image.color;
    }

    private void OnEnable()
    {
        _health.HealthChanged += StartVisibilityChanging;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= StartVisibilityChanging;
    }

    private void StartVisibilityChanging()
    {
        if (_changeVisibilityCoroutine != null)
        {
            StopCoroutine(_changeVisibilityCoroutine);
        }

        _changeVisibilityCoroutine = StartCoroutine(ChangeVisibility());
    }

    private IEnumerator ChangeVisibility()
    {
        WaitForSeconds visibilityDuration = new WaitForSeconds(_visibilityDuration);
        Color visibilityColor = _image.color;
        int alphaValue = 255;

        visibilityColor.a = alphaValue;
        _image.color = visibilityColor;
        yield return visibilityDuration;
        _image.color = _startImageColor;
    }
}
