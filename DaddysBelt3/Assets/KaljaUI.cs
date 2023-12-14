using UnityEngine;
using UnityEngine.UI;

public class KaljaUI : MonoBehaviour
{
    public Text kaljaTeksti; // Viittaus Text-komponenttiin UI:ssa

    private int kaljam‰‰r‰ = 0; // Oletetaan, ett‰ t‰m‰ on kaljam‰‰r‰

    // Oletetaan, ett‰ t‰m‰ metodi kutsutaan aina kun kaljam‰‰r‰ p‰ivittyy
    public void P‰ivit‰KaljaM‰‰r‰(int uusiM‰‰r‰)
    {
        kaljam‰‰r‰ = uusiM‰‰r‰;
        P‰ivit‰UITeksti();
    }

    void P‰ivit‰UITeksti()
    {
        // P‰ivit‰ Text-komponenttiin n‰ytett‰v‰ teksti kaljam‰‰r‰n perusteella
        kaljaTeksti.text = "Kaljam‰‰r‰: " + kaljam‰‰r‰.ToString();
    }
}