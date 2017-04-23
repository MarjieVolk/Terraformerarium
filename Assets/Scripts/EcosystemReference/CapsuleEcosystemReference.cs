using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleEcosystemReference : EcosystemReference
{
    public override Ecosystem Ecosystem { get { return SceneState.CurrentCapsule; } }
}
