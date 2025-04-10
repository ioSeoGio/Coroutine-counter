using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private CoroutineCounter _coroutineCounter;

    private void OnEnable()
    {
        _coroutineCounter.CounterChanged += DisplayCounter;
    }

    private void OnDisable()
    {
        _coroutineCounter.CounterChanged -= DisplayCounter;
    }

    private void DisplayCounter(float newCounter)
    {
        _counterText.text = "—четчик: " + newCounter;
    }
}
