using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    public IEnumerator PlayerStunned(float stunDuration)
    {
        MovementScript moveScript = player.GetComponent<MovementScript>();
        moveScript.enabled = false;
        yield return new WaitForSeconds(stunDuration);
        moveScript.enabled = true;
    }

}
