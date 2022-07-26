using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;

[ExecuteInEditMode]
public class CharacterAppearance : MonoBehaviour
{
    #region parameters
    #region basic
    [OnValueChanged(nameof(UpdateGender))]
    public bool isFemale;


    [TabGroup("Main", "Basic")]
    [HorizontalGroup("Main/Basic/HeadBox")]
    [ValueDropdown(nameof(GetHeads), IsUniqueList = true)]
    [OnValueChanged(nameof(UpdateHead))]
    public int Head;

    [HorizontalGroup("Main/Basic/HeadBox")]
    [Button("<", buttonSize: ButtonSizes.Small)]
    public void HeadPrev()
    {
        Prev(ref Head, GetHeads(), UpdateHead);
    }

    [HorizontalGroup("Main/Basic/HeadBox")]
    [Button(">", buttonSize: ButtonSizes.Small)]
    public void HeadNext()
    {
        Next(ref Head, GetHeads(), UpdateHead);
    }


    [TabGroup("Main", "Basic")]
    [HorizontalGroup("Main/Basic/HairBox")]
    [ValueDropdown(nameof(GetHair), IsUniqueList = true)]
    [OnValueChanged(nameof(UpdateHair))]
    public int Hair;

    [HorizontalGroup("Main/Basic/HairBox")]
    [Button("<", buttonSize: ButtonSizes.Small)]
    public void HairPrev()
    {
        Prev(ref Hair, GetHair(), UpdateHair);
    }

    [HorizontalGroup("Main/Basic/HairBox")]
    [Button(">", buttonSize: ButtonSizes.Small)]
    public void HairNext()
    {
        Next(ref Hair, GetHair(), UpdateHair);
    }


    [TabGroup("Main", "Basic")]
    [HorizontalGroup("Main/Basic/EyebrowsBox")]
    [ValueDropdown(nameof(GetEyebrows), IsUniqueList = true)]
    [OnValueChanged(nameof(UpdateEyebrows))]
    public int Eyebrows;

    [HorizontalGroup("Main/Basic/EyebrowsBox")]
    [Button("<", buttonSize: ButtonSizes.Small)]
    public void EyebrowsPrev()
    {
        Prev(ref Eyebrows, GetEyebrows(), UpdateEyebrows);
    }

    [HorizontalGroup("Main/Basic/EyebrowsBox")]
    [Button(">", buttonSize: ButtonSizes.Small)]
    public void EyebrowsNext()
    {
        Next(ref Eyebrows, GetEyebrows(), UpdateEyebrows);
    }


    [TabGroup("Main", "Basic")]
    [HorizontalGroup("Main/Basic/FacialHairBox")]
    [ValueDropdown(nameof(GetFacialHair), IsUniqueList = true)]
    [OnValueChanged(nameof(UpdateFacialHair))]
    public int FacialHair;

    [HorizontalGroup("Main/Basic/FacialHairBox")]
    [Button("<", buttonSize: ButtonSizes.Small)]
    public void FacialHairPrev()
    {
        Prev(ref FacialHair, GetFacialHair(), UpdateFacialHair);
    }

    [HorizontalGroup("Main/Basic/FacialHairBox")]
    [Button(">", buttonSize: ButtonSizes.Small)]
    public void FacialHairNext()
    {
        Next(ref FacialHair, GetFacialHair(), UpdateFacialHair);
    }
    #endregion

    #region armour

    [TabGroup("Main", "Armour")]
    [HorizontalGroup("Main/Armour/HelmetBox")]
    [ValueDropdown(nameof(GetHelmets), IsUniqueList = true)]
    [OnValueChanged(nameof(UpdateHelmet))]
    public int Helmet;

    [HorizontalGroup("Main/Armour/HelmetBox")]
    [Button("<", buttonSize: ButtonSizes.Small)]
    public void HelmetPrev()
    {
        Prev(ref Helmet, GetHelmets(), UpdateHelmet);
    }

    [HorizontalGroup("Main/Armour/HelmetBox")]
    [Button(">", buttonSize: ButtonSizes.Small)]
    public void HelmetNext()
    {
        Next(ref Helmet, GetHelmets(), UpdateHelmet);
    }

    [TabGroup("Main", "Armour")]
    [ValueDropdown(nameof(GetTorsos), IsUniqueList = true)]
    [OnValueChanged(nameof(UpdateTorso))]
    public int Torso;


    [TabGroup("Main", "Armour")]
    [LabelText("Left Upper Arm")]
    [ValueDropdown(nameof(GetUpperArmLeft), IsUniqueList = true)]
    [OnValueChanged(nameof(GetUpperArmLeft))]
    public int UpperArmLeft;


    [TabGroup("Main", "Armour")]
    [LabelText("Right Upper Arm")]
    [ValueDropdown(nameof(GetUpperArmRight), IsUniqueList = true)]
    [OnValueChanged(nameof(UpdateUpperArmRight))]
    public int UpperArmRight;


    [TabGroup("Main", "Armour")]
    [LabelText("Left Lower Arm")]
    [ValueDropdown(nameof(GetLowerArmLeft), IsUniqueList = true)]
    [OnValueChanged(nameof(UpdateLowerArmLeft))]
    public int LowerArmLeft;


    [TabGroup("Main", "Armour")]
    [LabelText("Right Lower Arm")]
    [ValueDropdown(nameof(GetLowerArmRight), IsUniqueList = true)]
    [OnValueChanged(nameof(UpdateLowerArmRight))]
    public int LowerArmRight;


    [TabGroup("Main", "Armour")]
    [LabelText("Left Hand")]
    [ValueDropdown(nameof(GetHandLeft), IsUniqueList = true)]
    [OnValueChanged(nameof(UpdateHandLeft))]
    public int HandLeft;


    [TabGroup("Main", "Armour")]
    [LabelText("Right Hand")]
    [ValueDropdown(nameof(GetHandRight), IsUniqueList = true)]
    [OnValueChanged(nameof(UpdateHandRight))]
    public int HandRight;


    [TabGroup("Main", "Armour")]
    [LabelText("Left Foot")]
    [ValueDropdown(nameof(GetLegLeft), IsUniqueList = true)]
    [OnValueChanged(nameof(UpdateLegLeft))]
    public int LegLeft;


    [TabGroup("Main", "Armour")]
    [LabelText("Right Foot")]
    [ValueDropdown(nameof(GetLegRight), IsUniqueList = true)]
    [OnValueChanged(nameof(UpdateLegRight))]
    public int LegRight;


    [TabGroup("Main", "Armour")]
    [LabelText("Legs")]
    [ValueDropdown(nameof(GetHips), IsUniqueList = true)]
    [OnValueChanged(nameof(UpdateHips))]
    public int Hips;


    [TabGroup("Main", "Armour")]
    [OnValueChanged(nameof(ToggleArmor))]
    public bool HideArmor;

    public void ToggleArmor()
    {
        if (HideArmor)
        {
            UpdatePart(BodyPart.Helmet, -1);
            UpdatePart(BodyPart.Head, Head);
            UpdatePart(BodyPart.Eyebrows, Eyebrows);
            UpdatePart(BodyPart.FacialHair, FacialHair);
            UpdatePart(BodyPart.Hair, Hair);
            UpdatePart(BodyPart.Torso, 0);
            UpdatePart(BodyPart.UpperArmRight, 0);
            UpdatePart(BodyPart.UpperArmLeft, 0);
            UpdatePart(BodyPart.LowerArmLeft, 0);
            UpdatePart(BodyPart.LowerArmRight, 0);
            UpdatePart(BodyPart.HandLeft, 0);
            UpdatePart(BodyPart.HandRight, 0);
            UpdatePart(BodyPart.Hips, 0);
            UpdatePart(BodyPart.LegLeft, 0);
            UpdatePart(BodyPart.LegRight, 0);

        }
        else
        {
            UpdateHelmet();
            UpdateTorso();
            UpdateUpperArmLeft();
            UpdateUpperArmRight();
            UpdateLowerArmLeft();
            UpdateLowerArmRight();
            UpdateHandLeft();
            UpdateHandRight();
            UpdateLegLeft();
            UpdateLegRight();
            UpdateHips();
        }

    }

    #endregion

    #region Colours
    [TabGroup("Main", "Colours")]
    [OnValueChanged(nameof(MaterialChanged))]
    public Material Material;

    [TabGroup("Main", "Colours")]
    [OnValueChanged(nameof(Color_Hair_Changed))]
    public Color Color_Hair;

    [TabGroup("Main", "Colours")]
    [OnValueChanged(nameof(Color_Skin_Changed))]
    public Color Color_Skin;

    [TabGroup("Main", "Colours")]
    [OnValueChanged(nameof(Color_Stubble_Changed))]
    public Color Color_Stubble;

    [TabGroup("Main", "Colours")]
    [OnValueChanged(nameof(Color_Scar_Changed))]
    public Color Color_Scar;

    [TabGroup("Main", "Colours")]
    [OnValueChanged(nameof(Color_BodyArt_Changed))]
    public Color Color_BodyArt;

    [TabGroup("Main", "Colours")]
    [OnValueChanged(nameof(Color_Eyes_Changed))]
    public Color Color_Eyes;

    #endregion

    #region boilerplate
    public void Prev(ref int prop, IEnumerable<ValueDropdownItem<int>> options, Action update)
    {
        if (prop == options.First().Value)
            prop = options.Last().Value;
        else
            prop--;
        update();
    }

    public void Next(ref int prop, IEnumerable<ValueDropdownItem<int>> options, Action update)
    {
        if (prop == options.Last().Value)
            prop = options.First().Value;
        else
            prop++;
        update();
    }
    #endregion
    #endregion

    #region colours

    public void MaterialChanged()
    {
        var mat = new Material(Material);
        Material = mat;

        Color_Hair = Material.GetColor("_Color_Hair");
        Color_Skin = Material.GetColor("_Color_Skin");
        Color_Stubble = Material.GetColor("_Color_Stubble");
        Color_Scar = Material.GetColor("_Color_Scar");
        Color_BodyArt = Material.GetColor("_Color_BodyArt");
        Color_Eyes = Material.GetColor("_Color_Eyes");
        UpdateMaterials(transform);
    }

    public void Color_Hair_Changed()
    {
        ColorChanged("_Color_Hair", Color_Hair);
    }

    public void Color_Skin_Changed()
    {
        ColorChanged("_Color_Skin", Color_Skin);
    }

    public void Color_Stubble_Changed()
    {
        ColorChanged("_Color_Stubble", Color_Stubble);
    }

    public void Color_Scar_Changed()
    {
        ColorChanged("_Color_Scar", Color_Scar);
    }

    public void Color_BodyArt_Changed()
    {
        ColorChanged("_Color_BodyArt", Color_BodyArt);
    }

    public void Color_Eyes_Changed()
    {
        ColorChanged("_Color_Eyes", Color_Eyes);
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
    #endregion

    #region paths
    private Dictionary<BodyPart, (bool unisex, string[] paths)> PartInfo = new Dictionary<BodyPart, (bool unisex, string[] paths)>()
    {
        [BodyPart.Hair] = (true, new[] { "01_Hair" }),

        [BodyPart.Head] = (false, new[] { "00_Head", "Head_All_Elements" }),
        [BodyPart.Eyebrows] = (false, new[] { "01_Eyebrows" }),
        [BodyPart.FacialHair] = (false, new[] { "02_FacialHair" }),
        [BodyPart.Helmet] = (false, new[] { "00_Head", "Head_No_Elements" }),
        [BodyPart.Torso] = (false, new[] { "03_Torso" }),
        [BodyPart.UpperArmLeft] = (false, new[] { "05_Arm_Upper_Left" }),
        [BodyPart.UpperArmRight] = (false, new[] { "04_Arm_Upper_Right" }),
        [BodyPart.LowerArmLeft] = (false, new[] { "07_Arm_Lower_Left" }),
        [BodyPart.LowerArmRight] = (false, new[] { "06_Arm_Lower_Right" }),
        [BodyPart.HandLeft] = (false, new[] { "09_Hand_Left" }),
        [BodyPart.HandRight] = (false, new[] { "08_Hand_Right" }),
        [BodyPart.LegLeft] = (false, new[] { "12_Leg_Left" }),
        [BodyPart.LegRight] = (false, new[] { "11_Leg_Right" }),
        [BodyPart.Hips] = (false, new[] { "10_Hips" }),
    };
    #endregion

    #region options
    public IEnumerable<ValueDropdownItem<int>> GetHeads()
    {
        return GetOptions(Get(BodyPart.Head));
    }

    public IEnumerable<ValueDropdownItem<int>> GetEyebrows()
    {
        return GetOptions(Get(BodyPart.Eyebrows), true);
    }

    public IEnumerable<ValueDropdownItem<int>> GetHair()
    {
        return GetOptions(Get(BodyPart.Hair), true);
    }

    public IEnumerable<ValueDropdownItem<int>> GetFacialHair()
    {
        return GetOptions(Get(BodyPart.FacialHair));
    }

    public IEnumerable<ValueDropdownItem<int>> GetHelmets()
    {
        return GetOptions(Get(BodyPart.Helmet), true);
    }

    public IEnumerable<ValueDropdownItem<int>> GetTorsos()
    {
        return GetOptions(Get(BodyPart.Torso));
    }

    public IEnumerable<ValueDropdownItem<int>> GetUpperArmLeft()
    {
        return GetOptions(Get(BodyPart.UpperArmLeft));
    }

    public IEnumerable<ValueDropdownItem<int>> GetUpperArmRight()
    {
        return GetOptions(Get(BodyPart.UpperArmRight));
    }

    public IEnumerable<ValueDropdownItem<int>> GetLowerArmLeft()
    {
        return GetOptions(Get(BodyPart.LowerArmLeft));
    }

    public IEnumerable<ValueDropdownItem<int>> GetLowerArmRight()
    {
        return GetOptions(Get(BodyPart.LowerArmRight));
    }

    public IEnumerable<ValueDropdownItem<int>> GetHandLeft()
    {
        return GetOptions(Get(BodyPart.HandLeft));
    }

    public IEnumerable<ValueDropdownItem<int>> GetHandRight()
    {
        return GetOptions(Get(BodyPart.HandRight));
    }

    public IEnumerable<ValueDropdownItem<int>> GetLegLeft()
    {
        return GetOptions(Get(BodyPart.LegLeft));
    }

    public IEnumerable<ValueDropdownItem<int>> GetLegRight()
    {
        return GetOptions(Get(BodyPart.LegRight));
    }

    public IEnumerable<ValueDropdownItem<int>> GetHips()
    {
        return GetOptions(Get(BodyPart.Hips));
    }

    #region boilerplate
    public IEnumerable<ValueDropdownItem<int>> GetOptions(List<GameObject> options, bool addEmpty = false)
    {
        if (addEmpty)
            yield return new ValueDropdownItem<int>("None", -1);

        for (int i = 0; i < options.Count; i++)
            yield return new ValueDropdownItem<int>((i + 1).ToString(), i);
    }

    public List<GameObject> GetAll(BodyPart part) => GetAll(PartInfo[part].unisex, PartInfo[part].paths);

    public List<GameObject> GetAll(bool unisex, params string[] paths)
    {
        if (unisex)
            return Get(isFemale, true, paths);
        else
        {
            return Get(true, false, paths).Concat(Get(false, false, paths)).ToList();
        }
    }

    public List<GameObject> Get(BodyPart part) => Get(isFemale, PartInfo[part].unisex, PartInfo[part].paths);

    public List<GameObject> Get(bool female, bool unisex, params string[] paths)
    {
        var prefix = unisex ? "All" : female ? "Female" : "Male";
        Transform current = transform.Find("Modular_Characters").Find($"{prefix}_Parts");
        if (unisex)
            prefix = "All";
        foreach (var p in paths)
        {
            current = current.Find($"{prefix}_{p}");
        }

        var lst = new List<GameObject>();
        foreach (Transform t in current)
        {
            lst.Add(t.gameObject);
        }
        return lst;
    }

    public List<GameObject> Get(params string[] paths) => Get(isFemale, false, paths);
    #endregion
    #endregion

    #region updaters
    public void UpdateGender()
    {
        UpdateHead();
        UpdateEyebrows();
        UpdateFacialHair();
        UpdateTorso();
        UpdateUpperArmLeft();
        UpdateUpperArmRight();
        UpdateLowerArmLeft();
        UpdateLowerArmRight();
        UpdateHandLeft();
        UpdateHandRight();
        UpdateLegLeft();
        UpdateLegRight();
        UpdateHips();
    }

    public void UpdateHead()
    {
        UpdatePart(BodyPart.Head, Helmet != -1  ? -1 : Head);
    }

    public void UpdateEyebrows()
    {
        UpdatePart(BodyPart.Eyebrows, Helmet != -1 ? -1 : Eyebrows);
    }

    public void UpdateHair()
    {
        UpdatePart(BodyPart.Hair, Helmet != -1 ? -1 : Hair);
    }

    public void UpdateFacialHair()
    {
        UpdatePart(BodyPart.FacialHair, Helmet != -1 ? -1 : FacialHair, isFemale);
    }

    public void UpdateHelmet()
    {
        UpdatePart(BodyPart.Helmet, Helmet);
        UpdateHead();
        UpdateHair();
        UpdateEyebrows();
        UpdateFacialHair();
    }

    public void UpdateTorso()
    {
        UpdatePart(BodyPart.Torso, Torso);
    }

    public void UpdateUpperArmLeft()
    {
        UpdatePart(BodyPart.UpperArmLeft, UpperArmLeft);
    }

    public void UpdateUpperArmRight()
    {
        UpdatePart(BodyPart.UpperArmRight, UpperArmRight);
    }

    public void UpdateLowerArmLeft()
    {
        UpdatePart(BodyPart.LowerArmLeft, LowerArmLeft);
    }

    public void UpdateLowerArmRight()
    {
        UpdatePart(BodyPart.LowerArmRight, LowerArmRight);
    }

    public void UpdateHandLeft()
    {
        UpdatePart(BodyPart.HandLeft, HandLeft);
    }

    public void UpdateHandRight()
    {
        UpdatePart(BodyPart.HandRight, HandRight);
    }

    public void UpdateLegLeft()
    {
        UpdatePart(BodyPart.LegLeft, LegLeft);
    }

    public void UpdateLegRight()
    {
        UpdatePart(BodyPart.LegRight, LegRight);
    }

    public void UpdateHips()
    {
        UpdatePart(BodyPart.Hips, Hips);
    }

    #region boilerplate
    public void UpdatePart(BodyPart bodyPart, int index, bool remove = false)
    {
        foreach (var p in GetAll(bodyPart))
            p.SetActive(false);
        if (!remove && index >= 0)
            Get(bodyPart)[index].SetActive(true);
    }
    #endregion
    #endregion
}
