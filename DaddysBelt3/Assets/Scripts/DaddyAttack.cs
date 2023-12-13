using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class DaddyAttack : MonoBehaviour
{
    public float maxRayDistance, drunkMeter, attackRange;
    public bool canSeePlayer;
    public Vector3 lastSeen;

    private GameObject player;
    Ray ray;

    private void Start()
    {
        player = GameObject.Find("Player").gameObject;
    }

    void Update()
    {

        Vector3 raycastDir = player.transform.position - transform.position;
        ray = new Ray(transform.position, raycastDir);
        Physics.Raycast(ray, out RaycastHit hit, maxRayDistance);
        if (hit.collider.gameObject.CompareTag("Player"))
        {
            PlayerSpotted();
        }
    }

    public void PlayerSpotted()
    {
        canSeePlayer = true;
        lastSeen = player.transform.position;
        float dp = Mathf.Sqrt(transform.position.x + transform.position.y);
        float pp = Mathf.Sqrt(lastSeen.x + lastSeen.y);
        Debug.Log("dp: "+dp+" pp: "+pp);
        if (dp - pp < attackRange)
        {
            DadAttack();
        }
    }

    IEnumerator DadAttack()
    {
        // Huutaa jotain
        yield return new WaitForSeconds(1 * drunkMeter);

    }

    IEnumerator DadGetStunned(float stunTime)
    {
        // Vittu! (tai jotain)
        yield return new WaitForSeconds(stunTime);

    }

    IEnumerator DadUseDrugs(float drugUseTime, float drunkAdd)
    {
        //Juomis ääniä
        yield return new WaitForSeconds(drugUseTime);
        drunkMeter += drunkAdd;
    }
}
