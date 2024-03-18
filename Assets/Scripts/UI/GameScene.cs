using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Transform _capturedImage;
    [SerializeField] private GameObject _gameWinNav;
    [SerializeField] private GameObject _gameLoseNav;
    [SerializeField] private GameObject _ingameMenuOfGluttony;
    [SerializeField] private GameObject _tutorHand;
    private bool _isDisableTutorHand = false;


    private string[] _gameWinTexts = new string[]
    {
        "What a genius?",
        "Is'nt that hard right?",
        "Gorgeous!",
        "Do you have a trick?",
        "Wonderfull win!",
        "Is there anything that can stop you?",
    };

    private string[] _gameLoseTexts = new string[]
    {
        "You are almost there!",
        "Huh?",
        "Really?",
        "Shhhhh!",
        "Try carefully next time!",
        "Try again?"
    };

    private void Start()
    {
        HideCapturedImage();
        if(LevelManager.instance.currentLevelIndex == 0)
        {
            ShowTutorHand();
        }
    }

    private void Update()
    {
        if (LevelManager.instance.currentLevelIndex == 0)
        {
            if(Input.GetMouseButtonDown(0) && !_isDisableTutorHand)
            {
                HideTutorHand();
            }
        }
    }

    public void ShowTutorHand()
    {
        _isDisableTutorHand = false;
        _tutorHand.SetActive(true);
        CanvasGroup canvasGroup = _tutorHand.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, .3f).SetUpdate(true).SetEase(Ease.Linear);
        _tutorHand.transform.localScale = Vector3.one * .3f;
        _tutorHand.transform.DOScale(Vector3.one, .3f).SetUpdate(true).SetEase(Ease.OutBack);
    }

    public void HideTutorHand()
    {
        _isDisableTutorHand = true; 
        CanvasGroup canvasGroup = _tutorHand.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.DOFade(0, .3f).SetUpdate(true).SetEase(Ease.Linear);
        _tutorHand.transform.DOScale(Vector3.one * .3f, .3f).SetUpdate(true).SetEase(Ease.InBack).OnComplete(() =>
        {
            _tutorHand.SetActive(false);
        });
    }

    public void ShowIngameMenuOfGluttony()
    {
        _ingameMenuOfGluttony.SetActive(true);
        CanvasGroup canvasGroup = _ingameMenuOfGluttony.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, .3f).SetUpdate(true).SetEase(Ease.Linear);
        RectTransform rectTransform = _ingameMenuOfGluttony.transform.GetChild(0).GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, 500);
        rectTransform.DOAnchorPosY(0, .3f).SetUpdate(true).SetEase(Ease.OutBack);
    }

    public void HideIngameMenuOfGluttony()
    {
        CanvasGroup canvasGroup = _ingameMenuOfGluttony.GetComponent<CanvasGroup>();
        canvasGroup.DOFade(0, .3f).SetUpdate(true).SetEase(Ease.Linear);
        RectTransform rectTransform = _ingameMenuOfGluttony.transform.GetChild(0).GetComponent<RectTransform>();
        rectTransform.DOAnchorPosY(500, .3f).SetUpdate(true).SetEase(Ease.InBack).OnComplete(() =>
        {
            _ingameMenuOfGluttony.SetActive(false);
        });
    }

    public void ShowCapturedImage()
    {
        _gameOverPanel.SetActive(true);
        _capturedImage.gameObject.SetActive(true);
        _capturedImage.localScale = Vector3.one * 1.5f;
        _capturedImage.DOScale(Vector3.one, .3f).SetUpdate(true).SetEase(Ease.OutBack);
        _capturedImage.DORotate(new Vector3(0, 0, 12), .3f).SetUpdate(true).SetEase(Ease.Linear);
        TMP_Text text = _capturedImage.GetChild(1).GetComponent<TMP_Text>();
        bool isGameWin = GameManager.instance.IsWinGluttonyChallenge();
        if (isGameWin)
        {
            _gameWinNav.SetActive(true);
            _gameLoseNav.SetActive(false);
            text.text = _gameWinTexts[Random.Range(0, _gameWinTexts.Length)];
        }
        else
        {
            _gameWinNav.SetActive(false);
            _gameLoseNav.SetActive(true);
            text.text = _gameLoseTexts[Random.Range(0, _gameLoseTexts.Length)];
        }
    }

    public void HideCapturedImage()
    {
        _capturedImage.gameObject.SetActive(false);
        _gameOverPanel.SetActive(false);
    }
}
