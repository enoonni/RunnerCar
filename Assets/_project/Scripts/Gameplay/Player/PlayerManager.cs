using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Gameplay.Player
{
    public class PlayerManager : MonoBehaviour
    {
        private List<Transform> _listPos;
        // Start is called before the first frame update
        void Start()
        {
            _listPos.Add(transform);
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
