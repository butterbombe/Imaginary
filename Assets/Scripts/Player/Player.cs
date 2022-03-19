using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int basePlayerHealth = 3;
    public int playerHealth = 3;
    private bool canBeDamaged = true;

    [SerializeField] float invincibleTime;

    private void Start()
    {
        playerHealth = basePlayerHealth;
    }

    public void TakeDamage()
    {
        Debug.Log("Taking Damage");
        if (canBeDamaged == false)
        {
            return;
        }
        else
        {
            playerHealth--;
            if (playerHealth <= 0)
            {
                PlayerDeath();
                return;
            }
            else
            {
                canBeDamaged = false;
                StartCoroutine(PlayerInvincibleState());
            }
        }
    }
    IEnumerator PlayerInvincibleState()
    {
        yield return new WaitForSeconds(invincibleTime);
        canBeDamaged = true;
    }

    private void PlayerDeath()
    {
        //
    }
    
}
