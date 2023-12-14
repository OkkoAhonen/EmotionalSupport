using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrugScript : MonoBehaviour
{
    public float stunDuration, moveSpeed, hitDetectionSize, angle;
    public Vector3 throwDir;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.position += throwDir * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.GetComponent<PlayerEffects>().PlayerStunned(stunDuration);
        }
    }
}
