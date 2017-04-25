using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Level
{
    public Ecosystem InitialPlanet { get; set; }
    public IEnumerable<LevelGoal> LevelGoals { get; set; }
    public List<Organism> availableOrganisms { get; set; }
    public string Name { get; set; }
    public int MaxOrganismsPerCapsule { get; set; }
}
