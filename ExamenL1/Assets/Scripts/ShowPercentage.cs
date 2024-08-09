using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowPercentage : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private TextMeshProUGUI textPercentage;

    private float max = 100f;
    private float current = 1f;
    [SerializeField] private float percentageNumber;

    private void Start()
    {
        // Set the slider values equal to the maximum stamina in start
        slider.maxValue = max;
        // Set the currrent to the desired percentage
        StartCoroutine(BuildUp());
    }

    private void Update()
    {

        // Display the text on screen
        textPercentage.text = slider.value.ToString() + "%";
    }

    private IEnumerator BuildUp()
    {
        yield return new WaitForSeconds(0.3f);

        // While there is stamina to use, add it back gradually 
        while (current < percentageNumber)
        {
            current += max / 100;
            slider.value = percentageNumber;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
