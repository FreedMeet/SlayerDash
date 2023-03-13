using Storage;
using Storage.Dash;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text dashCooldownText;
    
    private DashIterator _dashIterator;

    private float _dashCooldown;
    private float _currentDashCooldown;
    
    private void Start()
    {
        _dashIterator = Game.GetIterator<DashIterator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_dashIterator == null)
            return;
        
        DashCooldownUpdate();
        _dashCooldown = _dashIterator.DashCooldown;
    }

    private void DashCooldownUpdate()
    {
        var canDash = _dashIterator.CanDash;

        if (canDash)
        {
            dashCooldownText.text = "Dash: Ready";
            _currentDashCooldown = _dashCooldown;
        }
        else
        {
            _currentDashCooldown -= Time.deltaTime;
            dashCooldownText.text = $"Dash: {_currentDashCooldown:F1}";
        }
    }
}
