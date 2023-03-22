using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    public Text coinText;
    int contMonedas;

   public void GameOver()
    {
        isGameOver = true;
        
        //Se llama a la funcion con 1s y medio de retraso
        //Invoke("LoadScene", 1.5f);

        //Llamamos a la corutina LoadScene
        StartCoroutine("LoadScene");
    }

   /* void LoadScene()
    {
        SceneManager.LoadScene(2);
    }*/

    IEnumerator LoadScene()
    {
        //Para la corrutina durante 2,5s
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(2);
    }

    public void AddCoin()
    {
        contMonedas++;
        coinText.text = "coin " + contMonedas.ToString();
    }
}
