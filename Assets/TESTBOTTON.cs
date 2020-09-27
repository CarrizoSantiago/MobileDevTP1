using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TESTBOTTON : MonoBehaviour
{
    // Start is called before the first frame update
   /* void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
    public void PlayScene(){
       SceneManager.LoadScene("conduccion9");
       // Debug.Log("Aca se supone que se abre la escena del juego");
    }
    public void Credits()
    {
        Debug.Log("Menu hecho por Santiago Carrizo");

    }
    public void Settings()
    {
        Debug.Log("Empty");

    }
    public void QuitGame()
    {
        //Debug.Log("Saliendo");

        Application.Quit();
    }

}
