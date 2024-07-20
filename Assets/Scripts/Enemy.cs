using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private int _pointsForKilling;

    public int GetPoints()
    {
        return _pointsForKilling;
    }
}
