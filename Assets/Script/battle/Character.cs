using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public int type;
    public float maxHealth;
    public float currentHealth;
    public bool invulnerable;
    public float invulnerableDuration;
    public float invulnerableCounter;
    public GameObject hp;
    private void Start()
    {
        currentHealth = maxHealth;
        hp.SetActive(true);
    }
    public void TakeDamage(float damage)
    {
        if (invulnerable) return;
        currentHealth -= damage;
        if (type == 1) EventManager.Broadcast(new PlayerDamagedEvent(damage, null));
        if (currentHealth < 0)
        {
            if (type == 0)
            {
                int id = gameObject.GetComponent<EnemyMoveControl>().id;
                EntityManager.Instance.deads.Add(gameObject);
                //EntityManager.Instance.entities.Remove(gameObject);
                EntityManager.Instance.enemyMoves.Remove(id);
                EntityManager.Instance.enemies.Remove(id);
                if (--EntityManager.Instance.activeEnemyCount == 0)
                {
                    SceneManager.LoadScene("Win");
                }
            }
            else
            {
                //Íæ¼Ò¼Ä

            }
            Destroy(gameObject, 0.1f);
        }
        TriggerInvulnerable();
    }

    public void Update() 
    {
        
        if (invulnerable)
        {
            invulnerableCounter-=Time.deltaTime;
            if (invulnerableCounter <= 0 ) 
            {
                invulnerable = false;
            }
        }
    }
    private void TriggerInvulnerable() 
    {
        if (!invulnerable) 
        {
            invulnerable = true;
            invulnerableCounter = invulnerableDuration;
        }
    }
}
