
public interface ISaveService
{
    /// <summary>
    /// Сохранить данные в файл
    /// </summary>
    /// <param name="data"></param>
    public void SaveData(SaveData data);


    /// <summary>
    /// Прочитать данные из файла
    /// </summary>
    /// <param name="data"></param>
    public SaveData LoadData(SaveType type);
}
