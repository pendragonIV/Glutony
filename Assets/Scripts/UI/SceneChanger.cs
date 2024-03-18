using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private const string MENU = "MainMenu";
    private const string GAME = "GameScene";
    private const string LEVEL_CHOOSE = "LevelScene";

    [SerializeField]
    private Transform sceneTransition;

    private void Start()
    {
        PlayGluttonyStateTransitionAnim();
    }

    public void PlayGluttonyStateTransitionAnim()
    {
        sceneTransition.GetComponent<Animator>().Play("SceneTransitionReverse");
    }

    public void ChangeToGluttonyHome()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeStateForGluttony(MENU));
    }

    public void ChangeToGluttonyGameChallenger()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeStateForGluttony(GAME));
    }

    public void ChangeToGluttonyLevelsChoosingState()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeStateForGluttony(LEVEL_CHOOSE));
    }

    public void ChangeToNextGluttonyGameChallenger()
    {
        StopAllCoroutines();
        if (LevelManager.instance.currentLevelIndex < LevelManager.instance.levelData.GetAllGluttonyChallenges().Count - 1)
        {
            LevelManager.instance.currentLevelIndex++;
            StartCoroutine(ChangeStateForGluttony(GAME));
        }
        else
        {
            StartCoroutine(ChangeStateForGluttony(LEVEL_CHOOSE));
        }
    }


    private IEnumerator ChangeStateForGluttony(string sceneName)
    {

        //Optional: Add animation here
        sceneTransition.GetComponent<Animator>().Play("SceneTransition");
        yield return new WaitForSecondsRealtime(1f);

        SceneManager.LoadSceneAsync(sceneName);

    }
}
