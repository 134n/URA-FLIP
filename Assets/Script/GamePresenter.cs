using UnityEngine;
using UniRx;
using VContainer;
using Unityroom;
using KanKikuchi.AudioManager;
public class GamePresenter : MonoBehaviour
{
    [SerializeField] private PlayerCollision playerCollision;
    [SerializeField] private FloorColorChange topFloor;
    [SerializeField] private FloorColorChange bottomFloor;

    private ScoreService scoreService;

    private UIController uIController;

    private FlipService flipService;

    private RetryController retryController;

    [Inject]
    public void Construct(ScoreService scoreService
        , UIController uIController
        , FlipService flipService
        , RetryController retryController)
    {
        this.scoreService = scoreService;
        this.uIController = uIController;
        this.flipService = flipService;
        this.retryController = retryController;
    }

    public void Start()
    {
        BGMManager.Instance.Play(BGMPath.NESRPGA091_VICTORY);

        topFloor.SetFlip(flipService.IsFlipped.Value);
        bottomFloor.SetFlip(flipService.IsFlipped.Value);
        // フリップ時に床更新
        flipService.IsFlipped
            .SkipLatestValueOnSubscribe()
            .Subscribe(isFlipped =>
            {
                SEManager.Instance.Play(SEPath.GBGENERAL0115_PITCH);

                topFloor.SetFlip(!isFlipped);
                bottomFloor.SetFlip(isFlipped);
            })
            .AddTo(this);

        playerCollision.OnHit
            .Subscribe(hitType =>
            {
                bool isFlipped = flipService.IsFlipped.Value;
                bool isSafe =
                (!isFlipped && hitType == HitType.Good) ||
                (isFlipped && hitType == HitType.Bad);

                if (isSafe)
                {
                    SEManager.Instance.Play(SEPath.GBGENERAL0101_PITCH);

                    scoreService.Add(1);
                    Debug.Log($"Score : {scoreService.Score.Value}");
                }
                else
                {
                    SEManager.Instance.Play(SEPath.GBRPGB161_INN);
                    BGMManager.Instance.Stop();

                    Debug.Log("Game Over");

                    UnityroomAPI.ReportScore(1, scoreService.Score.Value);

                    uIController.ShowGameOverPanel();
                    retryController.EnableRetry();
                    Time.timeScale = 0f;
                }
            })
            .AddTo(this);

        scoreService.Score
            .Subscribe(score =>
                {
                    Debug.Log($"Current Score : {score}");
                })
                .AddTo(this);
    }
}
