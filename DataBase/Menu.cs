using System;


namespace DataBase
{
    class MenuService
    {
        public void Menu()
        {
            bool Persist = false;
            var Querry = new QuerryServices();
            var changeDb = new AddChangeDBRecord();
            do
            {              
                Console.WriteLine("Input 0 To Create Department and Assign new students and lectures");
                Console.WriteLine("Input 1 To Create Student");
                Console.WriteLine("Input 2 To Add Students and Lectures To Department");
                Console.WriteLine("Input 3 To Change Students Department");
                Console.WriteLine("Input 4 To Create Lecture and Assign Department");
                Console.WriteLine("Input 5 To Show Lectures Of Department");
                Console.WriteLine("Input 6 To Show Students Of Department");
                Console.WriteLine("Input 7 To Show Lectures Of Student");
                Console.WriteLine("Input 8 To Assign Lectures To Student");             
                Console.WriteLine("Input 9 To Show All Departments");
                Console.WriteLine("Input 10 To Show All Lectures");
                Console.WriteLine("Input 11 To Show All Students");
                Console.WriteLine("Input 12 To Exit Program");
                int Selection;
                try
                {
                    Selection = Console.ReadLine().IntValidation();                                              
                    switch (Selection)
                    {
                        case 0:
                            changeDb.AddDepartment();
                            Console.Clear();
                            break;
                        case 1:
                            changeDb.CreateStudent();
                            Console.Clear();
                            break;
                        case 2:
                            changeDb.CreateAndAddStudentsAndLecturesToExistingDepartment();
                            Console.Clear();
                            break;
                        case 3:
                            changeDb.ChangeStudentDepartment();
                            Console.Clear();
                            break;
                        case 4:
                            changeDb.CreateLectureAndAssignDepartment();
                            Console.Clear();
                            break;
                        case 5:
                            Querry.ShowDepartmentLectures();
                            Console.Clear();
                            break;
                        case 6:
                            Querry.ShowDepartmentStudents();
                            Console.Clear();
                            break;
                        case 7:
                            Querry.ShowStudentLectures();
                            Console.Clear();
                            break;
                        case 8:
                            changeDb.AssignLecturesToStudent();
                            Console.Clear();
                            break;                      
                        case 9:                           
                            Querry.ShowDepartments();
                            break;
                        case 10:                           
                            Querry.ShowLectures();
                            break;
                        case 11:                          
                            Querry.ShowStudents();
                            break;
                        case 12:
                            Persist = true;
                            break;
                        default:
                            Console.WriteLine("Selection out of range");
                            continue;                           
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input, try again");
                    continue;
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("No Corresponding Guid, returning to menu");
                    continue;
                }
                
            } while (!Persist);
           
        }
    }
}
