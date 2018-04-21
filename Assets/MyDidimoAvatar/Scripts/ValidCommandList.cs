// Command Examples
// =====================================
// Feel Maria Happy 1.0
// Feel Maria Sad 0.5
// Express Maria Fear 1.0
// Express Joao Sadness 0.5
// Talk Maria Start
// Talk Maria Stop
// Talk Maria Frequency 1.0
// Talk Joao Speed 1.0
// Nod Maria Start
// Nod Maria Stop
// Nod Maria Frequency 0.5
// Nod Maria Speed 0.5
// Gazeat Maria Joao
// Gazeat Maria Speed 0.2
// Gazeat Maria Frequency 0.5
// Gazeback Maria User
// Gazeback Joao Speed 0.2
// Gazeback Joao Frequency 0.7
// MoveEyes Maria Left
// MoveEyes Maria Speed 0.2
// MoveEyes Maria Frequency 0.5
    
public enum ActionGroup
{
    FEEL = 1,
    EXPRESS = 2,
    TALK = 3,
    NOD = 4,
    GAZEAT = 5,
    GAZEBACK = 6,
    MOVEEYES = 7
}

public enum ActionType3
{
    START = 1,
    STOP = 2,
    SPEED = 3,
    FREQUENCY = 4
}

public enum ActionType4
{
    MARIA = 1,
    JOAO = 2,
    USER = 3,
    SPEED = 4,
    FREQUENCY = 5
}