using UnityEngine;
using VContainer;
using VContainer.Unity;

public class LevelLifetimeScope : LifetimeScope
{
    [SerializeField] 
    private bool useInteractKey = true;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ISaveService, SaveService>(Lifetime.Scoped);
        builder.Register<IInventoryService, InventoryService>(Lifetime.Scoped);

        if (useInteractKey)
            builder.RegisterComponentInHierarchy<InteractKey>();


          builder.RegisterComponentInHierarchy<InventoryView>();
          builder.RegisterComponentInHierarchy<PauseScreen>();
          builder.RegisterComponentInHierarchy<GameOverScreen>();

        //все поля с атрибутом [Inject] в компонентах gameObject будут заполнены
        builder.RegisterBuildCallback(container =>
        {
            container.InjectGameObject(gameObject);
        });


    }
}
