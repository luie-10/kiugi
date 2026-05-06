using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; /// ui text를 불러오기위한 부분
using UnityEngine.UI;
public class Nogada : MonoBehaviour
    
{
    public Sprite[] stone = new Sprite[] { };
    public Image doll;
    public int dolllevel;
    public TextMeshProUGUI tkdghkddyd;
    public void Nogadaa()
    {
        tkdghkddyd.text = "";


        dolllevel += 1;
            doll.sprite = stone[dolllevel];
            
            if (dolllevel == 4)
            {
                tkdghkddyd.text = "100원을 벌었다!";
                dolllevel = 0;
                doll.sprite = stone[0];
            }
        
        
    }
}
