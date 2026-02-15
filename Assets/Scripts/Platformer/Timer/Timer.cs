using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _startingTime = 10f;

    private float _currentTime;

    [SerializeField] Text countDownTIme;

    private void Start()
    {
        _currentTime = _startingTime;

    }

    private void Update()
    {
        
    }


}
 
