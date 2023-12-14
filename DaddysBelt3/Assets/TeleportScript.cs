using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform teleportTarget; // Aseta t‰m‰n kentt‰‰n teleporttauskohde Unityn editorissa
    public AktivointiSkripti aktivointiSkripti; // Viite AktivointiSkriptiin

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Varmista, ett‰ kyseess‰ on pelaaja, vaihda tagin nimi tarvittaessa
        {
            // Teleporttaa pelaajan kohteeseen
            other.transform.position = teleportTarget.position;

                aktivointiSkripti.ToggleAktivointi();
            
        }
    }
}
