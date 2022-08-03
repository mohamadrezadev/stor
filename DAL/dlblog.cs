using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEE;
namespace DAL
{
   public class dlblog
    {
        public void create(blog blog)
        {
            try
            {

                var db1 = new db();
                var q = db1.Teachers.Where(i => i.id == blog.id);
                if (q.Count() == 0)
                {
                    db1.Blogs.Add(blog);
                    db1.SaveChanges();
                }
            }
            catch (Exception)
            {

                Console.WriteLine("eror");
            }
        }
        public List<blog> readall_blog()
        {
            try
            {
                var db1 = new db();
                return db1.Blogs.ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<blog> serchbyname(string titel)
        {
            var db1 = new db();
            var q = db1.Blogs.Where(i => i.titel.Contains(titel));
            if (q.Count() == 0)
            {

                return null;
            }
            return q.ToList();
        }
        public blog serchbynid(int id)
        {
            var db1 = new db();
            var q = db1.Blogs.Where(i => i.id == id);
            if (q.Count() == 0)
            {

                return null;
            }
            return q.Single();
        }
        public void delet(int id)
        {
            var db1 = new db();
            var q = db1.Blogs.Where(i => i.id == id);
            if (q.Count() != 0)
            {
                db1.Remove(q.Single());
                db1.SaveChanges();

            }
        }
        public void edit(int id, blog blog)
        {
            var db1 = new db();
            var q = db1.Teachers.Where(i => i.id == id).Single();
            if (q!=null)
            {
                var b1 = new blog();
                b1.titel = blog.titel;
                b1.text1 = blog.text1;
                b1.text2 = blog.text2;
                b1.text3 = blog.text3;
                b1.text4 = blog.text4;
                b1.intro = blog.intro;
                b1.foter = blog.foter;
                b1.image = blog.image;
                b1.video = blog.video;
                db1.SaveChanges();
            }
        }
        public int gettotal()
        {
            var db1 = new db();
            return db1.Blogs.Count();

        }
        public List<blog> get_skip(int c)
        {
            int n = c * 10;
            var db1 = new db();
            var q = db1.Blogs.Skip(n).Take(10);


            return q.ToList();
        }
    }
}
