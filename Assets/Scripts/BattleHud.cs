using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    public TextMeshProUGUI nameText;
     public TextMeshProUGUI levelText;
     public Slider hpSlider;

     LittleGuyzStats playerLittleGuy;
     

     public void SetHUD(LittleGuyzStats stats)
     {
        nameText.text = stats.unitName;
        levelText.text = "Lvl" + stats.level;
        hpSlider.maxValue = stats.maxHealth;
        hpSlider.value = stats.currentHealth;
     }

     public void SetHP(int hp)
     {
       hpSlider.value = hp;
       Debug.Log("BRUHHHH");
     }
     public void LevelThisMan(int lvl)
     {
        levelText.text = "lvl" + lvl;
     }

     
     

}
