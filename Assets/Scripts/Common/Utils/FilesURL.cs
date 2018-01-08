public static class FilesURL
{
    public static string GetFileURL(string name)
    {
        switch (name.ToLower())
        {
            //Maps
            //case "basemenumap": return "Main/Configurations/Data/Maps/BaseMenuMap.xml";

            //default
            default: return "";
        }
    }

    public static string GetFileFromResources(string name)
    {
        // Cars
        if (name.ToLower() == StringValue.GetStringValue(Collections.CarsEnum.FireGTO).ToLower()) return "Behaviours/Cars/PontiacFireGTO/Prefabs/FireGTO";
        if (name.ToLower() == StringValue.GetStringValue(Collections.CarsEnum.Focus).ToLower()) return "Behaviours/Cars/FordFocus/Prefabs/Focus";
        if (name.ToLower() == StringValue.GetStringValue(Collections.CarsEnum.Aventador).ToLower()) return "Behaviours/Cars/LamborginiAventador/Prefabs/Aventador";
        
        // Terrains
        if (name.ToLower() == StringValue.GetStringValue(Collections.TerrainsEnum.SingleStage).ToLower()) return "Terrains/SingleStage";

        return "";
    }
}
