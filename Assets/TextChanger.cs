using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;

public class TextChanger : MonoBehaviour
{
    public Text changingText;
    public string[] Blog = new string[15] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
    //Blog is actually supposed to be log but the variable Log stopped working 
    public string RT = "Full Raft";//Raft type
    public string RL = "True"; //Raft Label (True/False)
    public double D = 1.00;//Density
    public float TPS = 0.60f; //Touchpoint Size
    public string IS = "True"; //Internal Supports
    public double SM = 1.00; //Slope Multiplier
    public double HAR = 5.00;//Height above raft
    public double RTH = 2.00; //Raft thickness
    public double Scale = 1.00; //Scale
    public int i = 0;
    public int LT = 50; //Layer Thickness
    public double XScale = 1.00; //X Scale
    public double YScale = 1.00; //Y Scale
    public double ZScale = 1.00; //Z Scale

    //strings for writing to output file
    public string DensityS = "0";
    public string TouchpointSizeS = "0";
    public string SlopeModifierS = "0";
    public string HeightAboveRaftS = "0";
    public string RaftThicknessS = "0";
    public string ScaleS = "1";
    public string XScaleS = "0";
    public string YScaleS = "0";
    public string ZScaleS = "0";
    public string NewRaftTypeS = "2";

    public string OneClickS = "False";
    public string AutoOrientS = "False";
    public string AutoGenerateS = "False";
    public string GenerateLayoutS = "False";
    public string UndoS = "False";
    public string StartPrintS = "False";
    //So to change to new format: change toString strings then just set each one
    //command by command in settings.changer to follow new format
    public void TextChange()
    {
        changingText.text = "Current Settings: \n-Supports \n\tRaft Type (Selected: " + RT + ")\t(Options: " +
        "Full Raft / Mini Rafts / None)\n\tRaft Label (Selected: " + RL + ")\n\tDensity (Selected: " +
        D + ")\n\tTouchpoint Size (Selected: " + TPS + "mm)\n\tInternal Supports (Selected: " + IS + ")\n\t" +
        "Slope Multiplier (Selected: " + SM + ")\n\tHeight Above Raft (Selected: " + HAR + "mm)\n\t" +
        "Raft Thickness (Selected: " + RTH + "mm)\n-Layer Thickness (Selected: " + LT + "microns)\n-Scale" +
        " (Selected: " + Scale + ")\n\tXScale (Selected: " + XScale + ")\n\tYScale (Selected: " +
        YScale + ")\n\tZScale (Selected: " + ZScale + ")\n\nLog: \n" +
        Blog[0] + "\n" + Blog[1] + "\n" + Blog[2] + "\n" + Blog[3] + "\n" + Blog[4] + "\n" + Blog[5] + "\n" +
        Blog[6] + "\n" + Blog[7] + "\n" + Blog[8] + "\n" + Blog[9] + "\n" + Blog[10] + "\n" + Blog[11] + "\n" +
        Blog[12] + "\n" + Blog[13] + "\n" + Blog[14];
        UDPNetwork();
        //Legacy code for sending the full values of the variables instead of changes in values
        /*LayerThicknessString = LT.ToString();
        DensityString = D.ToString();
        TouchpointSizeString = TPS.ToString();
        SlopeModifierString = SM.ToString();
        HeightaboveRaftString = HAR.ToString();
        RaftThicknessString = RTH.ToString();
        ScaleString = Scale.ToString();
        XScaleString = XScale.ToString();
        YScaleString = YScale.ToString();
        ZScaleString = ZScale.ToString();
        */

        //System.IO.File.WriteAllLines(@"A:\Unity\Voice Control\NRN HoloLens Dev 101\TestFolder\WriteLines.csv", lines);
    }

    public void UDPNetwork()
    {
       /* string Packet = "Task,"+OneClickS+","+AutoOrientS+","+AutoGenerateS+","+GenerateLayoutS+","+NewRaftTypeS+","+RL+","+
            IS+","+DensityS +","+TouchpointSizeS+","+SlopeModifierS+","+HeightAboveRaftS+","+
            RaftThicknessS+","+UndoS+","+StartPrintS+","+XScaleS+","+YScaleS+","+ZScaleS+","
            +ScaleS;*/

        string Packet = OneClickS + "," + AutoOrientS + "," + AutoGenerateS + "," + GenerateLayoutS + "," + NewRaftTypeS + "," + RL + "," +
            IS + "," + DensityS + "," + TouchpointSizeS + "," + SlopeModifierS + "," + HeightAboveRaftS + "," +
            RaftThicknessS + "," + UndoS + "," + StartPrintS + "," + XScaleS + "," + YScaleS + "," + ZScaleS + ","
            + ScaleS;


        byte[] packetData = System.Text.ASCIIEncoding.ASCII.GetBytes(Packet);

        //port and IP Data for socket client
        string IP = "192.168.1.12"; //change the same IP address for WEB lab Computer, WIFI IP address, Omar's laptop
        int port = 80;
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        client.SendTimeout = 1;

        client.SendTo(packetData, ep);
    }
}
/*Desired format for object preparation subsystem:
 * oneclick
 * autoorient
 * autogenerate
 * generate layout
 * new raft type
 * raft label
 * internal supports
 * density
 * touch point size
 * slope multiplier
 * height above raft
 * raft thickness
 * undo 
 * start print
 * x
 * y
 * z
 * input size
 * ----------------
 * 1 = up one, 2 = up two, 3 = down one, 4 = down two, booleans are 'True' or 'False'*/
