using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField]float restartDelay = 0.5f;
    [SerializeField] ParticleSystem finishEffect;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("RestartScene", restartDelay);
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(0);

    }
}
