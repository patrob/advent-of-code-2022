namespace Day_02;

public class PlayOption : IComparable
{
    public PlayOptionEnum Option { get; }

    public PlayOption(PlayOptionEnum option)
    {
        Option = option;
    }
    
    public int CompareTo(object? obj)
    {
        if (obj is PlayOption playOption)
        {
            if (playOption.Option == Option) return 0;

            var playOptionValue = (int)playOption.Option;
            var myOptionValue = (int)Option;
            var result = playOptionValue - myOptionValue > 0 ? -1 : 1;
            
            return playOption.Option switch
            {
                PlayOptionEnum.Rock => Option == PlayOptionEnum.Scissors ? -result : result,
                PlayOptionEnum.Paper => result,
                PlayOptionEnum.Scissors => Option == PlayOptionEnum.Rock ? -result : result,
                _ => throw new NotSupportedException()
            };
        }

        throw new NotSupportedException();
    }
}