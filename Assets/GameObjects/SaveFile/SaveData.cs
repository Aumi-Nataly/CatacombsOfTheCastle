using System.Collections.Generic;


[System.Serializable]
public class SaveData
{
    public SaveType Type;

    public List<ListParamModel> listParams;
}

[System.Serializable]
public class ListParamModel
{
    public string NameParam;
    public string ValueParam;
}