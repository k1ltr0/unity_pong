using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Mode
{
    PVP, PVCPU
};

public class Options : MonoBehaviour
{
    static Mode mode = Mode.PVP;

    public void SetPVPMode()
    {
        Options.mode = Mode.PVP;
    }

    public void SetPVCPUMode()
    {
        Options.mode = Mode.PVCPU;
    }
}
