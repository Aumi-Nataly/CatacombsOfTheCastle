using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryService
{
    /// <summary>
    /// Добавить в инвентарь
    /// </summary>
    public void Add(ItemType id, int count);

    /// <summary>
    /// Удалить из инвентаря
    /// </summary>
    public void Remove(ItemType id, int count);

    /// <summary>
    /// Получить полный список инвентаря
    /// </summary>
    /// <returns></returns>
    public Dictionary<ItemType, int> GetInventoryList();


    /// <summary>
    /// Сохранить данные в файл при смене сцены
    /// </summary>
    public void WriteToFile();

    public int GetСoncreteItem(ItemType id);

    /// <summary>
    /// Сбросить сохраненные данные
    /// </summary>
    public void ResetFile();
}
