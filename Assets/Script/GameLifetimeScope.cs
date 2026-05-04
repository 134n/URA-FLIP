using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ScoreService>(Lifetime.Singleton);
        builder.Register<FlipService>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<GamePresenter>();
        builder.RegisterComponentInHierarchy<UIController>();
        builder.RegisterComponentInHierarchy<ItemSpawner>();
        builder.RegisterComponentInHierarchy<RetryController>();
    }
}
