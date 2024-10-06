using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{


    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    LittleGuyzStats playerLittleGuy;

    LittleGuyzStats enemyLittleGuy;

    public TextMeshProUGUI dialogueText;

    public BattleHud playerHUD;

    public BattleHud enemyHud;

    public BattleState state;

    public GameObject panel;

    // Start is called before the first frame update
    public void StartUp()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        
        playerLittleGuy = CombatInfoHolder.Instance.yourGuy;

        enemyLittleGuy = CombatInfoHolder.Instance.notYourGuy;

        dialogueText.text = " A wild Little Guy" + enemyLittleGuy.unitName + "Gets you";

        playerHUD.SetHUD( playerLittleGuy);
        enemyHud.SetHUD(enemyLittleGuy);

        yield return new WaitForSeconds(2f);

        if(enemyLittleGuy.swiftness <=  playerLittleGuy.swiftness)
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
            Debug.Log("Player Faster");
        }
        if( playerLittleGuy.swiftness < enemyLittleGuy.swiftness)
        {
            state = BattleState.ENEMYTURN;
            EnemyTurn();
            Debug.Log("WHATT");
             StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyLittleGuy.TakeDamage(playerLittleGuy.violence);
        enemyHud.SetHP(enemyLittleGuy.currentHealth);
        dialogueText.text = "The attack hits";

        yield return new WaitForSeconds(2f);

        if(isDead)
        {
            state = BattleState.WON;
             EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
         dialogueText.text = enemyLittleGuy.unitName + "Attacks";

         yield return new WaitForSeconds(1f);

         bool isDead = playerLittleGuy.TakeDamage(enemyLittleGuy.violence);

         playerHUD.SetHP(playerLittleGuy.currentHealth);

         yield return new WaitForSeconds(1f);

         if(isDead)
         {
            state=BattleState.LOST;
            
            EndBattle();
         }
         else
         {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
         }


        
    }

    void EndBattle()
    {
        if( state == BattleState.WON)
        {
            Debug.Log("You Win");
            dialogueText.text = "You win";
            playerLittleGuy.exp = playerLittleGuy.exp + 10 + (enemyLittleGuy.level*enemyLittleGuy.level);
            if(playerLittleGuy.exp>=100)
            {
                dialogueText.text = "Level Up!";
            }
            //wait here on this line
            playerHUD.LevelThisMan(playerLittleGuy.level);
            CombatInfoHolder.Instance.Download(GameObject.FindWithTag("Player").GetComponent<Party>().yourGuy);

            
            panel.SetActive(false);
            Destroy(enemyLittleGuy.gameObject);


        }
        else if(state == BattleState.LOST)
        {
             dialogueText.text = "DIE";
            Destroy(CombatInfoHolder.Instance.gameObject);
            SceneManager.LoadScene("Mainmenu");
        }
    }
    void PlayerTurn()
    {
        dialogueText.text = "Make your move";
    }

    public void OnAttackButton()
    {
        if(state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
    }


}
