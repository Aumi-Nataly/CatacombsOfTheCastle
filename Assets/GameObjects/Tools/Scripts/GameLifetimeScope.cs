using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<IInputSystem, InputSystem>(Lifetime.Singleton);
        builder.Register<ISaveService, SaveService>(Lifetime.Singleton);
        builder.Register<IInventoryService, InventoryService>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<MusicManager>();
    }
}
