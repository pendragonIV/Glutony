using UnityEngine;

public class FallingDestroyer : MonoBehaviour
{
    void Update()
    {
        if (gameObject.CompareTag("Unedible"))
        {
            if (transform.position.y <= -3f)
            {
                ImageCapture.instance.CaptureHoleImageNow();
                GameManager.instance.LoseGluttonyChallenge();
            }
            if (transform.position.y <= -5)
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.CompareTag("LayerSwitchable"))
        {
            if (transform.position.y <= -10)
            {
                Destroy(gameObject);
                Checker.instance.Check();
            }
        }

    }


}
