using VContainer;
using VContainer.Unity;

public class LevelLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ISaveService, SaveService>(Lifetime.Scoped);
        builder.Register<IInventoryService, InventoryService>(Lifetime.Scoped);
          builder.RegisterComponentInHierarchy<InteractKey>();
          builder.RegisterComponentInHierarchy<InventoryView>();

        //все поля с атрибутом [Inject] в компонентах gameObject будут заполнены
        builder.RegisterBuildCallback(container =>
        {
            container.InjectGameObject(gameObject);
        });

    }
}
