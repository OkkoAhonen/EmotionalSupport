using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class DaddyAttack : MonoBehaviour
{
    public float drunkMeter, attackRange, turnSpeed, angle;
    public bool canSeePlayer, canAttack;
    public Vector3 lastSeen;
    public GameObject objectInHand;

    private GameObject player;
    public ContactFilter2D contactFilter;
    RaycastHit2D [] hits = new RaycastHit2D [3];

    private void Start()
    {
        player = GameObject.Find("Player").gameObject;
    }

    void Update()
    {
        int numHits = Physics2D.Raycast(transform.position, player.transform.position - transform.position, contactFilter, hits);
        Debug.Log(numHits);
        if (hits[0])
        {
            if (hits[0].collider.gameObject.CompareTag("Player"))
            {
                PlayerSpotted();
            }
        }
    }

    public void LookTowards(Vector3 target)
    {
        Vector2 direction = target - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * drunkMeter * Time.deltaTime);
    }

    public void PlayerSpotted()
    {
        canSeePlayer = true;
        lastSeen = player.transform.position;
        LookTowards(lastSeen);
        // -1 on pelaajan ja is�n koosta pois
        float distance = (transform.position - player.transform.position).magnitude - 1;

        Debug.Log("distance: " + distance);
        if (distance < attackRange && !canAttack)
        {
            DadAttack();
        }
    }

    IEnumerator DadAttack()
    {
        // Huutaa jotain
        canAttack = false;
        Debug.Log("Dad Attack triggered!");
        yield return new WaitForSeconds(1 * drunkMeter);
        GameObject thrownObject = Instantiate(objectInHand, transform.position, Quaternion.identity);
        thrownObject.GetComponent<DrugScript>().angle = angle;
        canAttack = true;

    }

    IEnumerator DadGetStunned(float stunTime)
    {
        // Vittu! (tai jotain)
        Debug.Log("Dad got stunned!");
        yield return new WaitForSeconds(stunTime);

    }

    IEnumerator DadUseDrugs(float drugUseTime, float drunkAdd)
    {
        //Juomis ��ni�
        Debug.Log("Dad used drugs!");
        yield return new WaitForSeconds(drugUseTime);
        drunkMeter += drunkAdd;
    }
}
