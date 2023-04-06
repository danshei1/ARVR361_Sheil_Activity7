using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MaterialsControls : MonoBehaviour
{
    public Slider smoothnessSlider;
    public TextMeshProUGUI smoothnessText;
    public Slider normalSlider;
    public TextMeshProUGUI normalText;
    public Slider occlusionSlider;
    public TextMeshProUGUI occlusionText;

    private float _smoothness;
    private float _normal;
    private float _occlusion;

    public List<Renderer> renderers = new List<Renderer>();

    private void Start()
    {
        smoothnessSlider.value = 1f;
        normalSlider.value = 1f;
        occlusionSlider.value = 1f;
    }

    public float Smoothness
    {
        get => _smoothness;
        set
        {
            SetFloatProperty("_Smoothness", smoothnessSlider.value);
            smoothnessText.text = smoothnessSlider.value.ToString("F2");
        }
    }

    public float Normal
    {
        get => _normal;
        set
        {
            SetFloatProperty("_BumpScale", normalSlider.value);
            normalText.text = normalSlider.value.ToString("F2");
        }
    }

    public float Occlusion
    {
        get => _occlusion;
        set
        {
            SetFloatProperty("_OcclusionStrength", occlusionSlider.value);
            occlusionText.text = occlusionSlider.value.ToString("F1");
        }
    }

    private void SetFloatProperty(string name, float value)
    {
        for (int i = 0; i < renderers.Count; i++)
        {
            renderers.ElementAt(i).material.SetFloat(name, value);
        }
    }
}