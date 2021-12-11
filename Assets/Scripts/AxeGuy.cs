using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeGuy : Enemy
{
    public override float TreePosition { get; set; } = -0.19f;
    public override float Hp { get; set; } = 5;
    public override float Speed { get; set; } = 1;
    public override int Damage { get; set; } = 1;
}
