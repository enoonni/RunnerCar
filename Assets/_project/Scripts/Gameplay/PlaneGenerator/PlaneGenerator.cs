using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Location
{
    public class PlaneGenerator : MonoBehaviour
    {
       [SerializeField] private float _speed = 1;
       [SerializeField] private GameObject _location;
       [SerializeField] private GameObject _firstPlane;

       private const float _sizePlane = 220;

       private Vector3 _direction;

       private List<GameObject> _planes;

       private Transform _transofrm;

       private void Start()
       {
            _transofrm = GetComponent<Transform>();

            _direction = new Vector3(0, 0, -250);

            _planes = new List<GameObject>();
            _planes.Add(Instantiate(_location));
            _firstPlane.SetActive(false);
            InitRoad();
       }
       private void FixedUpdate()
       {
            foreach(var plane in _planes)
            {
                plane.transform.Translate(_direction * _speed * Time.deltaTime);
            }
            if(_planes[0].transform.position.z <= (-_sizePlane))
            {
                AddPlane();
                var plane = _planes[0];
                _planes.RemoveAt(0);
                Destroy(plane);
            }
       }
       private void InitRoad()
       {
            while(_planes.Count < 6)
            {
                var plane = Instantiate(_location);
                var pos = _planes[_planes.Count - 1].transform.position;
                plane.transform.position = new Vector3(pos.x, pos.y, pos.z + _sizePlane);
                _planes.Add(plane);
            }
       }

       private void AddPlane()
       {
            var plane = Instantiate(_location);
            var pos = _planes[_planes.Count - 1].transform.position;
            plane.transform.position = new Vector3(pos.x, pos.y, pos.z + _sizePlane);
            _planes.Add(plane);
       }
    }
}
