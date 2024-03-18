using UnityEngine;

public class LevelScene : MonoBehaviour
{
    public static LevelScene instance;

    [SerializeField]
    private Transform levelHolderPrefab;
    [SerializeField]
    private Transform levelsContainer;

    public Transform sceneTransition;

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

    void Start()
    {
        PrepareLevels();
    }
    public void PlayChangeScene()
    {
        sceneTransition.GetComponent<Animator>().Play("SceneTransition");
    }

    private void PrepareLevels()
    {
        for (int i = 0; i < LevelManager.instance.levelData.GetAllGluttonyChallenges().Count; i++)
        {
            Transform holder = Instantiate(levelHolderPrefab, levelsContainer);
            holder.name = i.ToString();
            Level level = LevelManager.instance.levelData.GetGluttonyChallengelAtIndex(i);
            if (LevelManager.instance.levelData.GetGluttonyChallengelAtIndex(i).isPlayable)
            {
                holder.GetComponent<LevelHolder>().EnableLevelClickAndUI();
            }
            else
            {
                holder.GetComponent<LevelHolder>().DisableLevelClickAndUI();
            }
        }
    }
}
