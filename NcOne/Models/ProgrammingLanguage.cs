﻿namespace NcOne.Models
{
    public class ProgrammingLanguage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
