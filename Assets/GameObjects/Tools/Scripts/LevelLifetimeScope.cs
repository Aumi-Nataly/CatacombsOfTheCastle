using UnityEngine;
using VContainer;
using VContainer.Unity;

public class LevelLifetimeScope : LifetimeScope
{
    [SerializeField] 
    private bool useInteractKey = true;

    [SerializeField]
    private bool useInteractDoor = true;

    [SerializeField]
    private bool useSpawnerEnemy = true;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<BackgroundLevelMusic>();

        if (useInteractKey)
            builder.RegisterComponentInHierarchy<InteractKey>();

        if (useInteractDoor)
            builder.RegisterComponentInHierarchy<InteractDoor>();

        if (useSpawnerEnemy)
            builder.RegisterComponentInHierarchy<SpawnerEnemy>();


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
