using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChange : MonoBehaviour
{
    [SerializeField] string _nextLevel;
    [SerializeField] Canvas _blackScreenCanvas;

    //void Start()
    //{
    //    StartCoroutine(LightenScreen(1f));
    //}

    //IEnumerator LightenScreen(float duration)
    //{
    //    Image blackScreen = _blackScreenCanvas.GetComponentInChildren<Image>();
    //    float time = 0;
    //    var tempColor = blackScreen.color;
    //    var targetColor = blackScreen.color;
    //    targetColor.a = 0;
    //    float t;

    //    while (time <= duration)
    //    {
    //        t = time / duration;
    //        t = t * t * (3f - 2f * t);
    //        tempColor = Color.Lerp(blackScreen.color, targetColor, t);
    //        blackScreen.color = tempColor;
    //        time += Time.unscaledDeltaTime;
    //        yield return null;
    //    }

    //    tempColor.a = 0f;
    //    blackScreen.color = tempColor;
    //    _blackScreenCanvas.gameObject.SetActive(false);
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().DisableMovement();
            _blackScreenCanvas.gameObject.SetActive(true);
            StartCoroutine(DarkenScreen(20f));
            Invoke("ChangeLevel", 3f);           
        }     
    }

    IEnumerator DarkenScreen(float duration)
    {
        Image blackScreen = _blackScreenCanvas.GetComponentInChildren<Image>();
        float time = 0;
        var tempColor = blackScreen.color;
        var targetColor = blackScreen.color;
        targetColor.a = 1;
        float t;

        while (time < duration)
        {
            t = time / duration;
            t = t * t * (3f - 2f * t);
            tempColor = Color.Lerp(blackScreen.color, targetColor, t);
            blackScreen.color = tempColor;
            time += Time.deltaTime;
            yield return null;
        }

        tempColor.a = 1f;
        blackScreen.color = tempColor;
    }

    void ChangeLevel() => SceneManager.LoadScene(_nextLevel);
}