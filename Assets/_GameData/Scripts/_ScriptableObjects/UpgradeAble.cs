using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeAble", menuName = "UpgradeAble", order = 0)]
public class UpgradeAble : ScriptableObject
{
    public Vector3 color,shadowColor,backColor;
    public string elementName;
    public int Cost,defaultCost;
    public float value,defaultvalue;
    public void SetPref()=>PlayerPrefs.SetInt("cost",Cost);
    public void GetPref()=> Cost = PlayerPrefs.GetInt("cost",Cost);
}