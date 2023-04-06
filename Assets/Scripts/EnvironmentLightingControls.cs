using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class EnvironmentLightingControls : MonoBehaviour
{
    public Toggle useSkyboxToggle;
    public Toggle enableFog;
    public Slider skyboxIntensitySlider;
    public TextMeshProUGUI skyboxIntensityText;

    public bool EnableFog
    {
        get => RenderSettings.fog;
        set => RenderSettings.fog = value;
    }


    public bool UseSkybox
    {
        get => (RenderSettings.ambientMode == AmbientMode.Skybox);
        set
        {
            RenderSettings.ambientMode = (value) ?
               AmbientMode.Skybox : AmbientMode.Flat;
            skyboxIntensitySlider.interactable = value;
            skyboxIntensityText.gameObject.SetActive(value);
        }
    }


    public float SkyboxIntensity
    {
        get => RenderSettings.ambientIntensity;
        set
        {
            RenderSettings.ambientIntensity = skyboxIntensitySlider.value;
            skyboxIntensityText.SetText(skyboxIntensitySlider.value.ToString("F1"));
            Debug.Log(value.ToString("F1"));
        }
    }

    private void Start()
    {
        useSkyboxToggle.isOn = UseSkybox;
        skyboxIntensitySlider.value = SkyboxIntensity;
        enableFog.isOn = EnableFog;
    }
}