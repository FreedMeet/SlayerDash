using System;
using System.Collections;
using UnityEngine;

namespace Assets
{
    public class Bullet: MonoBehaviour
    {
        private const float LifeTime = 0.5f;

        private void OnEnable()
        {
            StartCoroutine(LifeRoutine());
        }

        private void OnDisable()
        {
            StopCoroutine(LifeRoutine());
        }

        private IEnumerator LifeRoutine()
        {
            yield return new WaitForSeconds(LifeTime);
            
            Deactivate();
            
        }

        private void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}


