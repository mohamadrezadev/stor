using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BEE;
using Microsoft.EntityFrameworkCore;
namespace DAL
{
  public  class dlcours
    {
        public void create(cours cours)
        {
        
            try
            {
                var db1 = new db();
                var q = db1.courss.Where(i => i.id == cours.id);
                if (q.Count() == 0)
                {

                    db1.courss.Add(cours);
                    if (cours.Courss_techers.Count()!=0)
                    {
                        foreach (var item in cours.Courss_techers)
                        {
                            db1.techerCourss.Add(item);
                        }
                    }
                    db1.SaveChanges();
                    
                }
            }
            catch (Exception)
            {
               
            }
        }
        public void createtechercours(techer_Cours techer_Cours)
        {

            try
            {
                var db1 = new db();
                var q = db1.courss.Where(i => i.id == techer_Cours.id);
                if (q.Count() == 0)
                {

                    db1.techerCourss.Add(techer_Cours);
                    db1.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }
        public List<cours> readall_cours()
        {
            try
            {
                var db1 = new db();
                return db1.courss.ToList();
            }
            catch (Exception)
            {
                return null;
            }
          
        }
        public List<cours> serch(string search)
        {
            int n;
            var db1 = new db();
            var q = db1.courss.Where(i => i.titel.Contains(search) || i.details.Contains(search));
            if (int.TryParse(search,out n))
            {
                q = q.Where(i => i.price == Convert.ToInt32(search));
            }
          
            return q.ToList();
        }
        public cours serchbynid(int id)
        {
            var db1 = new db();
            var q = from i in db1.courss.Include(s => s.Courss_techers).ThenInclude(s => s.Teachers) where i.id == id select i;
           
            return q.SingleOrDefault();
        }
        public void delet(int id)
        {
            var db1 = new db();
            var q = db1.courss.Where(i => i.id == id);
            if (q.Count() != 0)
            {
                db1.Remove(q.Single());
                db1.SaveChanges();

            }
        }
        public void update( cours cours)
        {
            var db1 = new db();
            var q = db1.courss.Where(i => i.id == cours.id);
            if (q.Count() != 0)
            {
                var c1 = new cours();
                c1 = q.Single();
                c1.titel = cours.titel;
                c1.price = cours.price;
                c1.time = cours.time;
                c1.image = cours.image;
                c1.video = cours.video;
                c1.id = cours.id;
                
                c1.details = cours.details;
                c1.Courss_techers = new List<techer_Cours>();
                foreach (var item in cours.Courss_techers)
                {
                    if (item.teacherId!=0)
                    {
                        
                        c1.Courss_techers.Append(new techer_Cours { teacherId = item.teacherId, courseId = c1.id });
                    }
                }
                db1.SaveChanges();
            }
        }
       public List<cours> searchbyids(List<int> ids)
        {
            var db1 = new db();
            var q = from i in db1.courss where ids.Contains(i.id) select i;
            return q.ToList();
        }
        public int gettotal()
        {
            var db1 = new db();
            return db1.courss.Count();
            
        }
        public List<cours> get_skip(int c)
        {
            int n = c * 10;
            var db1 = new db();
            var q = db1.courss.Skip(n).Take(10);


            return q.ToList();
        }

    }
}
