using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableManager : MonoBehaviour
{
    private List<Pickable> _pickableList = new List<Pickable>();
    void Start()
    {
        InitPickableList();
    }

    private void InitPickableList()
    {
        Pickable[] pickableOjects = GameObject.FindObjectsOfType<Pickable>();
        foreach (Pickable pickable in pickableOjects)
        {
            _pickableList.Add(pickable);
            pickable.OnPicked += OnPickablePicked;
        }
        Debug.Log("Pickable List: " + _pickableList.Count);
    }

    private void OnPickablePicked(Pickable pickable)
    {
        _pickableList.Remove(pickable);
        Destroy(pickable.gameObject);
        Debug.Log("Pickable List: " + _pickableList.Count);
        if (_pickableList.Count <= 0)
        {
            Debug.Log("Win");
        }
        if (pickable._pickableType == PickableType.PowerUp)

        {

            _player?.PickPowerUp();

        }
    }

    [SerializeField]
    private Player _player;
}
