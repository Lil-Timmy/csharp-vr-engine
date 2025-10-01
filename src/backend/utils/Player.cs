


namespace Engine;


public static class Player
{
    private static pose head;
    private static pose neck;
    private static pose chest;
    private static pose torso;
    
    private static pose rightShoulder;
    private static pose rightElbow;
    private static pose rightWrist;
    private static pose rightPalm;
    
    private static pose leftShoulder;
    private static pose leftElbow;
    private static pose leftWrist;
    private static pose leftPalm;
    
    private static DebugLine[] lines;
    private static DebugLine[] forwardLines;
    
    
    private static void OnBegin()
    {
        lines        = new DebugLine[11];
        forwardLines = new DebugLine[3 ];
        
        for (int _i = 0; _i < lines.Length; _i++)
        {
            lines       [_i] = new DebugLine(vec3.ZERO, vec3.ZERO, vec3.ONE);
        }
        
        for (int _i = 0; _i < forwardLines.Length; _i++)
        {
            forwardLines[_i] = new DebugLine(vec3.ZERO, vec3.ZERO, vec3.ONE);
        }
    }
    
    
    private static void OnUpdate()
    {
        rightPalm.position = Input.rightControllerPosition;
        rightPalm.rotation = Input.rightControllerRotation;
        
        leftPalm. position = Input.leftControllerPosition;
        leftPalm. rotation = Input.leftControllerRotation;
        
        head.     position = Input.headsetPosition;
        head.     rotation = Input.headsetRotation;
        
        
        neck.position          = head.position + head.rotation * vec3.DOWN * 0.12f;
        neck.rotation          = new quat((vec3)head .rotation * new vec3(0.5f, 1f, 0.5f));
        
        chest.position         = neck.position + vec3.DOWN * 0.1f + neck.rotation * vec3.DOWN * 0.05f;
        chest.rotation         = new quat((vec3)head .rotation * new vec3(0.0f, 1f, 0.0f));
        
        torso.position         = chest.position + chest.rotation * vec3.DOWN * 0.25f;
        torso.rotation         = new quat((vec3)chest.rotation * new vec3(0.5f, 1f, 0.5f));
        
        rightShoulder.position = chest.position + chest.rotation * vec3.RIGHT * 0.18f + vec3.UP * 0.10f;
        rightShoulder.rotation = chest.rotation; // CHANGE
        
        leftShoulder .position = chest.position + chest.rotation * vec3.LEFT  * 0.18f + vec3.UP * 0.10f;
        leftShoulder .rotation = chest.rotation; // CHANGE
        
        rightWrist.position    = rightPalm.position + rightPalm.rotation * vec3.UP * 0.04f;
        rightWrist.rotation    = rightPalm.rotation; // CHANGE.
        
        leftWrist .position    = leftPalm .position + leftPalm .rotation * vec3.UP * 0.04f;
        leftWrist .rotation    = leftPalm .rotation; // CHANGE.
        
        rightElbow.position    = rightShoulder.position; // NEEDS IK.
        rightElbow.rotation    = rightShoulder.rotation; // NEEDS IK.
        
        leftElbow.position     = leftShoulder .position; // NEEDS IK.
        leftElbow.rotation     = leftShoulder .rotation; // NEEDS IK.
        
        
        forwardLines[0].start = head     .position; forwardLines[0].end = head     .position + head     .rotation * vec3.FOR ; forwardLines[0].color = head     .rotation * vec3.FOR  * 0.25f + 0.75f;
        forwardLines[1].start = rightPalm.position; forwardLines[1].end = rightPalm.position + rightPalm.rotation * vec3.DOWN; forwardLines[1].color = rightPalm.rotation * vec3.DOWN * 0.25f + 0.75f;
        forwardLines[2].start = leftPalm .position; forwardLines[2].end = leftPalm .position + leftPalm .rotation * vec3.DOWN; forwardLines[2].color = leftPalm .rotation * vec3.DOWN * 0.25f + 0.75f;
        
        
        lines[0 ].start = head         .position; lines[0 ].end = neck         .position;
        lines[1 ].start = neck         .position; lines[1 ].end = chest        .position;
        lines[2 ].start = chest        .position; lines[2 ].end = torso        .position;
        
        lines[3 ].start = chest        .position; lines[3 ].end = rightShoulder.position;
        lines[4 ].start = rightShoulder.position; lines[4 ].end = rightElbow   .position;
        lines[5 ].start = rightElbow   .position; lines[5 ].end = rightWrist   .position;
        lines[6 ].start = rightWrist   .position; lines[6 ].end = rightPalm    .position;
        
        lines[7 ].start = chest        .position; lines[7 ].end = leftShoulder.position;
        lines[8 ].start = leftShoulder .position; lines[8 ].end = leftElbow   .position;
        lines[9 ].start = leftElbow    .position; lines[9 ].end = leftWrist   .position;
        lines[10].start = leftWrist    .position; lines[10].end = leftPalm    .position;
    }
}