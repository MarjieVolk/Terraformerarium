using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Terraformerarium.Data
{
    public class Level
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string LevelKey { get; set; }

        public IList<Solution> Solutions { get; set; }
    }
}