using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.SceneManagement
{
    public class Portal : MonoBehaviour
    {
        private  void OnTriggerEnter(Collider other)
        {
            print("Portal triggered");
        }
    }

}
