using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; /// ui text를 불러오기위한 부분
using UnityEngine.UI;
public class swordsupdate : Sword
{
    private void Start()
    {
        moneydd.SetActive(false);
        immuse.SetActive(false);
        immuseFalse.SetActive(false);
        immuseOn.SetActive(false);
        nowmoney.text = money + "원";
        Upgrade = upgradeCost[swordlevel];
        sowrdprice.text = "강화 비용 : " + Upgrade;
        price = sellingCost[swordlevel];
        sellsowrdprice.text = "판매 비용 : " + price;
        sword.sprite = upgradesword[swordlevel];
        
        swordName.text = swordname[swordlevel];
    }
    // 검 이름을 쓰는 텍스트필드
    public TextMeshProUGUI swordName;
    public TextMeshProUGUI probabilitynow;
    public TextMeshProUGUI nowmoney;
    public TextMeshProUGUI sellsowrdprice;
    public TextMeshProUGUI sowrdprice;
    public TextMeshProUGUI imm;
    public Image sword;
    public GameObject moneydd;
    public GameObject immuse;
    public GameObject immuseFalse;
    public GameObject immuseOn;
    public void SwordUpdate() // 강화
    {
        
        if (Upgrade <= money) //소지금보다 강화 비용이 많거나 같을 때 강화
        {
            result = Random.Range(1, 101); //1이상 101미만 (1 ~ 100)
            Debug.Log($"결과 {result}");
            if (result <= Probability)
            {
                swordlevel += 1;
                sword.sprite = upgradesword[swordlevel];
                money -= Upgrade;
                swordName.text = swordname[swordlevel];
                if (upgradepro[swordlevel])
                {
                    Probability -= 5;
                    
                }
                probabilitynow.text = "성공확률 : " + Probability;
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
                    immuse.SetActive(true );
                    Invoke("dd", 1f); //아래에 있는 함수인 SetActive(false)를 뒤늦게 실행시키는 명령어
                }
                else
                {
                    swordlevel = 0;
                    sword.sprite = upgradesword[swordlevel];
                    money -= Upgrade;
                    swordName.text = swordname[swordlevel];
                    Probability = 100;
                    probabilitynow.text = "성공확률 : " + Probability;
                    Upgrade = upgradeCost[swordlevel];
                    sowrdprice.text = "강화 비용 : " + Upgrade;
                    price = sellingCost[swordlevel];
                    sellsowrdprice.text = "판매 비용 : " + price;
                    nowmoney.text = money + "원";
                }
            }
        }
        else
        {
            moneydd.SetActive(true);
            Invoke("dd", 2f);
        }
    }
  
    public void Immunitydd()
    {
        if (!useImmunity)
        {
            if (Immunity > 0)
            {

                useImmunity = true;
                Immunity -= 1;
                imm.text = $"{Immunity} : 방지권 개수";
                Debug.Log("방지권을 사용했습니다.");
                immuseOn.SetActive(true);
                Invoke("dd", 1f);

            }
        }
        else if (useImmunity)
        {
            useImmunity = false;
            Immunity += 1;
            imm.text = $"{Immunity} : 방지권 개수";
            Debug.Log("방지권을 취소했습니다.");
            immuseFalse.SetActive(true);
            Invoke("dd", 1f);
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
        money += price; //저장해둔 가격만큼 돈을 더해서 저장
        swordlevel = 0;
        sword.sprite = upgradesword[swordlevel];
        Probability = 100;
        swordName.text = swordname[swordlevel];
        probabilitynow.text = "성공확률 : " + Probability;
        Upgrade = upgradeCost[swordlevel];
        sowrdprice.text = "강화 비용 : " + Upgrade;
        price = sellingCost[swordlevel];
        sellsowrdprice.text = "판매 비용 : " + price;
        nowmoney.text = money + "원";
    }
    public void dd()
    {
        moneydd.SetActive(false);
        immuse.SetActive(false);
        immuseFalse.SetActive(false);
        immuseOn.SetActive(false);
    }
   
}
