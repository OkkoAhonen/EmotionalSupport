using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class DaddyAttack : MonoBehaviour
{
    public float drunkMeter, attackRange, turnSpeed, throwStrength;
    public static float angle;
    public bool canSeePlayer, canAttack;
    public Vector3 direction;
    public static Vector3 lastSeen;
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
        if (lastSeen == transform.position)
        {
            lastSeen = Vector3.zero;
        }
        int numHits = Physics2D.Raycast(transform.position, player.transform.position - transform.position, contactFilter, hits);
        Debug.Log(numHits);
        if (hits[0])
        {
            if (hits[0].collider.gameObject.CompareTag("Player"))
            {
                PlayerSpotted();
                StopCoroutine(FindPlayer());
            }
        }
        else
        {
            StartCoroutine(FindPlayer());
        }
    }

    public void LookTowards(Vector3 target)
    {
        direction = (target - transform.position).normalized;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * drunkMeter * Time.deltaTime);
    }

    public void PlayerSpotted()
    {
        //cancel findPlayer
        canSeePlayer = true;
        lastSeen = player.transform.position;
        LookTowards(lastSeen);
        // -1 on pelaajan ja is‰n koosta pois
        float distance = (transform.position - player.transform.position).magnitude - 1;

        Debug.Log("distance: " + distance);
        if (distance < attackRange && !canAttack)
        {
            DadAttack();
        }
    }

    IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(5 * drunkMeter);
        PlayerSpotted();

    }
    IEnumerator DadAttack()
    {
        // Huutaa jotain
        canAttack = false;
        Debug.Log("Dad Attack triggered!");
        yield return new WaitForSeconds(1 * drunkMeter);
        if (objectInHand == null)
        {

        }
        else
        {// Heitt‰‰ huumeet k‰dest‰
            GameObject thrownObject = Instantiate(objectInHand, transform.position, Quaternion.identity);
            DrugScript objScript = thrownObject.GetComponent<DrugScript>();
            objScript.throwDir = direction;
            objScript.moveSpeed = throwStrength * drunkMeter;
        }
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
        //Juomis ‰‰ni‰
        Debug.Log("Dad used drugs!");
        yield return new WaitForSeconds(drugUseTime);
        drunkMeter += drunkAdd;
    }
}
