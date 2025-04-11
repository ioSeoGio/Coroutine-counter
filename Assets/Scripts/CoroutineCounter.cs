using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineCounter : MonoBehaviour
{
    private int _counter = 0;
    private int _step = 1;
    private float _cooldownInSeconds = 0.5f;
    private bool isActive = false;

    private Coroutine coroutine;

    public event Action<float> Changed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isActive)
            {
                StopCoroutine();
            }
            else
            {
                StartCoroutine();
            }
        }
    }

    private void StartCoroutine()
    {
        isActive = true;
        coroutine = StartCoroutine(Coroutine());
        Debug.Log("Счетчик запущен");
    }

    private void StopCoroutine()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        isActive = false;
        Debug.Log("Счетчик остановлен. Текущее значение: " + _counter);
    }

    private IEnumerator Coroutine()
    {
        while (true)
        {
            _counter += _step;
            Debug.Log("Текущее значение счетчика: " + _counter);
            Changed?.Invoke(_counter);
            
            yield return new WaitForSeconds(_cooldownInSeconds);
        }
    }
}