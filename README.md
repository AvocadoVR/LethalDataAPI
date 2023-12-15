# LethalDataAPI

### Important
> You have to sync data yourself. It doesn't do it automatically. You cannot load save or load data on Awake() in your Plugin.cs File.

### How To Use
```csharp
// This will prevent other mods data to be mixed in with your data.
public static LethalData storage = new LethalData(modName); 

private int exampleVariable

public void SaveData() {
    // Save(string key, T value)
    // The key has to be unique and it dosen't have to be the variable name.
    storage.Save("exampleVariable", exampleVariable);
}

public void LoadData() {
    // Load<Type>(string key)
    exampleVariable = storage.Load<int>("exampleVariable");
}
```