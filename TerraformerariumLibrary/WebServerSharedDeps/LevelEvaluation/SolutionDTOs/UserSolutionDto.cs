using System;
using System.Collections.Generic;
using System.Xml.Serialization;

public class UserSolutionDto
{
    [XmlAttribute]
    public string LevelName { get; set; }
    public List<EcosystemDto> Ecosystems { get; set; }
}

public class EcosystemDto
{
    public List<EOrganism> Organisms { get; set; }
}
