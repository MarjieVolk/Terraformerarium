using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetEcosystemReference : EcosystemReference
{
    public override Ecosystem Ecosystem { get { return SceneState.GetCurrentLevel().InitialPlanet; } }
}
