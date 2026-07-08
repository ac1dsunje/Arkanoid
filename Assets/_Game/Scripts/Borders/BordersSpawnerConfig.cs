using UnityEngine;

namespace _Game.Scripts.Borders
{
[CreateAssetMenu(fileName = "BordersSpawnerConfig", menuName = "Borders/BordersSpawnerConfig")]
public class BordersSpawnerConfig: ScriptableObject
{
    [field: SerializeField] public GameObject BorderSidePrefab {get; private set;}
    [field: SerializeField] public GameObject BorderDownPrefab {get; private set;}
    [field: SerializeField] public GameObject BorderUpPrefab {get; private set;}
    [field: SerializeField] public float BorderWidth { get; private set; } = 0.2f;
}
}