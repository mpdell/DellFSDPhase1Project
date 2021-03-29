namespace ProjectPhase1.Builders
{
    public abstract class AbstractTeacherBuilder
    {       
        protected abstract void BuildID(Teacher teacher);
        protected abstract void BuildFirstName(Teacher teacher);
        protected abstract void BuildLastName(Teacher teacher);
       
        public Teacher Build()
        {
            var teacher = new Teacher();
            BuildID(teacher);
            BuildFirstName(teacher);
            BuildLastName(teacher);
            return teacher;
        }
    }
}