// using System.Collections;
// using UnityEngine;
// using UnityEngine.UI;
//
// public class UIScript : MonoBehaviour
// {
//     public Text dashCooldownText;
//     
//     private Dash _dash;
//
//     private float _dashCooldown;
//     private float _currentDashCooldown;
//     
//
//     private void Start()
//     {
//         if (!_dash)
//             _dash = FindObjectOfType<Dash>();
//     }
//
//     // Update is called once per frame
//     private void Update()
//     {
//         DashCooldownUpdate();
//         _dashCooldown = _dash.dashCooldown;
//     }
//
//     private void DashCooldownUpdate()
//     {
//         var canDash = _dash.canDash;
//
//         if (canDash)
//         {
//             dashCooldownText.text = "Dash: Ready";
//             _currentDashCooldown = _dashCooldown;
//         }
//         else
//         {
//             _currentDashCooldown -= Time.deltaTime;
//             dashCooldownText.text = $"Dash: {_currentDashCooldown:F1}";
//         }
//     }
// }
