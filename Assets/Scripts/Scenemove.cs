using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemove : MonoBehaviour
{
    public string sceneName;
    public string combatSceneName;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&gameObject.GetComponent<Party>()==null)
        {
            collision.gameObject.GetComponent<Party>().Upload(CombatInfoHolder.Instance.yourGuy);
            //gameObject.GetComponent<Party>().Upload(CombatInfoHolder.Instance.notYourGuy);
            LoadScene();
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Party>().Upload(CombatInfoHolder.Instance.yourGuy);
            gameObject.GetComponent<Party>().Upload(CombatInfoHolder.Instance.notYourGuy);
            LoadCombatScene();
        }

    }
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadCombatScene()
    {

        SceneManager.LoadScene(combatSceneName);
    }
    
}
