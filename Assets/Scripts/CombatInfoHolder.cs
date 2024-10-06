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
}
