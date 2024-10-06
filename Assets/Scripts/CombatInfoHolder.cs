using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatInfoHolder : MonoBehaviour
{
    public static CombatInfoHolder Instance { get; private set; } = null;
    public LittleGuyzStats yourGuy;
    public LittleGuyzStats notYourGuy;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Download(LittleGuyzStats target)
    {
        target.unitName = yourGuy.unitName;
        target.level = yourGuy.level;
        target.maxHealth = yourGuy.maxHealth;
        target.currentHealth = yourGuy.currentHealth;
        target.violence = yourGuy.violence;
        target.reinforcement = yourGuy.reinforcement;
        target.swiftness = yourGuy.swiftness;
        target.trait = yourGuy.trait;
        target.flesh = yourGuy.flesh;
        target.hasTrait = yourGuy.hasTrait;
        target.exp = yourGuy.exp;
    }
}
