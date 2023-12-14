using UnityEngine;

public class AktivointiSkripti : MonoBehaviour
{
    public GameObject alakerta;
    public GameObject yläkerta;


    public void ToggleAktivointi()
    {

        alakerta.SetActive(!alakerta.activeSelf);
        yläkerta.SetActive(!yläkerta.activeSelf);
    }
}
