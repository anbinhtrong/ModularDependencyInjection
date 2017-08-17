using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class Character
    {
        public Character(string name)
        {
            Name = name;
        }

        private Character()
        {
        }
        
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = String.Empty;
    }
}
