using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image _foregroundImage;
    [SerializeField] float _updateSpeedSeconds = 0.5f;

    public void HandleHealthChanged(float percent)
    {
        StartCoroutine(ChangeToPercentage(percent));
    }

    IEnumerator ChangeToPercentage(float percent)
    {
        float preChangePercent = _foregroundImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < _updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;

            Mathf.Lerp(preChangePercent, percent, elapsed / _updateSpeedSeconds);
            yield return null;
        }

        _foregroundImage.fillAmount = percent;
    }

    void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}
