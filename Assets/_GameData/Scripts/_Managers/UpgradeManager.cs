using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance {get;private set;}
    [HideInInspector] public int income;
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] public UpgradeAble upgrade;
    private Button buton;
    [SerializeField] private Image image,backImage;
    [SerializeField] private Shadow shadow;
    [SerializeField] private string element;
    private void Awake()
    {
        Instance = this;
        buton = GetComponent<Button>();
        cost.text = upgrade.Cost.ToString();
        level.text = ("Level " + upgrade.Level).ToString();
        if(upgrade.elementName == "Income"){ income = (int)upgrade.value;}
        LevelControl();
    }
    public void Purchase()
    {
        if (CoinManager.Instance.yourMoney >= upgrade.Cost)
        {
            CoinManager.Instance.yourMoney -= upgrade.Cost;
            PlayerPrefs.SetInt("topmoney", CoinManager.Instance.yourMoney);
            CoinManager.Instance.m_CoinText.text = CoinManager.Instance.yourMoney.ToString();
            Upgrades();
            upgrade.Cost += (upgrade.defaultCost / 2);
            cost.text = upgrade.Cost.ToString();
            level.text = ("Level "+(++upgrade.Level)).ToString();
        }
        LevelControl();
    }
    public void LevelControl()
    {
        if (upgrade.Level == upgrade.borderLevel)
        {
            cost.text = "MAX".ToString();
            level.text = "Level MAX".ToString();
            buton.interactable = false;
        }
        if (PlayerPrefs.GetInt("topmoney") >= upgrade.Cost)
        {
            level.color = new Color(upgrade.color.x,upgrade.color.y,upgrade.color.z);
            image.color = new Color(upgrade.color.x,upgrade.color.y,upgrade.color.z,1);//upgrade.color;
            backImage.color = new Color(upgrade.color.x,upgrade.color.y,upgrade.color.z,1);//upgrade.backColor;
            shadow.effectColor = new Color(upgrade.shadowColor.x,upgrade.shadowColor.y,upgrade.shadowColor.z,1);//upgrade.shadowColor;
            //new Color(shadowcolor.x,shadowcolor.y,shadowcolor.z,1);//upgrade.shadowColor;
        }
        if (PlayerPrefs.GetInt("topmoney") < upgrade.Cost && element == upgrade.elementName){ MAXColor(); }
    }
    private void MAXColor()
    {
        level.color = new Color(.5f,.5f,.5f,1);
        image.color = new Color(.37f,.37f,.37f,1);
        backImage.color = new Color(.5f,.5f,.5f,1);
        shadow.effectColor = new Color(.3f,.3f,.3f,1);
    }
    private void Upgrades()
    {
        switch (upgrade.elementName)
        {
            case "Speed":
                upgrade.value += upgrade.defaultvalue * .1f;
                break;
            case "Pump":
                PumperManager.Instance.Enabling((int)upgrade.value);
                upgrade.value++;
                break;
            case "Income":
                upgrade.value += upgrade.defaultvalue * .1f;
                break;
            default:
                break;
        }   
    }
}