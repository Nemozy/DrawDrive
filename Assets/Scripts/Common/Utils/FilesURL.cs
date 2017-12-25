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
        // Roads
        //if (name.ToLower() == StringValue.GetStringValue(Collections.RoadPrefabsEnum.RoadDeadend).ToLower()) return "RoadKit/Prefabs/road_deadend";
        //if (name.ToLower() == StringValue.GetStringValue(Collections.RoadPrefabsEnum.RoadStraight).ToLower()) return "RoadKit/Prefabs/road_straight";




        // Cars
        if (name.ToLower() == StringValue.GetStringValue(Collections.CarsEnum.FireGTO).ToLower()) return "Cars/Prefabs/FireGTO";



        // Terrains
        if (name.ToLower() == StringValue.GetStringValue(Collections.TerrainsEnum.SingleStage).ToLower()) return "Terrains/SingleStage";

        return "";
    }
}
