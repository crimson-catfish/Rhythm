using UnityEngine;
using TMPro;
using System.ComponentModel;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text frameRateText;
    
    public float avgFrameRate = 0f;


    public void Start()
    {
        Application.targetFrameRate = 300;
    }

    public void Update()
    {
        avgFrameRate = Time.frameCount / Time.time;
        frameRateText.text = avgFrameRate.ToString("0.0") + " fps";
    }
}
