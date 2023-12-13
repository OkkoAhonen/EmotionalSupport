using UnityEngine;

public class AktivointiSkripti : MonoBehaviour
{
    public GameObject alakerta;
    public GameObject yl�kerta;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleAktivointi();
        }
    }

    void ToggleAktivointi()
    {

        alakerta.SetActive(!alakerta.activeSelf);
        yl�kerta.SetActive(!yl�kerta.activeSelf);
    }
}
