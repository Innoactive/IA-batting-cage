namespace IAKorolev
{
    public interface IBalance
    {
        int MatchDuration { get; }

        float BallDelay { get; }

        float BallMissDelayModifier { get; }

        float BallInitialVelocity { get; }

        Difficulty CurrentDifficulty { get; set; }
    }
}
