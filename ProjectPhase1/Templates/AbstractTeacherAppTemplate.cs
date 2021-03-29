﻿using System;
using System.Collections.Generic;

namespace ProjectPhase1.Templates
{
    public abstract class AbstractTeacherAppTemplate
    {
        protected Dictionary<int, Teacher> _teachers = new Dictionary<int, Teacher>();

        public void Run()
        {
            Console.WriteLine("Please Select Option 1 to Load Teachers First to proceed:");
            var exit = false;
            while (!exit)
            {
                displayMenu();

                var option = getOption();

                switch (option)
                {                    
                    case 1: loadTeachers(); break;
                    case 2: saveTeachers(_teachers.Values); break;
                    case 3: addTeacher(); break;
                    case 4: deleteTeacher(); break;
                    case 5: updateTeacher(); break;
                    case 6: findTeacher(); break;
                    case 7: listTeachers(_teachers.Values); break;
                    case 8: sortTeachers(); break;
                    case 9: exit = true; break;
                    //default: displayMenu();break;
                }
            }

            Console.WriteLine("Bye!");
        }

        private void displayMenu()
        {
            Console.WriteLine("\nWhat would you like to do? ");
            Console.WriteLine("1) Load teachers");
            Console.WriteLine("2) Save teachers");
            Console.WriteLine("3) Add a teacher");
            Console.WriteLine("4) Delete a teacher");
            Console.WriteLine("5) Update a teacher");
            Console.WriteLine("6) Find teacher by ID");
            Console.WriteLine("7) List teachers");
            Console.WriteLine("8) Sort teachers");
            Console.WriteLine("9) Exit");
        }

        protected abstract int getOption();
        protected abstract void loadTeachers(); 
        protected abstract void saveTeachers(IEnumerable<Teacher> teachers); 
        protected abstract void addTeacher(); 
        protected abstract void deleteTeacher();
        protected abstract void updateTeacher();
        protected abstract void findTeacher();
        protected abstract void listTeachers(IEnumerable<Teacher> teachers);
        protected abstract void sortTeachers();
   }
}
