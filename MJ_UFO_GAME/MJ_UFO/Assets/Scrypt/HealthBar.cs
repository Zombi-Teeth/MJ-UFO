using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Player player;
    public Slider hpBar;

  void Update()
  {
       hpBar.value = (float)player.hp / (float)player.maxHP;
        
  }
}
