using UnityEngine;

public class FloorColorChange : MonoBehaviour
{
    [SerializeField] private HitType hitType;

    private MeshRenderer meshRenderer;
    
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    
    public void SetFlip(bool isFlipped)
    {
        
        if (meshRenderer == null) return;

        bool isWhite =
            !isFlipped && hitType == HitType.Good
            ||( isFlipped && hitType == HitType.Bad);

        meshRenderer.material.color = isWhite ? Color.white : Color.black;
    }
}
