using UnityEngine;

public class LittleGuyzStats : MonoBehaviour
{
    public int maxHealth=100;
    public int currentHealth;
    public int violence;
    public int reinforcement;
    public int swiftness;
    
   void Awake()
   {
        currentHealth = maxHealth;
   }

   void Update()
   {
     if(Input.GetKeyDown(KeyCode.T))
     {
        TakeDamage(violence);
     }
   }

   public void TakeDamage(int violence)
   {
        violence-= reinforcement;
        violence = Mathf.Clamp(violence,1,int.MaxValue);
        currentHealth -= violence;
        Debug.Log(transform.name + "takes" + violence + "damage.");

        if(currentHealth<=0)
        {
            Die();
        }

   }

   public virtual void Die()
   {
        Debug.Log("Die");
   }
}
