using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;
using VContainer;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI flipText;
    [SerializeField] private GameObject gameOverText;

    private ScoreService scoreService;
    private FlipService flipService;

    [Inject]
    public void Inject(ScoreService scoreService,FlipService flipService)
    {
        this.scoreService = scoreService;
        this.flipService = flipService;
    }

    private void Start()
    {
        scoreService.Score
            .Subscribe(score => {scoreText.text = $"Score : {score}";})
            .AddTo(this);

        flipService.IsFlipped
            .Subscribe(isFlip => {flipText.text = isFlip? "Flip : URA" : "Flip : OMOTE";})
            .AddTo(this);
    }

    public void ShowGameOverPanel()
    {
        gameOverText.SetActive(true);
    }
}
