using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsChanger : MonoBehaviour
{
    public GameObject settings;
    public TextChanger SettingsScript;
    public int LastCommand = 1; //stores last command #
    public int i = 0; //for keeping track of what row the Blog is on

    public string PreviousRaftType = "Full Raft";
    public int PreviousLayerThickness = 25;
    public string PreviousRL = "True"; //Raft Label 
    public double PreviousD = 1.00;//Density
    public float PreviousTPS = 0.60f; //Touchpoint Size
    public string PreviousIS = "True"; //Internal Supports
    public double PreviousSM = 1.00; //Slope Modifier
    public double PreviousHAR = 5.00;//Height above raft
    public double PreviousRTH = 2.00; //Raft thickness
    public double PreviousScale = 1.00; //Scale
    public double PreviousXScale = 1.00; //xscale
    public double PreviousYScale = 1.00; //yscale
    public double PreviousZScale = 1.00; //zscale

    public void BlogOutput() //using blog because for some reason log wouldnt work
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();
        if (i == 15)
        {
            SettingsScript.Blog[0] = "";
            SettingsScript.Blog[1] = "";
            SettingsScript.Blog[2] = "";
            SettingsScript.Blog[3] = "";
            SettingsScript.Blog[4] = "";
            SettingsScript.Blog[5] = "";
            SettingsScript.Blog[6] = "";
            SettingsScript.Blog[7] = "";
            SettingsScript.Blog[8] = "";
            SettingsScript.Blog[9] = "";
            SettingsScript.Blog[10] = "";
            SettingsScript.Blog[11] = "";
            SettingsScript.Blog[12] = "";
            SettingsScript.Blog[13] = "";
            SettingsScript.Blog[14] = "";
            i = 0;
        }
    }
    public void RaftTypeFR() //changes raft type to full raft
    {
        TextChanger SettingsScript;                             //these two lines give access to the variables in the other file
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousRaftType = SettingsScript.RT; //this command is for the undo command
        SettingsScript.RT = "Full Raft"; //this changes the variable RT - Raft Type in the TextChanger file
        LastCommand = 1; //this is the command number, for use in the undo command, this is command 1
        BlogOutput(); //this resets the log if it reaches max lines
        SettingsScript.Blog[i] = "Raft Type Updated to 'Full Raft'"; //this updates the log
        i += 1; //this is the line position for the log
        SettingsScript.NewRaftTypeS = "2";//2 represents full raft in object preparation code. this is for sending
        SettingsScript.TextChange(); //updates the text on screen
    }
    public void RaftTypeMR() //changes raft type to mini rafts
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousRaftType = SettingsScript.RT;
        SettingsScript.RT = "Mini Rafts";
        BlogOutput();
        SettingsScript.Blog[i] = "Raft Type Updated to 'Mini Rafts'";
        i += 1;
        SettingsScript.NewRaftTypeS = "1";
        SettingsScript.TextChange();
        LastCommand = 2;
    }
    public void RaftTypeN() //changes raft type to none
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousRaftType = SettingsScript.RT;
        SettingsScript.RT = "None";
        BlogOutput();
        SettingsScript.Blog[i] = "Raft Type Updated to 'None'";
        i += 1;
        SettingsScript.NewRaftTypeS = "3";
        SettingsScript.TextChange();
        LastCommand = 3;
    }
    public void RaftLabelToggle() //Toggles Raft Label
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();
        if (SettingsScript.RL == "False")
        {
            SettingsScript.RL = "True";
            BlogOutput();
            SettingsScript.Blog[i] = "Raft Label Toggled";
            i += 1;
            SettingsScript.TextChange();
        }
        else if (SettingsScript.RL == "True")
        {
            SettingsScript.RL = "False";
            BlogOutput();
            SettingsScript.Blog[i] = "Raft Label Toggled";
            i += 1;
            SettingsScript.TextChange();
        }
        LastCommand = 4;
    }
    public void InternalSupportsToggle() //Toggles Internal Supports
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();
        if (SettingsScript.IS == "False")
        {
            SettingsScript.IS = "True";
            BlogOutput();
            SettingsScript.Blog[i] = "Internal Supports Toggled";
            i += 1;
            SettingsScript.TextChange();
        }
        else if (SettingsScript.IS == "True")
        {
            SettingsScript.IS = "False";
            BlogOutput();
            SettingsScript.Blog[i] = "Internal Supports Toggled";
            i += 1;
            SettingsScript.TextChange();
        }
        LastCommand = 5;
    }
    public void DensityIncreasePoint05() //increases density by .05
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.D += 0.05;
        BlogOutput();
        SettingsScript.Blog[i] = "Density Increased by 0.05";
        i += 1;
        SettingsScript.DensityS = "1";
        SettingsScript.TextChange();
        SettingsScript.DensityS = "0";
        LastCommand = 6;
    }
    public void DensityIncreasePoint1() //increases density by .1
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.D += 0.1;
        BlogOutput();
        SettingsScript.Blog[i] = "Density Increased by 0.1";
        i += 1;
        SettingsScript.DensityS = "2";
        SettingsScript.TextChange();
        SettingsScript.DensityS = "0";
        LastCommand = 7;
    }
    public void DensityDecreasePoint05() //decrease density by .05
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.D -= 0.05;
        BlogOutput();
        SettingsScript.Blog[i] = "Density Decreased by 0.05";
        i += 1;
        SettingsScript.DensityS = "3";
        SettingsScript.TextChange();
        SettingsScript.DensityS = "0";
        LastCommand = 8;
    }
    public void DensityDecreasePoint1() //decrease density by .1
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.D -= 0.1;
        BlogOutput();
        SettingsScript.Blog[i] = "Density Decreased by 0.1";
        i += 1;
        SettingsScript.DensityS = "4";
        SettingsScript.TextChange();
        SettingsScript.DensityS = "0";
        LastCommand = 9;
    }
    public void TouchPointSizeIncreasePoint05() //increase touch point size by .05
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.TPS += 0.05f;
        BlogOutput();
        SettingsScript.Blog[i] = "Touch Point Size Increased by 0.05";
        i += 1;
        SettingsScript.TouchpointSizeS = "1";
        SettingsScript.TextChange();
        SettingsScript.TouchpointSizeS = "0";
        LastCommand = 10;
    }
    public void TouchPointSizeIncreasePoint1() //increase touch point size by .1
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.TPS += 0.1f;
        BlogOutput();
        SettingsScript.Blog[i] = "Touch Point Size Increased by 0.1";
        i += 1;
        SettingsScript.TouchpointSizeS = "2";
        SettingsScript.TextChange();
        SettingsScript.TouchpointSizeS = "0";
        LastCommand = 11;
    }
    public void TouchPointSizeDecreasePoint05() //decrease touch point size by .05
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.TPS -= 0.05f;
        BlogOutput();
        SettingsScript.Blog[i] = "Touch Point Size Decreased by 0.05";
        i += 1;
        SettingsScript.TouchpointSizeS = "3";
        SettingsScript.TextChange();
        SettingsScript.TouchpointSizeS = "0";
        LastCommand = 12;
    }
    public void TouchPointSizeDecreasePoint1() //decrease touch point size by .1
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.TPS -= 0.1f;
        BlogOutput();
        SettingsScript.Blog[i] = "Touch Point Size Decreased by 0.1";
        i += 1;
        SettingsScript.TouchpointSizeS = "4";
        SettingsScript.TextChange();
        SettingsScript.TouchpointSizeS = "0";
        LastCommand = 13;
    }
    public void SlopeMultiplierIncreasePoint05() //increase slope multiplier size by .05
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.SM += 0.05;
        BlogOutput();
        SettingsScript.Blog[i] = "Slope Multiplier Increased by 0.05";
        i += 1;
        SettingsScript.SlopeModifierS = "1";
        SettingsScript.TextChange();
        SettingsScript.SlopeModifierS = "0"; 
        LastCommand = 14;
    }
    public void SlopeMultiplierIncreasePoint1() //increase slope multiplier size by .1
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.SM += 0.1;
        BlogOutput();
        SettingsScript.Blog[i] = "Slope Multiplier Increased by 0.1";
        i += 1;
        SettingsScript.SlopeModifierS = "2";
        SettingsScript.TextChange();
        SettingsScript.SlopeModifierS = "0";
        LastCommand = 15;
    }
    public void SlopeMultiplierDecreasePoint05() //decrease slope multiplier size by .05
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.SM -= 0.05;
        BlogOutput();
        SettingsScript.Blog[i] = "Slope Multiplier Decreased by 0.05";
        i += 1;
        SettingsScript.SlopeModifierS = "3";
        SettingsScript.TextChange();
        SettingsScript.SlopeModifierS = "0";
        LastCommand = 16;
    }
    public void SlopeMultiplierDecreasePoint1() //decrease slope multiplier size by .1
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.SM -= 0.1;
        BlogOutput();
        SettingsScript.Blog[i] = "Slope Multiplier Decreased by 0.1";
        i += 1;
        SettingsScript.SlopeModifierS = "4";
        SettingsScript.TextChange();
        SettingsScript.SlopeModifierS = "0";
        LastCommand = 17;
    }
    public void HeightAboveRaftIncreasePoint5() //increase height above raft by .5mm
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.HAR += 0.5;
        BlogOutput();
        SettingsScript.Blog[i] = "Height Above Raft Increased by 0.5";
        i += 1;
        SettingsScript.HeightAboveRaftS = "1";
        SettingsScript.TextChange();
        SettingsScript.HeightAboveRaftS = "0";
        LastCommand = 18;
    }
    public void HeightAboveRaftIncrease1() //increase height above raft by 1mm
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.HAR += 1;
        BlogOutput();
        SettingsScript.Blog[i] = "Height Above Raft Increased by 1.0";
        i += 1;
        SettingsScript.HeightAboveRaftS = "2";
        SettingsScript.TextChange();
        SettingsScript.HeightAboveRaftS = "0";
        LastCommand = 19;
    }
    public void HeightAboveRaftDecreasePoint5() //decrease height above raft by .5mm
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.HAR -= 0.5;
        BlogOutput();
        SettingsScript.Blog[i] = "Height Above Raft Decreased by 0.5";
        i += 1;
        SettingsScript.HeightAboveRaftS = "3";
        SettingsScript.TextChange();
        SettingsScript.HeightAboveRaftS = "0";
        LastCommand = 20;
    }
    public void HeightAboveRaftDecrease1() //decrease height above raft by 1mm
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.HAR -= 1;
        BlogOutput();
        SettingsScript.Blog[i] = "Height Above Raft Decreased by 1.0";
        i += 1;
        SettingsScript.HeightAboveRaftS = "4";
        SettingsScript.TextChange();
        SettingsScript.HeightAboveRaftS = "0";
        LastCommand = 21;
    }
    public void RaftThicknessIncreasePoint05() //increase raft thickness by .05
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.RTH += 0.05;
        BlogOutput();
        SettingsScript.Blog[i] = "Raft Thickness Increased by 0.05";
        i += 1;
        SettingsScript.RaftThicknessS = "1";
        SettingsScript.TextChange();
        SettingsScript.RaftThicknessS = "0";
        LastCommand = 22;
    }
    public void RaftThicknessIncreasePoint1() //increase raft thickness by .1
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.RTH += 0.1;
        BlogOutput();
        SettingsScript.Blog[i] = "Raft Thickness Increased by 0.1";
        i += 1;
        SettingsScript.RaftThicknessS = "2";
        SettingsScript.TextChange();
        SettingsScript.RaftThicknessS = "0";
        LastCommand = 23;
    }
    public void RaftThicknessDecreasePoint05() //decrease raft thickness by .05
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.RTH -= 0.05;
        BlogOutput();
        SettingsScript.Blog[i] = "Raft Thickness Decreased by 0.05";
        i += 1;
        SettingsScript.RaftThicknessS = "3";
        SettingsScript.TextChange();
        SettingsScript.RaftThicknessS = "0";
        LastCommand = 24;
    }
    public void RaftThicknessDecreasePoint1() //decrease raft thickness by .1
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.RTH -= 0.1;
        BlogOutput();
        SettingsScript.Blog[i] = "Raft Thickness Decreased by 0.1";
        i += 1;
        SettingsScript.RaftThicknessS = "4";
        SettingsScript.TextChange();
        SettingsScript.RaftThicknessS = "0";
        LastCommand = 25;
    }
    public void ScaleIncreasePoint1() //increase scale by 0.1 
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.Scale += 0.1;
        BlogOutput();
        SettingsScript.Blog[i] = "Scale Increased by 0.1";
        i += 1;
        SettingsScript.ScaleS = "1";
        SettingsScript.TextChange();
        SettingsScript.ScaleS = "0";
        LastCommand = 26;
    }
    public void ScaleIncreasePoint2() //increase scale by 0.2 
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.Scale += 0.2;
        BlogOutput();
        SettingsScript.Blog[i] = "Scale Increased by 0.2";
        i += 1;
        SettingsScript.ScaleS = "2";
        SettingsScript.TextChange();
        SettingsScript.ScaleS = "0";
        LastCommand = 27;
    }
    public void ScaleIncreasePoint5() //increase scale by point 5 
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.Scale += 0.5;
        BlogOutput();
        SettingsScript.Blog[i] = "Scale Increased by 0.5";
        i += 1;
        SettingsScript.TextChange(); //no command for this yet do later ok? dont forget 
        LastCommand = 28;
    }
    public void ScaleDecreasePoint1() //decrease scale by 0.1 
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.Scale -= 0.1;
        BlogOutput();
        SettingsScript.Blog[i] = "Scale Decreased by 0.1";
        i += 1;
        SettingsScript.ScaleS = "3";
        SettingsScript.TextChange();
        SettingsScript.ScaleS = "0";
        LastCommand = 29;
    }
    public void ScaleDecreasePoint2() //decrease scale by 0.2 
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.Scale -= 0.2;
        BlogOutput();
        SettingsScript.Blog[i] = "Scale Decreased by 0.2";
        i += 1;
        SettingsScript.ScaleS = "4";
        SettingsScript.TextChange();
        SettingsScript.ScaleS = "0";
        LastCommand = 30;
    }
    public void ScaleDecreasePoint5() //decrease scale by point 5 
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.Scale -= 0.5;
        BlogOutput();
        SettingsScript.Blog[i] = "Scale Decreased by 0.5";
        i += 1;
        SettingsScript.TextChange();//no command for this yet do later ok? dont forget
        LastCommand = 31;
    }
    //legacy code... layerthickness cannot be changed after the program has started
    /*public void LayerThickness25() //change layer thickness to 25
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousLayerThickness = SettingsScript.LT;
        SettingsScript.LT = 25;
        BlogOutput();
        SettingsScript.Blog[i] = "Layer Thickness Updated";
        i += 1;
        SettingsScript.TextChange();
        LastCommand = 32;
    }
    public void LayerThickness50() //change layer thickness to 50
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousLayerThickness = SettingsScript.LT;
        SettingsScript.LT = 50;
        BlogOutput();
        SettingsScript.Blog[i] = "Layer Thickness Updated";
        i += 1;
        SettingsScript.TextChange();
        LastCommand = 33;

    }
    public void LayerThickness100() //change layer thickness to 100
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousLayerThickness = SettingsScript.LT;
        SettingsScript.LT = 100;
        BlogOutput();
        SettingsScript.Blog[i] = "Layer Thickness Updated";
        i += 1;
        SettingsScript.TextChange();
        LastCommand = 34;
    }*/
    public void ResetAll() //resets all values to default
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousLayerThickness = SettingsScript.LT;
        PreviousRaftType = SettingsScript.RT;
        PreviousRL = SettingsScript.RL;
        PreviousD = SettingsScript.D;
        PreviousTPS = SettingsScript.TPS;
        PreviousIS = SettingsScript.IS;
        PreviousSM = SettingsScript.SM;
        PreviousHAR = SettingsScript.HAR;
        PreviousRTH = SettingsScript.RTH;
        PreviousScale = SettingsScript.Scale;
        PreviousXScale = SettingsScript.XScale;
        PreviousYScale = SettingsScript.YScale;
        PreviousZScale = SettingsScript.ZScale;

        SettingsScript.RT = "Full Raft";
        SettingsScript.RL = "True"; 
        SettingsScript.D = 1.00;
        SettingsScript.TPS = 0.60f; 
        SettingsScript.IS = "True"; 
        SettingsScript.SM = 1.00; 
        SettingsScript.HAR = 5.00;
        SettingsScript.RTH = 2.00;  
        SettingsScript.Scale = 1.00;
        SettingsScript.XScale = 1.00;
        SettingsScript.YScale = 1.00;
        SettingsScript.ZScale = 1.00;
        SettingsScript.LT = 50; 
        BlogOutput();
        SettingsScript.Blog[i] = "All Settings Set to Default";
        i += 1;
        SettingsScript.TextChange();
        LastCommand = 35;
    }
    public void DefaultLayerThickness() //change layer thickness to default
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousLayerThickness = SettingsScript.LT;
        SettingsScript.LT = 50;
        BlogOutput();
        SettingsScript.Blog[i] = "Layer Thickness Set to Default";
        i += 1;
        SettingsScript.TextChange();
        LastCommand = 36;
    }
    public void DefaultRaftType() //change Raft Type to default
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousRaftType = SettingsScript.RT;
        SettingsScript.RT = "Full Raft";
        BlogOutput();
        SettingsScript.Blog[i] = "Raft Type Set to Default";
        i += 1;
        SettingsScript.TextChange();
        LastCommand = 37;
    }
    public void DefaultRaftLabel() //change raft label to default
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousRL = SettingsScript.RL;
        SettingsScript.RL = "True";
        BlogOutput();
        SettingsScript.Blog[i] = "Raft Label Set to Default";
        i += 1;
        SettingsScript.TextChange();
        LastCommand = 38;
    }
    public void DefaultDensity() //change density to default
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousD = SettingsScript.D;
        SettingsScript.D = 1.00;
        BlogOutput();
        SettingsScript.Blog[i] = "Density Set to Default";
        i += 1;
        SettingsScript.TextChange();
        LastCommand = 39;
    }
    public void DefaultTouchPointSize() //change touch point size to default
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousTPS = SettingsScript.TPS;
        SettingsScript.TPS = 0.60f;
        BlogOutput();
        SettingsScript.Blog[i] = "Touch Point Size Set to Default";
        i += 1;
        SettingsScript.TextChange();
        LastCommand = 40;
    }
    public void DefaultInternalSupports() //change internal supports to default
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousIS = SettingsScript.IS;
        SettingsScript.IS = "True";
        BlogOutput();
        SettingsScript.Blog[i] = "Internal Supports Set to Default";
        i += 1;
        SettingsScript.TextChange();
        LastCommand = 41;
    }
    public void DefaultSlopeModifier() //change Slope Modifier to default
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousSM = SettingsScript.SM;
        SettingsScript.SM = 1.00;
        BlogOutput();
        SettingsScript.Blog[i] = "Slope Modifier Set to Default";
        i += 1;
        SettingsScript.TextChange();
        LastCommand = 42;
    }
    public void DefaultHeightAboveRaft() //change Height above raft to default
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousHAR = SettingsScript.HAR;
        SettingsScript.HAR = 5.00;
        BlogOutput();
        SettingsScript.Blog[i] = "Height Above Raft Set to Default";
        i += 1;
        SettingsScript.TextChange();
        LastCommand = 43;
    }
    public void DefaultRaftThickness() //change raft thickness to default
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousRTH = SettingsScript.RTH;
        SettingsScript.RTH = 2.00;
        BlogOutput();
        SettingsScript.Blog[i] = "Raft Thickness Set to Default";
        i += 1;
        SettingsScript.TextChange();
        LastCommand = 44;
    }
    public void DefaultScale() //change scale to default
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousScale = SettingsScript.Scale;
        SettingsScript.Scale = 1.00;
        BlogOutput();
        SettingsScript.Blog[i] = "Scale Set to Default";
        i += 1;
        SettingsScript.TextChange();
        LastCommand = 45;
    }
    public void XScaleIncreasePoint1() //increase x scale by .1
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.XScale += 0.1;
        BlogOutput();
        SettingsScript.Blog[i] = "X Scale Increased by 0.1";
        i += 1;
        SettingsScript.XScaleS = "1";
        SettingsScript.TextChange();
        SettingsScript.XScaleS = "0";
        LastCommand = 46;
    }
    public void XScaleDecreasePoint1() //decrease x scale by .1
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.XScale -= 0.1;
        BlogOutput();
        SettingsScript.Blog[i] = "X Scale Decreased by 0.1";
        i += 1;
        SettingsScript.XScaleS = "3";
        SettingsScript.TextChange();
        SettingsScript.XScaleS = "0";
        LastCommand = 47;
    }
    public void YScaleIncreasePoint1() //increase y scale by .1
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.YScale += 0.1;
        BlogOutput();
        SettingsScript.Blog[i] = "Y Scale Increased by 0.1";
        i += 1;
        SettingsScript.YScaleS = "1";
        SettingsScript.TextChange();
        SettingsScript.YScaleS = "0";
        LastCommand = 48;
    }
    public void YScaleDecreasePoint1() //decrease y scale by .1
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.YScale -= 0.1;
        BlogOutput();
        SettingsScript.Blog[i] = "Y Scale Decreased by 0.1";
        i += 1;
        SettingsScript.YScaleS = "3";
        SettingsScript.TextChange();
        SettingsScript.YScaleS = "0";
        LastCommand = 49;
    }
    public void ZScaleIncreasePoint1() //increase z scale by .1
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.ZScale += 0.1;
        BlogOutput();
        SettingsScript.Blog[i] = "Z Scale Increased by 0.1";
        i += 1;
        SettingsScript.ZScaleS = "1";
        SettingsScript.TextChange();
        SettingsScript.ZScaleS = "0";
        LastCommand = 50;
    }
    public void ZScaleDecreasePoint1() //decrease z scale by .1
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        SettingsScript.ZScale -= 0.1;
        BlogOutput();
        SettingsScript.Blog[i] = "Z Scale Decreased by 0.1";
        i += 1;
        SettingsScript.ZScaleS = "3";
        SettingsScript.TextChange();
        SettingsScript.ZScaleS = "0";
        LastCommand = 51;
    }
    public void DefaultXScale() //change x scale to default
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousXScale = SettingsScript.XScale;
        SettingsScript.XScale = 1.00;
        BlogOutput();
        SettingsScript.Blog[i] = "X Scale Set to Default";
        i += 1;
        SettingsScript.TextChange();
        LastCommand = 52;
    }
    public void DefaultYScale() //change y scale to default
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousYScale = SettingsScript.YScale;
        SettingsScript.YScale = 1.00;
        BlogOutput();
        SettingsScript.Blog[i] = "Y Scale Set to Default";
        i += 1;
        SettingsScript.TextChange();
        LastCommand = 53;
    }
    public void DefaultZScale() //change z scale to default
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        PreviousZScale = SettingsScript.ZScale;
        SettingsScript.ZScale = 1.00;
        BlogOutput();
        SettingsScript.Blog[i] = "Z Scale Set to Default";
        i += 1;
        SettingsScript.TextChange();
        LastCommand = 54;
    }
    public void SendToPrinter() //send to printer
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.StartPrintS = "True";
        SettingsScript.Blog[i] = "Sending to Printer";
        i += 1;
        SettingsScript.TextChange();
        SettingsScript.StartPrintS = "False";
    }
    public void OneClickPrintFunction() //one click print
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.OneClickS = "True";
        SettingsScript.Blog[i] = "Using One-Click-Print Function";
        i += 1;
        SettingsScript.TextChange();
        SettingsScript.OneClickS = "False";
    }
    public void AutoOrientObject() //auto orient object
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.AutoOrientS = "True";
        SettingsScript.Blog[i] = "Object Oriented";
        i += 1;
        SettingsScript.TextChange();
        SettingsScript.AutoOrientS = "False";
    }
    public void AutoGenerateSupports() //auto generate supports
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.AutoGenerateS = "True";
        SettingsScript.Blog[i] = "Supports Generated";
        i += 1;
        SettingsScript.TextChange();
        SettingsScript.AutoGenerateS = "False";
    }
    public void AutoGenerateLayout() //auto generate layout
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.GenerateLayoutS = "True";
        SettingsScript.Blog[i] = "Layout Generated";
        i += 1;
        SettingsScript.TextChange();
        SettingsScript.GenerateLayoutS = "False";
    }
    /*public void Help() 
    { OLD HELP  Screen
        
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        i = 15;
        BlogOutput();
        SettingsScript.Blog[0] = "Command List: (Say 'SETTING_Help' to display help on that setting)";
        SettingsScript.Blog[1] = "Close Settings | Open Settings | Toggle Raft Label | Go Back (Undo)";
        SettingsScript.Blog[2] = "Toggle Internal Supports | Increase/Decrease Density Point Zero Five |";
        SettingsScript.Blog[3] = "Increase/Decrease Density Point One | Increase/Decrease Slope Multiplier Point One |";
        SettingsScript.Blog[4] = "Increase/Decrease Slope Multiplier Point Zero Five | Change Raft Type Mini Rafts |";
        SettingsScript.Blog[5] = "Change Raft Type Full Raft | Change Raft Type None | Increase/Decrease Touch Point";
        SettingsScript.Blog[6] = "Size Point Zero Five | Increase/Decrease Touch Point Size Point One | Increase/Decrease";
        SettingsScript.Blog[7] = "Height Above Raft Point Five | Increase/Decrease Height Above Raft Point One | ";
        SettingsScript.Blog[8] = "Increase/Decrease Raft Thickness Point Zero Five | Increase/Decrease Raft Thickness";
        SettingsScript.Blog[9] = "Point One | Increase/Decrease Scale Point One/Two/Three | Increase/Decrease X/Y/Z Scale";
        SettingsScript.Blog[10] = "Point One | One Click Print | Auto Orient Object | Auto Generate Supports |";
        SettingsScript.Blog[11] = "Set SETTING default | Reset All Default | How do I know my part is ready to print? |";
        SettingsScript.Blog[12] = "How do I replace resin? | When do I replace resin? | How long do I wash and cure? |";
        SettingsScript.Blog[13] = "What can go wrong during a print? | How do I print? | How do I clean nozzle?";
        SettingsScript.Blog[14] = "Warning: Using a non-listed command may result in random command being executed";
        i = 15;
        SettingsScript.TextChange();
    }*/
    public void Help()//lists commands /tree start
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        i = 15;
        BlogOutput();
        SettingsScript.Blog[0] = "What would you like help with?";
        SettingsScript.Blog[1] = "Setting change commands";
        SettingsScript.Blog[2] = "Basic commands";
        SettingsScript.Blog[3] = "Frequently asked questions";
        SettingsScript.Blog[4] = "";
        SettingsScript.Blog[5] = "";
        SettingsScript.Blog[6] = "Warning: Using a non-listed command may result in random command being executed";
        SettingsScript.Blog[7] = "";
        SettingsScript.Blog[8] = "";
        SettingsScript.Blog[9] = "";
        SettingsScript.Blog[10] = "";
        SettingsScript.Blog[11] = "";
        SettingsScript.Blog[12] = "";
        SettingsScript.Blog[13] = "";
        SettingsScript.Blog[14] = "";
        i = 15;
        SettingsScript.TextChange();
        
    }
    public void Help1() //setting change commands /tree 1
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        i = 15;
        BlogOutput();
        SettingsScript.Blog[0] = "Setting change commands are as follows: (ex. 'Increase density point one')";
        SettingsScript.Blog[1] = "change raft type [full raft/mini rafts/none], toggle internal supports,";
        SettingsScript.Blog[2] = "toggle raft label, change layer thickness [100/50/25], Go back (undo command),";
        SettingsScript.Blog[3] = "[increase/decrease] density point [one/zero five],";
        SettingsScript.Blog[4] = "[increase/decrease] slope multiplier point [one/zero five],";
        SettingsScript.Blog[5] = "[increase/decrease] touch point size point [one/zero five],";
        SettingsScript.Blog[6] = "[increase/decrease] height above raft [one/point five],";
        SettingsScript.Blog[7] = "[increase/decrease] raft thickness point [one/zero five],";
        SettingsScript.Blog[8] = "[increase/decrease] scale point [one/two/five],";
        SettingsScript.Blog[9] = "[increase/decrease] [x/y/z] scale point one,";
        SettingsScript.Blog[10] = "set SETTING_NAME default (ex. set height above raft default), Reset all";
        SettingsScript.Blog[11] = "";
        SettingsScript.Blog[12] = "";
        SettingsScript.Blog[13] = "";
        SettingsScript.Blog[14] = "";
        i = 15;
        SettingsScript.TextChange();
    }
    
    
     public void Help2() //Basic commands /tree 2
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        i = 15;
        BlogOutput();
        SettingsScript.Blog[0] = "Basic commands are as follows:";
        SettingsScript.Blog[1] = "open settings, close settings, clear (clears log),";
        SettingsScript.Blog[2] = "auto generate supports, auto orient object, auto generate layout,";
        SettingsScript.Blog[3] = "send to printer (prints object with current settings),";
        SettingsScript.Blog[4] = "go back (undo command),";
        SettingsScript.Blog[5] = "reset all (resets all settings to default),";
        SettingsScript.Blog[6] = "help (main help screen),";
        SettingsScript.Blog[7] = "setting change commands (displays all setting change commands),";
        SettingsScript.Blog[8] = "basic commands (displays current help screen),";
        SettingsScript.Blog[9] = "frequently asked questions (displays question help screen),";
        SettingsScript.Blog[10] = "one click print (sends to printer with computer generated settings)";
        SettingsScript.Blog[11] = "SETTING_NAME help (ex. layer thickness help) (displays specific command help),";
        SettingsScript.Blog[12] = "";
        SettingsScript.Blog[13] = "";
        SettingsScript.Blog[14] = "";
        i = 15;
        SettingsScript.TextChange();
    }
    
    
     public void Help3() //frequently asked questions /tree 3
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        i = 15;
        BlogOutput();
        SettingsScript.Blog[0] = "Frequently asked questions are as follows: (ask the question to recieve answer)";
        SettingsScript.Blog[1] = "How do I know my part is ready to print?,";
        SettingsScript.Blog[2] = "How do I print?,";
        SettingsScript.Blog[3] = "How long do I let my object drip?,";
        SettingsScript.Blog[4] = "When do I break the part from the supports?,";
        SettingsScript.Blog[5] = "How long should I wash and cure?,";
        SettingsScript.Blog[6] = "How do I clean the nozzle?,";
        SettingsScript.Blog[7] = "When do I replace the resin?,";
        SettingsScript.Blog[8] = "How do I replace the resin?,";
        SettingsScript.Blog[9] = "What can go wrong during print?,";
        SettingsScript.Blog[10] = "SETTING_NAME help (ex. layer thickness help) (displays specific command help)";
        SettingsScript.Blog[11] = "";
        SettingsScript.Blog[12] = "";
        SettingsScript.Blog[13] = "";
        SettingsScript.Blog[14] = "";
        i = 15;
        SettingsScript.TextChange();
    }
    
    public void Undo() //undoes previous command. 60
    {
        if ((LastCommand == 1) || (LastCommand == 2) || (LastCommand == 3)) { //raft type commands 
            SettingsScript = settings.GetComponent<TextChanger>();
            SettingsScript.RT = PreviousRaftType;
            BlogOutput();
            SettingsScript.Blog[i] = "Raft Type Updated";
            i += 1;
            SettingsScript.UndoS = "True";
            SettingsScript.TextChange();
            SettingsScript.UndoS = "False";
        }
        else if (LastCommand == 4) //raft toggle command
            RaftLabelToggle();
        else if (LastCommand == 5) //internal supports toggle command
            InternalSupportsToggle();
        else if (LastCommand == 6) {//density increase .05 command
            DensityDecreasePoint05();
            LastCommand = 8;
        }
        else if (LastCommand == 7) {//density increase .1 command
            DensityDecreasePoint1();
            LastCommand = 9;
        }
        else if (LastCommand == 8) {//density decrease .05 command
            DensityIncreasePoint05();
            LastCommand = 6;
        }
        else if (LastCommand == 9) {//density decrease .1 command
            DensityIncreasePoint1();
            LastCommand = 7;
        }
        else if (LastCommand == 10) {//touch point size increase .05 command
            TouchPointSizeDecreasePoint05();
            LastCommand = 12;
        }
        else if (LastCommand == 11) {//touch point size increase .1 command
            TouchPointSizeDecreasePoint1();
            LastCommand = 13;
        }
        else if (LastCommand == 12) {//touch point size decrease .05 command
            TouchPointSizeIncreasePoint05();
            LastCommand = 10;
        }
        else if (LastCommand == 13) {//touch point size decrease .1 command
            TouchPointSizeIncreasePoint1();
            LastCommand = 11;
        }
        else if (LastCommand == 14) {//slope multiplier increase .05 command
            SlopeMultiplierDecreasePoint05();
            LastCommand = 16;
        }
        else if (LastCommand == 15) {//slope multiplier increase .1 command
            SlopeMultiplierDecreasePoint1();
            LastCommand = 17;
        }
        else if (LastCommand == 16) {//slope multiplier decrease .05 command
            SlopeMultiplierIncreasePoint05();
            LastCommand = 14;
        }
        else if (LastCommand == 17) {//slope multiplier decrease .1 command
            SlopeMultiplierIncreasePoint1();
            LastCommand = 15;
        }
        else if (LastCommand == 18) {//height above raft increase .5mm command
            HeightAboveRaftDecreasePoint5();
            LastCommand = 20;
        }
        else if (LastCommand == 19) {//height above raft increase 1mm command
            HeightAboveRaftDecrease1();
            LastCommand = 21;
        }
        else if (LastCommand == 20) {//height above raft decrease .5mm command
            HeightAboveRaftIncreasePoint5();
            LastCommand = 18;
        }
        else if (LastCommand == 21) {//height above raft decrease 1mm command
            HeightAboveRaftIncrease1();
            LastCommand = 19;
        }
        else if (LastCommand == 22) {//raft thickness increase .05 command
            RaftThicknessDecreasePoint05();
            LastCommand = 24;
        }
        else if (LastCommand == 23) {//raft thickness increase .1 command
            RaftThicknessDecreasePoint1();
            LastCommand = 25;
        }
        else if (LastCommand == 24) {//raft thickness decrease .05 command
            RaftThicknessIncreasePoint05();
            LastCommand = 22;
        }
        else if (LastCommand == 25) {//raft thickness decrease .1 command
            RaftThicknessIncreasePoint1();
            LastCommand = 23;
        }
        else if (LastCommand == 26) {//scale increase .1 command
            ScaleDecreasePoint1();
            LastCommand = 29;
        }
        else if (LastCommand == 27) {//scale increase .2 command
            ScaleDecreasePoint2();
            LastCommand = 30;
        }
        else if (LastCommand == 28) {//scale increase .5 command
            ScaleDecreasePoint5();
            LastCommand = 31;
        }
        else if (LastCommand == 29) {//scale decrease .1 command
            ScaleIncreasePoint1();
            LastCommand = 26;
        }
        else if (LastCommand == 30) { //scale decrease .2 command
            ScaleIncreasePoint2();
            LastCommand = 27;
        }
        else if (LastCommand == 31) { //scale decrease .5 command
            ScaleIncreasePoint5();
            LastCommand = 28;
        }
        else if ((LastCommand == 32) || (LastCommand == 33) || (LastCommand == 34))
        { //Layer thickness commands
            SettingsScript = settings.GetComponent<TextChanger>();
            SettingsScript.LT = PreviousLayerThickness;
            BlogOutput();
            SettingsScript.Blog[i] = "Layer Thickness Updated";
            i += 1;
            SettingsScript.UndoS = "True";
            SettingsScript.TextChange();
            SettingsScript.UndoS = "False";
        }
        else if (LastCommand == 35) //restores all settings
        {
            SettingsScript = settings.GetComponent<TextChanger>();
            SettingsScript.RT = PreviousRaftType;
            SettingsScript.RL = PreviousRL;
            SettingsScript.D = PreviousD;
            SettingsScript.TPS = PreviousTPS;
            SettingsScript.IS = PreviousIS;
            SettingsScript.SM = PreviousSM;
            SettingsScript.HAR = PreviousHAR;
            SettingsScript.RTH = PreviousRTH;
            SettingsScript.Scale = PreviousScale;
            SettingsScript.LT = PreviousLayerThickness;
            SettingsScript.XScale = PreviousXScale;
            SettingsScript.YScale = PreviousYScale;
            SettingsScript.ZScale = PreviousZScale;
            BlogOutput();
            SettingsScript.Blog[i] = "All Settings Restored";
            i += 1;
            SettingsScript.UndoS = "True";
            SettingsScript.TextChange();
            SettingsScript.UndoS = "False";
        }
        else if (LastCommand ==36) //restores layer thickness
        {
            SettingsScript = settings.GetComponent<TextChanger>();
            SettingsScript.LT = PreviousLayerThickness;
            BlogOutput();
            SettingsScript.Blog[i] = "Layer Thickness Restored";
            i += 1;
            SettingsScript.UndoS = "True";
            SettingsScript.TextChange();
            SettingsScript.UndoS = "False";
        }
        else if (LastCommand == 37) //restores raft type
        {
            SettingsScript = settings.GetComponent<TextChanger>();
            SettingsScript.RT = PreviousRaftType;
            BlogOutput();
            SettingsScript.Blog[i] = "Raft Type Restored";
            i += 1;
            SettingsScript.UndoS = "True";
            SettingsScript.TextChange();
            SettingsScript.UndoS = "False";
        }
        else if (LastCommand == 38) //restores raft label
        {
            SettingsScript = settings.GetComponent<TextChanger>();
            SettingsScript.RL = PreviousRL;
            BlogOutput();
            SettingsScript.Blog[i] = "Raft Label Restored";
            i += 1;
            SettingsScript.UndoS = "True";
            SettingsScript.TextChange();
            SettingsScript.UndoS = "False";
        }
        else if (LastCommand == 39) //restores density
        {
            SettingsScript = settings.GetComponent<TextChanger>();
            SettingsScript.D = PreviousD;
            BlogOutput();
            SettingsScript.Blog[i] = "Density Restored";
            i += 1;
            SettingsScript.UndoS = "True";
            SettingsScript.TextChange();
            SettingsScript.UndoS = "False";
        }
        else if (LastCommand == 40) //restores touch point size
        {
            SettingsScript = settings.GetComponent<TextChanger>();
            SettingsScript.TPS = PreviousTPS;
            BlogOutput();
            SettingsScript.Blog[i] = "Touch Point Size Restored";
            i += 1;
            SettingsScript.UndoS = "True";
            SettingsScript.TextChange();
            SettingsScript.UndoS = "False";
        }
        else if (LastCommand == 41) //restores internal supports
        {
            SettingsScript = settings.GetComponent<TextChanger>();
            SettingsScript.IS = PreviousIS;
            BlogOutput();
            SettingsScript.Blog[i] = "Internal Supports Restored";
            i += 1;
            SettingsScript.UndoS = "True";
            SettingsScript.TextChange();
            SettingsScript.UndoS = "False";
        }
        else if (LastCommand == 42) //restores slope modifier
        {
            SettingsScript = settings.GetComponent<TextChanger>();
            SettingsScript.SM = PreviousSM;
            BlogOutput();
            SettingsScript.Blog[i] = "Slope Modifier Restored";
            i += 1;
            SettingsScript.UndoS = "True";
            SettingsScript.TextChange();
            SettingsScript.UndoS = "False";
        }
        else if (LastCommand == 43) //restores height above raft
        {
            SettingsScript = settings.GetComponent<TextChanger>();
            SettingsScript.HAR = PreviousHAR;
            BlogOutput();
            SettingsScript.Blog[i] = "Height Above Raft Restored";
            i += 1;
            SettingsScript.UndoS = "True";
            SettingsScript.TextChange();
            SettingsScript.UndoS = "False";
        }
        else if (LastCommand == 44) //restores raft thickness
        {
            SettingsScript = settings.GetComponent<TextChanger>();
            SettingsScript.RTH = PreviousRTH;
            BlogOutput();
            SettingsScript.Blog[i] = "Raft Thickness Restored";
            i += 1;
            SettingsScript.UndoS = "True";
            SettingsScript.TextChange();
            SettingsScript.UndoS = "False";
        }
        else if (LastCommand == 45) //restores scale
        {
            SettingsScript = settings.GetComponent<TextChanger>();
            SettingsScript.Scale = PreviousScale;
            BlogOutput();
            SettingsScript.Blog[i] = "Scale Restored";
            i += 1;
            SettingsScript.UndoS = "True";
            SettingsScript.TextChange();
            SettingsScript.UndoS = "False";
        }     
        else if (LastCommand == 46) //decrease x scale .1
        {
            XScaleDecreasePoint1();
            LastCommand = 47;
        }
        else if (LastCommand == 47) //increase x scale .1
        {
            XScaleIncreasePoint1();
            LastCommand = 46;
        }
        else if (LastCommand == 48) //decrease y scale .1
        {
            YScaleDecreasePoint1();
            LastCommand = 49;
        }
        else if (LastCommand == 49) //increase y scale .1
        {
            YScaleIncreasePoint1();
            LastCommand = 48;
        }
        else if (LastCommand == 50) //decrease z scale .1
        {
            ZScaleDecreasePoint1();
            LastCommand = 51;
        }
        else if (LastCommand == 51) //increase z scale .1
        {
            ZScaleIncreasePoint1();
            LastCommand = 50;
        }
        else if (LastCommand == 52) //restores x scale
        {
            SettingsScript = settings.GetComponent<TextChanger>();
            SettingsScript.XScale = PreviousXScale;
            BlogOutput();
            SettingsScript.Blog[i] = "X Scale Restored";
            i += 1;
            SettingsScript.UndoS = "True";
            SettingsScript.TextChange();
            SettingsScript.UndoS = "False";
        }
        else if (LastCommand == 53) //restores y scale
        {
            SettingsScript = settings.GetComponent<TextChanger>();
            SettingsScript.YScale = PreviousYScale;
            BlogOutput();
            SettingsScript.Blog[i] = "Y Scale Restored";
            i += 1;
            SettingsScript.UndoS = "True";
            SettingsScript.TextChange();
            SettingsScript.UndoS = "False";
        }
        else if (LastCommand == 54) //restores z scale
        {
            SettingsScript = settings.GetComponent<TextChanger>();
            SettingsScript.ZScale = PreviousZScale;
            BlogOutput();
            SettingsScript.Blog[i] = "Z Scale Restored";
            i += 1;
            SettingsScript.UndoS = "True";
            SettingsScript.TextChange();
            SettingsScript.UndoS = "False";
        }
    }
    public void HelpRaftType() //Raft Type Help 61
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "RTH: Print your model on a single large raft, multiple small rafts, or the print bed";
        i += 1;
        SettingsScript.TextChange();
    }
    public void HelpRaftLabel() //Raft label help 62
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "RLH: Models name is generated on the raft of the support structure";
        i += 1;
        SettingsScript.TextChange();
    }
    public void HelpDensity() //density Help 63 
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "DH: Changes the number of touchpoints between your model and the support structure";
        i += 1;
        SettingsScript.TextChange();
    }
    public void HelpTouchPointSize() //touch point size help 64
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "TSPH: Changes diameter of points where support structure and model meet";
        i += 1;
        SettingsScript.TextChange();
    }
    public void HelpInternalSupports() //internal supports help 65
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "ISH: Internal supports are supports with both ends touching the model";
        i += 1;
        SettingsScript.TextChange();
    }
    public void HelpSlopeMultiplier() //slope multiplier Help66
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "SMH: Changes the density of support structures for surfaces set at an angle.";
        i += 1;
        SettingsScript.TextChange();
    }
    public void HelpHeightAboveRaft() //height above raft Help67
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "HARH: Changes how high a model sits above the raft";
        i += 1;
        SettingsScript.TextChange();
    }
    public void HelpRaftThickness() //Raft thickness Help68
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "RTHH: Thickness of the raft affects how a print stays connected to the build platform";
        i += 1;
        SettingsScript.TextChange();
    }
    public void HelpLayerThickness() //layer thickness Help69
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "LTH: Layer thickness affects speed and quality. Thicker layers print faster but lose detail";
        i += 1;
        SettingsScript.TextChange();
    }
    public void HelpScale() //Scale Help70
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "SH: Changes the scale of the object";
        i += 1;
        SettingsScript.TextChange();
    }
    public void ReadyToPrint() //How do I know my part is ready to print71
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "Wait for printer display to show 'Ready'";
        i += 1;
        SettingsScript.TextChange();
    }
    public void ObjectDripTime() //How long do I let my object drip72
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "Time depends on complexity of print, 1 hour - 1 day";
        i += 1;
        SettingsScript.TextChange();
    }
    public void BreakFromSupport() //When do I break the part from the supports73
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "After washing and before curing";
        i += 1;
        SettingsScript.TextChange();
    }
    public void WashCureTime() //How long should I wash and cure74
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "Refer to manual";
        i += 1;
        SettingsScript.TextChange();
    }
    public void HowPrint() //How do I print75
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        i = 15;
        BlogOutput();
        SettingsScript.Blog[0] = "Step one  : When object is ready, select print on printer";
        SettingsScript.Blog[1] = "Step two  : Wait for printing process";
        SettingsScript.Blog[2] = "Step three: Wash object in washer";
        SettingsScript.Blog[3] = "Step four : Break Supports";
        SettingsScript.Blog[4] = "Step five : Cure in curing machine";

        i = 5;
        SettingsScript.TextChange();
    }
    public void NozzleClean() //How do I clean nozzle76
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "Remove nozzle from bottom right of resin container and scrape off dry resin";
        i += 1;
        SettingsScript.TextChange();
    }
    public void ResinBad() //When do I replace the resin77
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "Remove tray and check if resin is cloudy after swabbing";
        i += 1;
        SettingsScript.TextChange();
    }
    public void HowReplaceResin() //How to replace resin78
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "Pull the old container up and out from the back of the printer and replace";
        i += 1;
        SettingsScript.TextChange();
    }
    public void CanGoWrong() //What can go wrong during a print79
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();

        BlogOutput();
        SettingsScript.Blog[i] = "Possible printing errors: Nozzle jam | Resin could be bad | Resin runs out";
        i += 1;
        SettingsScript.TextChange();
    }
    public void ClearLog() //Clear80
    {
        TextChanger SettingsScript;
        SettingsScript = settings.GetComponent<TextChanger>();
        i = 15;
        BlogOutput();
        SettingsScript.TextChange();
    }
}
