using System;
using System.Collections.Generic;
using System.Text;
using BEE;
using System.Linq;
namespace DAL
{
   public class dltacher
    {
        public void create(teacher teacher)
        {
            try
            {

                var db1 = new db();
                var q = db1.Teachers.Where(i => i.id == teacher.id);
                if (q.Count() == 0)
                {
                    db1.Teachers.Add(teacher);
                    db1.SaveChanges();
                }
            }
            catch (Exception)
            {

                Console.WriteLine("eror");
            }
        }
        public List<teacher> readall_teacher()
        {
            try
            {
                var db1 = new db();
                return db1.Teachers.ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<teacher> serchbyname(string nameteachers)
        {
            var db1 = new db();
            var q = db1.Teachers.Where(i => i.name.Contains(nameteachers));
            if (q.Count() == 0)
            {

                return null;
            }
            return q.ToList();
        }
        public teacher serchbynid(int id)
        {
            var db1 = new db();
            var q = db1.Teachers.Where(i => i.id==id);
            if (q.Count() == 0)
            {

                return null;
            }
            return q.Single();
        }
        public void delet(int id)
        {
            var db1 = new db();
            var q = db1.Teachers.Where(i => i.id == id);
            if (q.Count() != 0)
            {
                db1.Remove(q.Single());
                db1.SaveChanges();

            }
        }
        public void edit(int id, teacher teacher)
        {
            var db1 = new db();
            var q = db1.Teachers.Where(i => i.id == id);
            if (q.Count() != 0)
            {
                var t1 = new teacher();
                t1 = q.Single();
                t1.name = teacher.name;
                t1.family = teacher.family;
                t1.email = teacher.email;
                t1.username = teacher.username;
                t1.password = teacher.password;
                t1.image = teacher.image;
               
                
                db1.SaveChanges();
            }
        }
    }
}
