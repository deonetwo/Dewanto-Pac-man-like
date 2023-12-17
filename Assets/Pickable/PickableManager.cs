using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickableManager : MonoBehaviour
{
    private List<Pickable> _pickableList = new List<Pickable>();

    [SerializeField]
    private ScoreManager _scoreManager;

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
        _scoreManager.SetMaxScore(_pickableList.Count);
        Debug.Log("Pickable List: " + _pickableList.Count);
    }

    private void OnPickablePicked(Pickable pickable)
    {
        _pickableList.Remove(pickable);
        Destroy(pickable.gameObject);
        Debug.Log("Pickable List: " + _pickableList.Count);
        if (_scoreManager != null)
        {
            _scoreManager.AddScore(1);
        }
        if (_pickableList.Count <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }
        if (pickable._pickableType == PickableType.PowerUp)
        {
            _player?.PickPowerUp();
        }
    }

    [SerializeField]
    private Player _player;
}
