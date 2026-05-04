using UniRx;
using UnityEngine;
using VContainer;

public class ItemColorChange : MonoBehaviour
{
    [SerializeField] private HitType hitType;
    public HitType HitType => hitType;
    private FlipService flipService;
    private MeshRenderer meshRenderer;

    [Inject]
    public void Construct(FlipService flipService)
    {
        this.flipService = flipService;
    }
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        UpdateColor(flipService.IsFlipped.Value);

        flipService.IsFlipped
            .Subscribe(isFlipped =>
            {
                UpdateColor(isFlipped);
            })
            .AddTo(this);
    }
    private void UpdateColor(bool isFlipped)
    {
        if (!isFlipped)
        {
            // OMOTE
            if (hitType == HitType.Good)
                meshRenderer.material.color = Color.white;
            else
                meshRenderer.material.color = Color.black;
        }
        else
        {
            // URA
            if (hitType == HitType.Good)
                meshRenderer.material.color = Color.black;
            else
                meshRenderer.material.color = Color.white;
        }
    }
}
