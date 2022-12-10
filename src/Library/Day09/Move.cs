namespace Library.Day09;

public enum Direction
{
    Up = 'U',
    Down = 'D',
    Left = 'L',
    Right = 'R'
}

public record Move(Direction Direction, int Spaces);