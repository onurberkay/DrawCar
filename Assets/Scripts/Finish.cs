using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject restartButton;
    private bool once = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (once && collision.gameObject.CompareTag("Line"))
        {
            restartButton.SetActive(true);
            once = false;
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
