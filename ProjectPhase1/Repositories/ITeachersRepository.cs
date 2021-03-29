using System.Collections.Generic;

namespace ProjectPhase1.Repositories
{
    public interface ITeachersRepository
    {
        void Save(IEnumerable<Teacher> teachers);
        IEnumerable<Teacher> Load();
    }
}
