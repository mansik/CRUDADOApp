namespace CRUDADO.Models
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Reg { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }

        public Student(string id, string name, string reg, string @class, string section)
        {
            Id = id;
            Name = name;
            Reg = reg;
            Class = @class;
            Section = section;
        }
    }
}
