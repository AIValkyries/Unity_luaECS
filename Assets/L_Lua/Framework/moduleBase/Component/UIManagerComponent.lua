-- Layers=GameObject[] Layers;
-- Root = GameObject
   -- /// <summary>
   -- /// Key:view路径
   -- /// Value:view的prefab
   -- /// </summary>
-- UIPrefabs = Dictionary<string, GameObject>
   -- /// <summary>
   -- /// Key:Prefab
   -- /// Value:实例
   -- /// </summary>
-- UIViews = Dictionary<GameObject, GameObject>

UIManagerComponent = MakeComponent("UIManagerCompoent","Layers","Root","UIPrefabs","UIViews")
