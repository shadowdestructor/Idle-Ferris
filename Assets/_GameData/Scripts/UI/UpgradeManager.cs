using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance {get;private set;}
    [HideInInspector] public int income;
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] public UpgradeAble upgrade;
    private Button buton;
    [SerializeField] private Image image;
    private Shadow shadow;
    [SerializeField] private string element;
    private void Awake()
    {
        Instance = this;
        buton = GetComponent<Button>();
        shadow = GetComponent<Shadow>();
        cost.text = upgrade.Cost.ToString();
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
        }
        LevelControl();
    }
    public void LevelControl()
    {
        /*if (upgrade.Level == upgrade.borderLevel)
        {
            cost.text = "MAX".ToString();
            buton.interactable = false;
        }*/
        if (PlayerPrefs.GetInt("topmoney") >= upgrade.Cost)
        {
            //image.color = new Color(.4392157f,.4862745f,.6745098f,1);
            //shadow.effectColor = new Color(.5274297f,.5785475f,0.7830189f,1);
        }
        //if (PlayerPrefs.GetInt("topmoney") < upgrade.Cost && element == upgrade.elementName){ MAXColor(); }
    }
    private void MAXColor()
    {
        //image.color = new Color(.37f,.37f,.37f,1);
        //shadow.effectColor = new Color(.3f,.3f,.3f,1);
    }
    private void Upgrades()
    {
        switch (upgrade.elementName)
        {
            case "Speed":
                upgrade.value -= upgrade.defaultvalue - .2f;//.1f
                //CabinetManager.Instance.speed = upgrade.value;
                break;
            case "Pump":
                WheelManager.Instance.Enabling((int)upgrade.value);
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