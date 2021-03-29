using ProjectPhase1.Builders;
using ProjectPhase1.Repositories;
using ProjectPhase1.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPhase1.Templates
{
    public class ConcreteTeacherManagementApp : AbstractTeacherAppTemplate
    {
        protected override void loadTeachers()
        {
            var teachersRepository = new PipeDelimitedFileTeachersRepository("teachers.txt");
            var teachersAsList = teachersRepository.Load();
            _teachers = teachersAsList.ToDictionary(t => t.ID);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Succesfully Loaded {_teachers.Count} teachers");
            Console.ResetColor();
        }

        protected override void saveTeachers( IEnumerable<Teacher> teachers )
        {           
            var teachersRepository = new PipeDelimitedFileTeachersRepository("teachers.txt");
            teachersRepository.Save(teachers);
        }

        protected override int getOption()
        {
            try
            {
                var option = Console.ReadLine();
                return int.Parse(option);
            }
            catch(Exception Ex)
            {
                Console.WriteLine("Please Enter Valid Option from above list");
                return 0;                
            }
        }

        protected override void addTeacher()
        {
            var teacherBuilder = new ConcreteTeacherBuilder();
            var teacher = teacherBuilder.Build();
            _teachers[teacher.ID] = teacher;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"New teacher with {teacher.ID} has been added successfully");
            Console.ResetColor();
        }

        protected override void deleteTeacher()
        {
            Console.WriteLine("Enter ID of teacher to delete");
            var id = int.Parse(Console.ReadLine());
           
            if (!_teachers. ContainsKey(id))
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Teacher with id {id} not found");
                Console.ResetColor();
            }
            else
            {                
                _teachers.Remove(id);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Removed teacher with ID : {id}");
                Console.ResetColor();
            }
        }

        protected override void findTeacher()
        {
            Console.WriteLine("Enter ID of teacher to find");
            var id = int.Parse(Console.ReadLine());

            if( !_teachers.ContainsKey(id) )
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Teacher with id {id} not found");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Teacher with id {id} is found and teacher details are " +
                    $"FirstName : {_teachers[id].FirstName} , LastName :{_teachers[id].LastName}");
                Console.ResetColor();
            }
        }

        protected override void listTeachers( IEnumerable<Teacher> teachers )
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            foreach( var teacher in teachers )
            {
                Console.WriteLine(teacher);
            }
            Console.ResetColor();
        }

        protected override void sortTeachers()
        {
            Console.WriteLine("You chose to sort teachers");
            Console.WriteLine("--------------------------");
            
            Console.WriteLine("List Before sorting");
           
            listTeachers(_teachers.Values);         

            Console.WriteLine("How would you like to sort them?");
            Console.WriteLine("1) ID");
            Console.WriteLine("2) Last Name");
            Console.WriteLine("3) First Name");

            var option = int.Parse(Console.ReadLine());
            ISortTeachersStrategy sortStrategy = null;
            switch (option)
            {
                case 1: sortStrategy = new SortTeachersByIDStrategy(); break;
                case 2: sortStrategy = new SortTeachersByLastNameStrategy(); break;
                case 3: sortStrategy = new SortTeachersByFirstNameStrategy(); break;
            }

            var sorted = sortStrategy.Sort(_teachers.Values);
            Console.WriteLine("--------------------------");
            Console.WriteLine("List After Sorting");
            listTeachers(sorted);          
        }

        protected override void updateTeacher()
        {
            Console.WriteLine("Enter ID of teacher to update");
            var id = int.Parse(Console.ReadLine());
            if (!_teachers.ContainsKey(id))
            {
                Console.WriteLine($"Did not find teacher with id: {id}");
                return;
            }

            var teacher = _teachers[id];
            Console.WriteLine("You selected...");
            Console.WriteLine(teacher);
          
            Console.WriteLine("Enter new FirstName");
            var updatedTeacherFirstName = Console.ReadLine();
            teacher.FirstName = updatedTeacherFirstName;        

            Console.WriteLine("Enter new LastName");
            var updatedTeacherLastName = Console.ReadLine();
            teacher.LastName = updatedTeacherLastName;      
        }
    }
}
