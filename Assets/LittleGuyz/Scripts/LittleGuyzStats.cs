using UnityEngine;
 public enum Trait
{sharp,slime,solid}
public class LittleGuyzStats : MonoBehaviour
{
    public string unitName;
    public int level = 1;
    public int maxHealth;
    public int currentHealth;
    public int violence;
    public int reinforcement;
    public int swiftness;

    public int TheNumber;

    public int TheNumber2;

    public int TheNumber3;

    public int TheNumber4;


    public Trait trait;
    
    public bool flesh;
    public bool hasTrait;
    public int typemod;
    public int exp;
    
   void Awake()
   {
        currentHealth = maxHealth;
        
   }

   void Update()
   {
     if(Input.GetKeyDown(KeyCode.T))
     {      
        TakeDamage(violence,Trait.sharp);
     }

      if(Input.GetKeyDown(KeyCode.R))
     {
        exp = exp+10;
     }

     LevelUp();
   }

   public void TakeDamage(int violence, Trait damageType)
   {
        if(hasTrait)
        {
            Debug.Log((int)trait);
            Debug.Log("type " + (int)damageType);
            
            if ((int)trait == ((int)damageType+1)%3)
            {
                Debug.Log("weak");
                violence*=2;
            }
            else if ((int)trait == ((int)damageType+2)%3)
            {
                Debug.Log("resist");
                violence = (int)(violence/2);
            }
        }
        violence-= reinforcement;
        violence = Mathf.Clamp(violence,1,int.MaxValue);
        currentHealth -= violence;
        Debug.Log(transform.name + "takes" + violence + "damage.");

        if(currentHealth<=0)
        {
            Die();
        }
         

   }
   public bool TakeDamage(int violence)
   {
        
        violence-= reinforcement;
        violence = Mathf.Clamp(violence,1,int.MaxValue);
        currentHealth -= violence;
        Debug.Log(transform.name + "takes" + violence + "damage.");

        if(currentHealth<=0)
        {
            Die();
            return true;
        }
        else
        {
            return false;
        }

   }

   public virtual void Die()
   {
        Debug.Log("Die");
   }

   public void LevelUp()
   {
        TheNumber = Random.Range(0,11);
        TheNumber2 = Random.Range(0,11);
        TheNumber3 = Random.Range(0,11);
        TheNumber4 = Random.Range(0,11);
        if(exp == 100)
        {
            violence = violence + TheNumber ;
            maxHealth = maxHealth + TheNumber2;
            reinforcement = reinforcement + TheNumber3;
            swiftness = swiftness + TheNumber4;
            exp-= 100;
            level = level + 1;
            currentHealth = maxHealth;
        }
        
        
   }
}
