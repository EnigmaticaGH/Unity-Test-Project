using UnityEngine;
using System.Collections;
using System.Threading;

public class Ability
{
    public enum Status
    {
        Ready,
        Active,
        Cooldown
    }
    public string Name { get; private set; }
    public delegate void AbilityFunction(Ability This);
    public float ActiveTime { get; private set; }
    public float CooldownTime { get; private set; }
    public Status AbilityStatus { get; private set; }
    private AbilityFunction Active;
    private Timer timer;
    public Ability(string name, KeyCode key, AbilityFunction active, float activeTime, float cooldownTime)
    {
        Name = name;
        Active = active;
        CooldownTime = cooldownTime;
        ActiveTime = activeTime;
        AbilityStatus = Status.Ready;
        GameInput.EditControl(name, key);
    }
    private void Ready(object state)
    {
        timer.Dispose();
        AbilityStatus = Status.Ready;
    }
    public void Activate()
    {
        AbilityStatus = Status.Active;
        Active(this);
        timer = new Timer(Cooldown, null, (int)(ActiveTime * 1000), -1);
    }
    private void Cooldown(object state)
    {
        AbilityStatus = Status.Cooldown;
        timer = new Timer(Ready, null, (int)(CooldownTime * 1000), -1);
    }
}
