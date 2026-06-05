using System;
using System.Collections.Generic;

public class InventoryService : IInventoryService
{
    private Dictionary<ItemType, int> items = new Dictionary<ItemType, int>();

    private readonly ISaveService _saveService;

    public InventoryService(ISaveService saveService)
    {
        _saveService = saveService;

        ReadFromFile();

        if(items.Count == 0)
            StartingData();
    }


    private void StartingData()
    {
        items[ItemType.Key] = 0;
        items[ItemType.HealthBottle] = 0;
    }

    public void Add(ItemType id, int count)
    {
        if (items.ContainsKey(id))
        {
            items[id] += count; 
        }
        else
        {
            items[id] = count; 
        }

    }

    public Dictionary<ItemType, int> GetInventoryList()
    {
        return items;
    }

    public void Remove(ItemType id, int count)
    {
        if (items.TryGetValue(id, out int CurCount))
        {
            items[id] = CurCount - count > 0 ? CurCount - count : 0;
        }
    }

    private void ReadFromFile()
    {
       var data = _saveService.LoadData(SaveType.Inventory);

        if (data == null || data.listParams == null)
            return;

        items.Clear();
        string NameParam;

        foreach (var i in data.listParams) 
        {
            if (Enum.TryParse<ItemType>(i.NameParam, ignoreCase: true, out var parsedEnum))
            {
                items.TryAdd(parsedEnum, Convert.ToInt32(i.ValueParam));
            }
        }
    }

    public void WriteToFile()
    {
        var paramList = new List<ListParamModel>();

        foreach (var item in items) 
        {
            paramList.Add(new ListParamModel { NameParam = item.Key.ToString(), ValueParam = item.Value.ToString() });
        }

        _saveService.SaveData(new SaveData { Type = SaveType.Inventory, listParams = paramList });
    }

    public int GetСoncreteItem(ItemType id)
    {
        if (items.TryGetValue(id, out int CurCount))
        {
            return CurCount;
        }

        return 0;
    }

    public void ResetFile()
    {
        StartingData();
        WriteToFile();
    }
}
