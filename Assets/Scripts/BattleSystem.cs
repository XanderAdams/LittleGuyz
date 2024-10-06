using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public GameObject littleGuyPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    LittleGuyzStats playerLittleGuy;

    LittleGuyzStats enemyLittleGuy;

    public TextMeshProUGUI dialogueText;

    public BattleHud playerHUD;

    public BattleHud enemyHud;

    public BattleState state;

    

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGo = Instantiate(littleGuyPrefab, playerBattleStation);
        playerLittleGuy = playerGo.GetComponent<LittleGuyzStats>();

        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
        enemyLittleGuy = enemyGo.GetComponent<LittleGuyzStats>();

        dialogueText.text = " A wild Little Guy" + enemyLittleGuy.unitName + "Gets you";

        playerHUD.SetHUD( playerLittleGuy);
        enemyHud.SetHUD(enemyLittleGuy);

        yield return new WaitForSeconds(2f);

        if(enemyLittleGuy.swiftness <  playerLittleGuy.swiftness)
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
            dialogueText.text = "You win";
            playerLittleGuy.exp = playerLittleGuy.exp + 10;
            if(playerLittleGuy.exp>=100)
            {
                dialogueText.text = "Level Up!";
            }
            //wait here on this line
            playerHUD.LevelThisMan(playerLittleGuy.level);
        }
        else if(state == BattleState.LOST)
        {
             dialogueText.text = "DIE";
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
