using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskPad
{
    class Task
    {
       public  string taskname;
        public DateTime completiondate;
        public string priority;
        public int id;
        public string message;
            public string status;
        public Task(string taskname, DateTime completiondate,string message, int priority,int id)
        {
            this.taskname = taskname;
            this.completiondate = completiondate;
            this.message = message;
            this.id = id;
            this.status = "Pending";
            switch(priority)
            {
                case 0:this.priority = "very low";break;
                case 1:this.priority = "low";break;
                case 2:this.priority = "medium";break;
                case 3:this.priority = "high";break;
            }

        }
        
    }
    class Program
    {
        //private static int getpriority()
        //{
        //    int p = Convert.ToInt32(Console.ReadLine());
        //    return p;
        //}
        private static int bydate(Task a, Task b)
        {
            if (a.completiondate < b.completiondate)
                return -1;
            if (a.completiondate == b.completiondate)
                return 0;
            if (a.completiondate > b.completiondate)
                return 1;

            return -1;

        }
        private static int byid(Task a,Task b)
        {
            if (a.id < b.id)
                return -1;
            if (a.id == b.id)
                return 0;
            if (a.id > b.id)
                return 1;

            return -1;
        }
        private static int bypriority(Task a, Task b)
        {
            if (a.priority == "very low" && b.priority == "very low")
                return 0;
            else if (a.priority == "low" && b.priority == "low")
                return 0;
            else if (a.priority == "medium" && b.priority == "medium")
                return 0;
            else if (a.priority == "high" && b.priority == "high")
                return 0;
            else if (a.priority == "very low" && b.priority == "low")
                return 1;
            else if (a.priority == "very low" && b.priority == "medium")
                return 1;
            else if (a.priority == "very low" && b.priority == "high")
                return 1;
            else if (a.priority == "low" && b.priority == "medium")
                return 1;
            else if (a.priority == "low" && b.priority == "high")
                return 1;
            else if (a.priority == "medium" && b.priority == "high")
                return 1;

            return 0;
        }
        /*create new, view by id, view all, edit, delete a message list with exit option.*/
        static void Main(string[] args)
        {
            List<Task> list = new List<Task>();
           
            Console.ForegroundColor = ConsoleColor.Magenta;
            
            Console.WriteLine("TO DO LIST");
           
            int ch;
            while(true )
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(
                    "________________________________________\n"+
                    "|                                      |\n" +
                    "|  1. Create a new task                |\n" +
                    "|  2. View tasks by id                 |\n" +
                    "|  3. View all tasks                   |\n" +
                    "|  4. Edit a task                      |\n" +
                    "|  5. Delete a task                    |\n" +
                    "|  6. Exit                             |\n" +
                    "|   Enter your choice                  |\n" +
                    "________________________________________\n");
                try
                {
                    ch = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Please enter value between 1 to 6");
                    continue;
                }
                if (ch == 6)
                    break;
                switch (ch)
                {
                    case 1:
                        Console.WriteLine( "Enter a task name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter completion date");
                        DateTime completiondate=DateTime.Now;
                        while (true)
                        {
                            try
                            {
                                completiondate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                                if (completiondate <= DateTime.Now.AddDays(-1))
                                {
                                    Console.WriteLine("don't enter past date");
                                    continue;
                                }
                                else
                                    break;
                            }
                            catch (System.FormatException )
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Invalid date");
                                continue;
                            }
                        }
                        int priority = 4;
                        while(priority<0 || priority>3)
                        {
                            Console.WriteLine("Enter priority of task\n0- very low \n1- low\n2- medium\n3- high\n enter between 0 to 3");
                            try
                            {
                                priority = Convert.ToInt32(Console.ReadLine());
                             }
                            catch(System.FormatException )
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Please enter correct format ");
                                continue;
                            }
                            if (priority > 3 || priority < 0)
                            {
                                Console.WriteLine("Sorry you entered invalid priority number...Try again");
                            }
                            else
                                break;
                        }
                        Console.WriteLine("Enter a message");
                        string msg = Console.ReadLine();
                        
                       
                        Console.WriteLine("Do you want to add task into list... type y or n");
                        string response = Console.ReadLine();
                        if(response=="y")
                        {
                            //add into list

                            list.Add(new Task(name, completiondate,msg, priority, list.Count+1));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Task added successfully.");
                            Console.WriteLine("....................................................");
                        }
                        else 
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("No worries. You can create task later.");
                            Console.WriteLine("....................................................");
                        }

                        break;
                    case 2:
                        int id;
                        while (true)
                        {
                            Console.WriteLine("enter id to view task");
                            try
                            {
                                 id = Convert.ToInt32(Console.ReadLine());
                            }
                            catch(System.FormatException )
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("please enter valid id to view task");
                                continue;
                            }
                            break;
                        }
                        Task curtask=null;
                       foreach (var task in list)
                        {
                            if(task.id==id)
                            {
                                if (task.completiondate < DateTime.Now)
                                    task.status = "Incomplete";
                                curtask = task;
                             }
                        }
                        if (curtask != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Your task :\n");
                            Console.WriteLine(".....................................................................................................");
                            Console.WriteLine("Task id      Task                completion date             status");
                           
                            Console.WriteLine(id + "             " + curtask.taskname + "            " + curtask.completiondate + "                    " + curtask.status);

                            Console.WriteLine(".....................................................................................................");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Task doesn't exist for given id");
                        }
                        break;
                    case 3:
                        if (list.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No tasks");
                        }
                        else
                        {
                            int vid;
                            while (true)
                            {
                                Console.WriteLine("enter choice to view tasks\n" +
                                    "1. priority\n" +
                                    "2.date\n" +
                                    "3.id");
                                try
                                {
                                     vid = Convert.ToInt32(Console.ReadLine());
                                    if(vid<1 || vid>3)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Please enter choice between 1 to 3");
                                        continue;
                                    }
                                }
                                catch(System.FormatException )
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Please enter correct format");
                                    continue;
                                }
                                switch (vid)
                                {
                                    case 1:
                                        list.Sort(bypriority);
                                        break;
                                    case 2:
                                        list.Sort(bydate);
                                        break;
                                    case 3:
                                        list.Sort(byid);
                                        break;
                                }
                                break;
                            }
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("All tasks :\n");
                            Console.WriteLine(".....................................................................................................");
                            foreach (var task in list)
                            {
                                if(task.status=="incomplete")
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                else if(task.status=="complete")
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                else
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine(task.id + "     " + task.taskname + "     " + task.completiondate + "    " + task.status + "    " + task.priority);

                            }
                            Console.WriteLine(".....................................................................................................");
                        }
                        break;
                    case 4:
                        foreach (var task in list)
                        {

                            Console.WriteLine(task.id+" "+ task.taskname + " " + task.completiondate + " " + task.status);

                        }
                        while (true)
                        {
                            Console.WriteLine("enter task id to edit");
                            try
                            {
                                id = Convert.ToInt32(Console.ReadLine());
                                
                            }
                            catch(System.FormatException )
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Please enter correct format");
                                continue;
                            }
                            break;
                        }
                        Task tofindtask = list.Find(x => x.id == id);
                        if (tofindtask == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Task doesn't exist");
                        }
                        else
                        {

                            int eid;
                            while (true)
                            {
                                Console.WriteLine("1. to edit task\n2. To edit completion date\n3. To edit status\nenter your choice");
                                try
                                {
                                    eid = Convert.ToInt32(Console.ReadLine());
                                    if (eid < 1 || eid > 3)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Please enter choice between 1 to 3");
                                        continue;
                                    }
                                }
                                catch (System.FormatException)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Please enter correct format");
                                    continue;
                                }
                                break;
                            }
                            switch (eid)
                            {
                                case 1:
                                    string ename = Console.ReadLine();
                                    tofindtask.taskname = ename;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Updation successfully");
                                    Console.WriteLine("....................................................");
                                    break;
                                case 2:
                                    while (true)
                                    {
                                        try
                                        {
                                            DateTime ecompletiondate = DateTime.Parse(Console.ReadLine());

                                            tofindtask.completiondate = ecompletiondate;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Updation successfully");
                                            Console.WriteLine("....................................................");
                                        }
                                        catch (System.FormatException)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.WriteLine("please enter date in correct format like - 18/08/2021");
                                            continue;
                                        }
                                        break;
                                    }
                                    break;
                                case 3:
                                    while (true)
                                    {
                                        string estatus = Console.ReadLine();
                                        estatus.ToLower();
                                        if (estatus == "complete" || estatus == "pending" || estatus == "incomplete")
                                        {
                                            tofindtask.status = estatus;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Updation successfully");
                                            Console.WriteLine("....................................................");
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.WriteLine("Enter status as complete or pending or incomplete");
                                            continue;
                                        }
                                        break;
                                    }
                                    break;
                            }
                        }
                        break;
                    case 5:
                        while (true)
                        {
                            int did;
                            Console.WriteLine("enter task id to delete");
                            try
                            {
                              did = Convert.ToInt32(Console.ReadLine());
                            }
                            catch(System.FormatException )
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Please enter correct format for id to delete task");
                                continue;
                            }
                            Task toremove = list.Find(x => x.id == did);
                            if (toremove == null)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Task doesn't exist");
                            }
                            else
                            {
                                list.Remove(toremove);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Task removed successfully.");
                                Console.WriteLine("....................................................");
                            }
                            break;
                        }
                        break;
                   
                }
            }
        }
    }
}
