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
    private bool isCounting = false;

    private Coroutine countingCoroutine;

    public event Action<float> CounterChanged;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isCounting)
            {
                StopCounting();
            }
            else
            {
                StartCounting();
            }
        }
    }

    private void StartCounting()
    {
        isCounting = true;
        countingCoroutine = StartCoroutine(CountCoroutine());
        Debug.Log("Счетчик запущен");
    }

    private void StopCounting()
    {
        if (countingCoroutine != null)
        {
            StopCoroutine(countingCoroutine);
        }

        isCounting = false;
        Debug.Log("Счетчик остановлен. Текущее значение: " + _counter);
    }

    private IEnumerator CountCoroutine()
    {
        while (true)
        {
            _counter += _step;
            Debug.Log("Текущее значение счетчика: " + _counter);
            CounterChanged?.Invoke(_counter);
            
            yield return new WaitForSeconds(_cooldownInSeconds);
        }
    }
}