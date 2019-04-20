using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3 : TurnZone {
    public Material[] grounds;
    public Color32 color;
    public override void Start() {
        base.Start();
        foreach (Material a in grounds)
            a.color = Color.white;
    }
    public override void Fixposition()
    {
        base.Fixposition();
        foreach (Material a in grounds)
            a.color = color;
    }
}
