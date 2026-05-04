using UnityEngine;
using UniRx;
using System;
using UniRx.Triggers;

public class PlayerCollision : MonoBehaviour
{
    private readonly Subject<HitType> onHit = new();
    public IObservable<HitType> OnHit => onHit;

    private void Start()
    {
        this.OnTriggerEnterAsObservable()
            .Subscribe(collider =>
                {
                    collider.TryGetComponent<ItemColorChange>(out var item);
                    onHit.OnNext(item.HitType);
                    Destroy(collider.gameObject);
                }
            )
            .AddTo(this);
    }
}
