using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName ="Assets/New Enemy")]

public class Enemy : ScriptableObject
{
    public string enemyName;
    public float hp;
    public float strenght;
    public float xpReward;
}
