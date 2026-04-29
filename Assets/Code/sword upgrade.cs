using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; /// ui text를 불러오기위한 부분
using UnityEngine.UI;
public class swordsupdate : Sword
{
    // 검 이름을 쓰는 텍스트필드
    public TextMeshProUGUI swordName;
    public TextMeshProUGUI probabilitynow;
    public TextMeshProUGUI nowmoney;
    public TextMeshProUGUI sellsowrdprice;
    public TextMeshProUGUI sowrdprice;
    public TextMeshProUGUI imm;
    public Image sword;
    public void SwordUpdate() // 강화
    {
        
        if (Upgrade <= money) //소지금보다 강화 비용이 많거나 같을 때 강화
        {
            result = Random.Range(0, 100);
            if (result <= Probability)
            {
                swordlevel += 1;
                money -= Upgrade;
                swordName.text = swordname[swordlevel];
                if (upgradepro[swordlevel])
                {
                    Probability -= 5;
                    probabilitynow.text = "성공확률 : " + Probability; 
                }
                Upgrade = upgradeCost[swordlevel];
                sowrdprice.text = "강화 비용 : " + Upgrade;
                price = sellingCost[swordlevel];
                sellsowrdprice.text = "판매 비용 : " + price;
                nowmoney.text = money + "원";
                
            }
            else
            {
                if (useImmunity == true)
                {
                    useImmunity = false;
                }
                else
                {
                    swordlevel = 0;
                    money -= Upgrade;
                    swordName.text = swordname[swordlevel];
                    Probability = 100;
                    probabilitynow.text = "성공 확률 : 100%";
                    Upgrade = upgradeCost[swordlevel];
                    sowrdprice.text = "강화 비용 : " + Upgrade;
                    price = sellingCost[swordlevel];
                    sellsowrdprice.text = "판매 비용 : " + price;
                    nowmoney.text = money + "원";
                }
            }
        }
    }
    public void Update()
    {
        sword.sprite = upgradesword[swordlevel];
        probabilitynow.text = "성공확률 : " + Probability;
    }
    public void Immunitydd()
    {
        if (Immunity > 0)
        {
            if (!useImmunity)
            {
                useImmunity = true;
                Immunity -= 1;
            }
            else
            {
                useImmunity = false;
            }
        }
    }
    public void buyimmunity()
    {
        if (money >= 500)
        {
            Immunity += 1;
            Debug.Log("방지권 1개 획득");
            money -= 500;
            imm.text = $"{Immunity} : 방지권 개수";
            nowmoney.text = money + "원";
        }
    }
    public void sell()
    {
        money += price;
        swordlevel = 0;
       
        swordName.text = swordname[swordlevel];
        probabilitynow.text = "성공 확률 : 100%";
        Upgrade = upgradeCost[swordlevel];
        sowrdprice.text = "강화 비용 : " + Upgrade;
        price = sellingCost[swordlevel];
        sellsowrdprice.text = "판매 비용 : " + price;
        nowmoney.text = money + "원";
    }
}
