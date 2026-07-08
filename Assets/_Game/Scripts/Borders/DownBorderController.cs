using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Game.Scripts.Borders
{
public class DownBorderController:  MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
}