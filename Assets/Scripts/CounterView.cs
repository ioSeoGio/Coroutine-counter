using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private CoroutineCounter _coroutineCounter;

    private void OnEnable()
    {
        _coroutineCounter.Changed += Display;
    }

    private void OnDisable()
    {
        _coroutineCounter.Changed -= Display;
    }

    private void Display(float value)
    {
        _text.text = "—четчик: " + value;
    }
}
