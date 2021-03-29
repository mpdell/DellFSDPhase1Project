namespace ProjectPhase1
{
    public class Teacher
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        

        public Teacher()
        {

        }
        
        public Teacher(int id, string firstName, string lastName)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"ID:{ID} FirstName:{FirstName} LastName:{LastName}";
        }
    }
}
