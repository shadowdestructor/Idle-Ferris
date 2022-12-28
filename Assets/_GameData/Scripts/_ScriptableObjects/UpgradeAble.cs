using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeAble", menuName = "UpgradeAble", order = 0)]
public class UpgradeAble : ScriptableObject
{
    public Vector3 color,shadowColor,backColor;
    public string elementName;
    public int Level,borderLevel,Cost,defaultCost;
    public float value,defaultvalue;
    
}