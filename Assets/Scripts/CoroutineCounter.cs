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
    private bool _isActive = false;

    private Coroutine _coroutine;

    public event Action<float> Changed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isActive)
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
        _isActive = true;
        _coroutine = StartCoroutine(Coroutine());
        Debug.Log("������� �������");
    }

    private void StopCounting()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        _isActive = false;
        Debug.Log("������� ����������. ������� ��������: " + _counter);
    }

    private IEnumerator Coroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_cooldownInSeconds);

        while (true)
        {
            _counter += _step;
            Debug.Log("������� �������� ��������: " + _counter);
            Changed?.Invoke(_counter);
            
            yield return wait;
        }
    }
}