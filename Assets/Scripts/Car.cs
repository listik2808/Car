using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private List<Animator> _animators = new List<Animator>();

        private const string WheelRotationForward = "ForwardRotation";
        private const string WheelRotationBack = "BackRotation";

        public void PlayWheelRotationForward()
        {
            foreach (var item in _animators)
            {
                item.SetBool(WheelRotationForward, true);
            }
        }

        public void DisableWheelRotationForward()
        {
            foreach (var item in _animators)
            {
                item.SetBool(WheelRotationForward, false);
            }
        }

        public void PlayWheelRotationBack()
        {
            foreach (var item in _animators)
            {
                item.SetBool(WheelRotationBack, true);
            }
        }

        public void DisableWheelRotationBack()
        {
            foreach (var item in _animators)
            {
                item.SetBool(WheelRotationBack, false);
            }
        }
    }
}