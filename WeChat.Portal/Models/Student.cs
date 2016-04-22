namespace ConsoleApplication1
{
    public class Student
    {
        public int Id { get; set; }
        public int Age { get; set; }

        public string Name { get; set; }
        public int GradeId { get; set; }

        public int[] Ints { get; set; } = {1, 2, 3};
    }
}