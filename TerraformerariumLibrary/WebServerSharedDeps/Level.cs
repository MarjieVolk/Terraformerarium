using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Level
{
    public Ecosystem InitialPlanet { get; set; }
    // TODO make this a white box so it can be displayed to the player easily
    public Predicate<Ecosystem> GoalEvaluator { get; set; }
    public List<IOrganism> availableOrganisms { get; set; }
}
