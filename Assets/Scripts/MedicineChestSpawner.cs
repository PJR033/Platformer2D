using System.Collections.Generic;
using UnityEngine;

public class MedicineChestSpawner : MonoBehaviour
{
    [SerializeField] private MedicineChest _medicineChestPrefab;
    [SerializeField] private int _medcineChestsMaxCount;

    private List<Transform> _spawnPoints = new List<Transform>();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _spawnPoints.Add(transform.GetChild(i));
        }
    }

    private void Start()
    {
        for (int i = 0; i < _medcineChestsMaxCount; i++)
        {
            int currentPoint = Random.Range(0, _spawnPoints.Count);
            MedicineChest created = Instantiate(_medicineChestPrefab, _spawnPoints[currentPoint].position, Quaternion.identity);
            _spawnPoints.RemoveAt(currentPoint);
        }
    }
}
