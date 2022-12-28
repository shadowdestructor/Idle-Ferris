using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance {get; private set;}
    [HideInInspector] public TextMeshProUGUI m_CoinText;
    public int yourMoney;
    private void Awake()
    {
        Instance = this;
        m_CoinText = GetComponent<TextMeshProUGUI>();
        m_CoinText.text = PlayerPrefs.GetInt("topmoney").ToString();
        yourMoney = PlayerPrefs.GetInt("topmoney");
    }
    public void Click(int reward)
    {
        yourMoney += reward;
        PlayerPrefs.SetInt("topmoney",yourMoney);
        m_CoinText.text = PlayerPrefs.GetInt("topmoney").ToString();
    }
    private void Income()
    {
        //CoinManager.Instance.Click((int)income.value);
    }
    /*private void TextAnim()
    {
        text.gameObject.SetActive(true);
        text.gameObject.transform.DOMoveZ(30,1.5f).OnComplete(()=>
        {
            text.text = ((int)income.value).ToString();
            text.gameObject.SetActive(false);
            text.gameObject.transform.position = new Vector3(12.5f,2.5f,4);
        });
    }*/
}
