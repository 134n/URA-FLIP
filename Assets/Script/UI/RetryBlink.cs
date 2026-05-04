using DG.Tweening;
using TMPro;
using UnityEngine;

public class RetryBlink : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        text.DOFade(0.2f, 0.5f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine)
            .SetUpdate(true)
            .SetLink(gameObject);

        transform.DOScale(1.1f, 0.5f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine)
            .SetUpdate(true)
            .SetLink(gameObject);
    }
}