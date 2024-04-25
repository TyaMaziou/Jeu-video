
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retour : MonoBehaviour
{
    // Méthode appelée lorsque le bouton de retour est cliqué
    public void Back()
    {
        // Charger la scène du menu principal
        SceneManager.LoadScene("TitleMenu");
    }
}
