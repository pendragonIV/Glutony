using UnityEngine;

public class Checker : MonoBehaviour
{
    public static Checker instance;

    [SerializeField] private Transform _edibleObjectsContainer;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void Check()
    {
        if (_edibleObjectsContainer.childCount - 1 == 0)
        {
            if (GameManager.instance.IsLoseGluttonyChallenge() || GameManager.instance.IsWinGluttonyChallenge())
            {
                return;
            }
            GameManager.instance.WinGluttonyChallenge();
            ImageCapture.instance.CaptureHoleImageNow();
        }
    }
}
