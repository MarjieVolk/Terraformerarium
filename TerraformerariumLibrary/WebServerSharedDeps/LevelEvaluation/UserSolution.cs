using System.Collections.Generic;

public sealed class UserSolution
{
    public ICollection<Ecosystem> Ecosystems { get; }

    public UserSolution(ICollection<Ecosystem> ecosystems)
    {
        this.Ecosystems = ecosystems;
    }
}