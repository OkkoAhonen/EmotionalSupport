using UnityEngine;

public class AktivointiSkripti : MonoBehaviour
{
    public GameObject alakerta;
    public GameObject yl�kerta;


    public void ToggleAktivointi()
    {

        alakerta.SetActive(!alakerta.activeSelf);
        yl�kerta.SetActive(!yl�kerta.activeSelf);
    }
}
