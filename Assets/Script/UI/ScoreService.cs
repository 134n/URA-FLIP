using UniRx;

public class ScoreService
{
    readonly ReactiveProperty<int> score = new(0);
    public IReadOnlyReactiveProperty<int> Score => score;

    public void Add(int value) => score.Value += value;

    public void Reset() => score.Value = 0;
}
