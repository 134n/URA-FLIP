using UniRx;
using System;

public class FlipService
{
    private readonly ReactiveProperty<bool> isFlipped = new(false);
    public IReadOnlyReactiveProperty<bool> IsFlipped => isFlipped;

    public FlipService()
    {
        Observable.Interval(TimeSpan.FromSeconds(5))
            .Subscribe(_ =>
            {
                isFlipped.Value = !isFlipped.Value;
            });
    }
}
