using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

public sealed class UserSolution
{
    public Level Level;
    private IList<Ecosystem> Capsules { get; }

    public UserSolution(string level, IList<Ecosystem> capsules)
    {
        this.Level = LevelLibrary.GetLevelFor(level);
        this.Capsules = capsules;
    }

    public static UserSolution FromXml(string xml)
    {
        UserSolutionDto dto; 

        XmlSerializer serializer = new XmlSerializer(typeof(UserSolutionDto));
        using (StringReader writer = new StringReader(xml))
        {
            dto = (UserSolutionDto)serializer.Deserialize(writer);
        }

        var ecosystems = dto.Ecosystems.Select(
                s => new Ecosystem(s.Organisms.Select(OrganismLibrary.GetOrganismFor).ToList())
            ).ToList();

        return new UserSolution(dto.LevelName, ecosystems);
    }
    
    public string ToXml()
    {
        var dto = new UserSolutionDto
        {
            LevelName = Level == null ? "<unknown level>" : Level.Name,
            Ecosystems = this.Capsules.Select(e => new EcosystemDto
            {
                Organisms = e.ContainedOrganisms.Select(o => o.Type).ToList()
            }).ToList()
        };  

        XmlSerializer serializer = new XmlSerializer(typeof(UserSolutionDto));
        using (StringWriter writer = new StringWriter())
        {
            serializer.Serialize(writer, dto);
            return writer.ToString();
        }
    }

    public void AddCapsule(Ecosystem capsule)
    {
        Capsules.Add(capsule);
    }

    public Ecosystem GetFinalEcosystem()
    {
        Ecosystem planet = new Ecosystem(Level.InitialPlanet);
        foreach (Ecosystem capsule in Capsules)
        {
            // merge capsule ecosystem into planet
            planet.AddOrganisms(capsule.ContainedOrganisms);

            // simulate to convergence
            Multiset<Organism> unsupportedOrganisms = planet.GetUnsupportedOrganisms();
            while (unsupportedOrganisms.Count > 0)
            {
                planet.RemoveOrganisms(unsupportedOrganisms);
                unsupportedOrganisms = planet.GetUnsupportedOrganisms();
            }
        }

        return planet;
    }

    public bool IsLegal()
    {
        return Capsules.SelectMany(capsule => capsule.ContainedOrganisms).All(org => Level.availableOrganisms.Contains(org));
    }

    public bool MeetsGoalRequirements()
    {
        return LevelSolutionEvaluator.Create(Level.LevelGoals).EvaluateResult(this).IsValid;
    }

    public int GetScore()
    {
        return Capsules.Count;
    }
}