using UnityEngine;

namespace Gameplay.Player
{   
    public class PlayerManager : MonoBehaviour
    {    
        [SerializeField] private float _maxDistance = 3;
        [SerializeField] private float _speed = 0.1f;

        private StateMoving _pos = StateMoving.MovingCenter;

        private Transform _transform;

        private Vector3 _maxLeftPos;
        private Vector3 _maxRightPos;
        private Vector3 _defaultPos;

        private void Start()
        {
            _transform = GetComponent<Transform>();

            _defaultPos = transform.position;
            _maxLeftPos = _transform.position;
            _maxRightPos = _transform.position;

            _maxLeftPos.x -= _maxDistance;
            _maxRightPos.x += _maxDistance;         
        }

        // Update is called once per frame
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
               switch(_pos)
               {
                case StateMoving.MovingCenter:
                    _pos = StateMoving.MovingLeft;                    
                    break;

                case StateMoving.MovingRight:
                    _pos = StateMoving.MovingCenter;
                    break;
                
                default:
                    break;
               }
            }

            else if(Input.GetKeyDown(KeyCode.D))
            {
                switch(_pos)
                {
                    case StateMoving.MovingCenter:
                        _pos = StateMoving.MovingRight;
                        break;

                    case StateMoving.MovingLeft:
                        _pos = StateMoving.MovingCenter;
                        break;
                    
                    default:
                        break;
                }
            }            
        }

        private void FixedUpdate()
        {
            Moving();
        }

        private void Moving()
        {
            switch(_pos)
            {    
                case StateMoving.MovingLeft:
                MoveTo(_maxLeftPos);
                break;

                case StateMoving.MovingCenter:
                MoveTo(_defaultPos);
                break;

                case StateMoving.MovingRight:
                MoveTo(_maxRightPos);
                break;

                default:
                break;
            }
        }

        private void MoveTo(Vector3 pos)
        {
            transform.position = Vector3.Lerp(transform.position, pos, _speed);
        }

        private enum StateMoving
        {
            Moving,
            MovingLeft,
            MovingRight,
            MovingCenter
        }
    }
   
}
