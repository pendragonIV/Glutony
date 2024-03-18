using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
    public GameScene gameScene;

    #region Game status
    private Level currentLevelData;
    private bool isGameWin = false;
    private bool isGameLose = false;
    private bool isGamePause = false;
    #endregion

    private void Start()
    {
        currentLevelData = LevelManager.instance.levelData.GetGluttonyChallengelAtIndex(LevelManager.instance.currentLevelIndex);
        GameObject map = Instantiate(currentLevelData.map, Vector3.zero, Quaternion.identity);
        Time.timeScale = 1;
    }

    public void WinGluttonyChallenge()
    {
        isGameWin = true;
        LevelManager.instance.levelData.SaveDataJSON();
    }

    public void LoseGluttonyChallenge()
    {
        isGameLose = true;
    }

    public bool IsWinGluttonyChallenge()
    {
        return isGameWin;
    }

    public bool IsLoseGluttonyChallenge()
    {
        return isGameLose;
    }

    public void PauseChallenge()
    {
        isGamePause = true;
        Time.timeScale = 0;
    }

    public void ResumeChallenge()
    {
        isGamePause = false;
        Time.timeScale = 1;
    }

    public bool IsGluttonyChalengePaused()
    {
        return isGamePause;
    }
}

