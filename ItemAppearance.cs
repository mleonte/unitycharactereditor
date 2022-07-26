using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ItemAppearance : MonoBehaviour
{

    [TabGroup("Main", "Colours")]
    [OnValueChanged(nameof(MaterialChanged))]
    public Material Material;

    [TabGroup("Main", "Colours")]
    [OnValueChanged(nameof(Color_Primary_Changed))]
    public Color Color_Primary;

    [TabGroup("Main", "Colours")]
    [OnValueChanged(nameof(Color_Secondary_Changed))]
    public Color Color_Secondary;

    [TabGroup("Main", "Colours")]
    [OnValueChanged(nameof(Color_Leather_Primary_Changed))]
    public Color Color_Leather_Primary;

    [TabGroup("Main", "Colours")]
    [OnValueChanged(nameof(Color_Leather_Secondary_Changed))]
    public Color Color_Leather_Secondary;

    [TabGroup("Main", "Colours")]
    [OnValueChanged(nameof(Color_Metal_Dark_Changed))]
    public Color Color_Metal_Dark;

    [TabGroup("Main", "Colours")]
    [OnValueChanged(nameof(Color_Metal_Secondary_Changed))]
    public Color Color_Metal_Secondary;


    public void MaterialChanged()
    {
        var mat = new Material(Material);
        Material = mat;

        Color_Primary = Material.GetColor("_Color_Primary");
        Color_Secondary = Material.GetColor("_Color_Secondary");
        Color_Leather_Primary = Material.GetColor("_Color_Leather_Primary");
        Color_Leather_Secondary = Material.GetColor("_Color_Leather_Secondary");
        Color_Metal_Dark = Material.GetColor("_Color_Metal_Dark");
        Color_Metal_Secondary = Material.GetColor("_Color_Metal_Secondary");
        UpdateMaterials(transform);
    }

    public void Color_Primary_Changed()
    {
        ColorChanged("_Color_Primary", Color_Primary);
    }

    public void Color_Secondary_Changed()
    {
        ColorChanged("_Color_Secondary", Color_Secondary);
    }

    public void Color_Leather_Primary_Changed()
    {
        ColorChanged("_Color_Leather_Primary", Color_Leather_Primary);
    }

    public void Color_Leather_Secondary_Changed()
    {
        ColorChanged("_Color_Leather_Secondary", Color_Leather_Secondary);
    }

    public void Color_Metal_Dark_Changed()
    {
        ColorChanged("_Color_Metal_Dark", Color_Metal_Dark);
    }

    public void Color_Metal_Secondary_Changed()
    {
        ColorChanged("_Color_Metal_Secondary", Color_Metal_Secondary);
    }

    public void ColorChanged(string id, Color color)
    {
        Material.SetColor(id, color);
        UpdateMaterials(transform);
    }

    private void UpdateMaterials(Transform tr)
    {
        var renderer = tr.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = Material;
        }
        foreach (Transform t in tr)
        {
            UpdateMaterials(t);
        }
    }
}
