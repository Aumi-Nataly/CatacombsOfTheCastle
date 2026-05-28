using UnityEngine;

public interface IInterable
{
    /// <summary>
    /// Изменить выделение предмета
    /// </summary>
    void ChangeLight(bool enable);

    /// <summary>
    /// Взаимодействовать
    /// </summary>
    void Interact();


    string GetInteractPromt();
}
