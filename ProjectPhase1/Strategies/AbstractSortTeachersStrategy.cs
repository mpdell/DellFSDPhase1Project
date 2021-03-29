using System.Collections.Generic;

namespace ProjectPhase1.Strategies
{
    public abstract class AbstractSortTeachersStrategy : ISortTeachersStrategy
    {
        public abstract List<Teacher> Sort(IEnumerable<Teacher> teachers);
    }
}
