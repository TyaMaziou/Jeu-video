
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retour : MonoBehaviour
{
    // M�thode appel�e lorsque le bouton de retour est cliqu�
    public void Back()
    {
        // Charger la sc�ne du menu principal
        SceneManager.LoadScene("TitleMenu");
    }
}
