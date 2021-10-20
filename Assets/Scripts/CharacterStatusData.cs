using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Status")]
public class CharacterStatusData : ScriptableObject
{
    public int health = 10;
    public int maxHealth = 10;
    public int stamina = 100;
    public int maxStamina = 100;
    public bool aliveStatus = true;
}
