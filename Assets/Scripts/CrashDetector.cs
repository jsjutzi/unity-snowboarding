using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float restartDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();

            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("RestartScene", restartDelay);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);

    }
}
