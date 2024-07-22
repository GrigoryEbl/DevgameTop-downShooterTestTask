using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private int _scoresForKilling;

    public Action<int> Died;

    private void OnDestroy()
    {
        Died?.Invoke(_scoresForKilling);
    }
}
