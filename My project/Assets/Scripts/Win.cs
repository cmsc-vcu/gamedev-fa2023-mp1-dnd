using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
        if (collision.gameObject.CompareTag("Door"))
        {
            SceneManager.LoadScene("Win");
        }
   }
}
