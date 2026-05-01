using System.Collections.Generic;


[System.Serializable]
public class SaveData
{
    public SaveType Type { get; set; }
   
    public List<ListParamModel> listParams { get; set; }

}


public class ListParamModel
{ 
    public string NameParam { get; set; }
    public string ValueParam { get; set; }
}