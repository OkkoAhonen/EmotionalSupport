using UnityEngine;

public class AktivointiSkripti : MonoBehaviour
{
    public GameObject alakerta;
    public GameObject yläkerta;

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
        yläkerta.SetActive(!yläkerta.activeSelf);
    }
}
