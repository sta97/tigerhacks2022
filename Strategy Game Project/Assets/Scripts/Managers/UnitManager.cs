using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    private List<ScriptableUnits> units;

    void Awake()
    {
        Instance = this;

        units = Resources.LoadAll<ScriptableUnits>("Units").ToList();
    }

    public void SpawnHeroes()
    {
        var heroCount = 1;

        for (int i = 0; i< heroCount; i++)
        {

        }
    }

    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        return (T)units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }
}