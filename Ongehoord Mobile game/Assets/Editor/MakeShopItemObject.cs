using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[System.Serializable]
public class MakeShopItemObject : ScriptableObject {

    [MenuItem("Assets/Create/ShopItem Object")]
    public static void Create()
    {
        ShieldObject asset = ScriptableObject.CreateInstance<ShieldObject>();
        AssetDatabase.CreateAsset(asset, "Assets/NewShopItem.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }


}
