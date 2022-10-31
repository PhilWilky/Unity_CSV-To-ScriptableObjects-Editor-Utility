using UnityEngine;
using UnityEditor;
using System.IO;

public class CsvToSo
{
    private static string CsvPath = "/Editor/CSVs/EnemyCSV.csv";
    [MenuItem("Utilities/Generate Enemies")]
    public static void GenerateEnemies()
    {

        Debug.Log("Loading file; please wait...");
        string[] allLines = File.ReadAllLines(Application.dataPath + CsvPath);

        foreach (string item in allLines)
        {
            string[] splitData = item.Split(",");

            if (splitData.Length != 4)
            {
                Debug.Log(splitData + "FAILED: " + " does not have four values");
                return;
            }

            Enemy enemy = ScriptableObject.CreateInstance<Enemy>(); //create empty ScriptableObject of type Enemy
            enemy.enemyName = splitData[0];

            // WARNING maybe add a catch clause to stop trying to parse non-numbers as float
            enemy.hp = float.Parse(splitData[1]);
            enemy.strenght = float.Parse(splitData[2]);
            enemy.xpReward = float.Parse(splitData[3]);

            AssetDatabase.CreateAsset(enemy, $"Assets/Enemies/{enemy.enemyName}.asset");
            Debug.Log("Added: " +enemy.enemyName);
        }

        AssetDatabase.SaveAssets();
        Debug.Log("File loaded and assets saved!   :-) ");
    }

}
