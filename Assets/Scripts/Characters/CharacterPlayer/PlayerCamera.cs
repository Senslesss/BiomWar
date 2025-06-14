using Cinemachine;
using UnityEngine;
using Zenject;

namespace Characters.CharacterPlayer
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _playerCamera;
        private Transform _player;
        private Transform _mapCenter;
    
        [Inject]
        public void Construct(CharacterPlayer.Player player, MapCenter mapCenter)
        {
        
            _player = player.transform;
            _mapCenter = mapCenter.transform;
            _playerCamera.m_Follow = _player;
            _playerCamera.m_LookAt = _mapCenter;
        }
    }
}
