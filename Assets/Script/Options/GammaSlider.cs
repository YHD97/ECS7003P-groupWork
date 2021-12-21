using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class GammaSlider : MonoBehaviour
{
    Slider slider
    {
        get { return GetComponent<Slider>(); }
    }

    [SerializeField]
    public Text percentageLabel;

    public Light2D globalLight;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = globalLight.intensity - 0.5f;

        UpdateValueOnChange(slider.value);

        slider.onValueChanged.AddListener(delegate
        {
            UpdateValueOnChange(slider.value);
        });
    }

    public void UpdateValueOnChange(float value) 
    {
        if(globalLight != null)
            globalLight.intensity = 0.5f + value;

        if(percentageLabel != null)
            percentageLabel.text = Mathf.Floor(value * 100.0f).ToString() + "%";
    }
}
