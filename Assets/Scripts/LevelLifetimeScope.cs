using VContainer;
using VContainer.Unity;

public class LevelLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ISaveService, SaveService>(Lifetime.Scoped);
        builder.Register<IInventoryService, InventoryService>(Lifetime.Scoped);
        builder.RegisterComponentInHierarchy<InteractKey>();
    }
}
