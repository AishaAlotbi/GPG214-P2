using System.IO;
using UnityEngine;

public class LoadAssetBundles : MonoBehaviour
{
    string folderPath = "AssetBundles";
    string fileName = "enemies";
    string combinedPath;
    private AssetBundle enemiesBundle;

    
    void Start()
    {
        LoadEnemiesBundle();
        SpawnEnemy();
    }
    void LoadEnemiesBundle()
    {
        combinedPath = Path.Combine(Application.streamingAssetsPath, folderPath, fileName);

        if (File.Exists(combinedPath))
        {
            enemiesBundle = AssetBundle.LoadFromFile(combinedPath);
            Debug.Log("Asset Bundle Loaded");
        }
        else
        {
            Debug.Log("File does not exist" +  combinedPath);
        }
    }

    void SpawnEnemy()
    {
        if (enemiesBundle == null)
        {
            return;
        }

        GameObject chomperPrefab = enemiesBundle.LoadAsset<GameObject>("Chomper");
        GameObject spitterPrefab = enemiesBundle.LoadAsset<GameObject>("Spitter");

        if(chomperPrefab && spitterPrefab != null)
        {
           Instantiate(chomperPrefab);
           Instantiate(spitterPrefab);
        }
        
    }
   
}
