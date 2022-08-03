using System;
using System.Collections.Generic;
using BEE;
using DAL;
namespace BLL
{
    public class blteacher
    {
        public void create(teacher teacher1)
        {
            var dlteacher = new dltacher();
            dlteacher.create(teacher1);
        }
        public List<teacher> readall_teacher()
        {
            var dlteacher = new dltacher();
            return dlteacher.readall_teacher();
        }
        public teacher serchbynid(int id)
        {
            var dlteacher = new dltacher();
            return dlteacher.serchbynid(id);
        }
        public List<teacher> serchbyname(string nameteachers)
        {
            var dlteacher = new dltacher();
            return dlteacher.serchbyname(nameteachers);
        }
        public void delet(int id)
        {
            var dlteacher = new dltacher();
            dlteacher.delet(id);
        }
        public void edit(int id, teacher teacher)
        {
            var dlteacher = new dltacher();
            dlteacher.edit(id, teacher);
        }
    }
    public class blcours
    {
        public void create(cours cours)
        {
            var dlcours = new dlcours();
            dlcours.create(cours);

        }
        public List<cours> searchbyids(List<int> ids)
        {
            var dlcours = new dlcours();
            return dlcours.searchbyids(ids);
        }
        public void createtechercours(techer_Cours techer_Cours) 
        {
            var dlcours = new dlcours();
            dlcours.createtechercours(techer_Cours);
        }

        public List<cours> readall_cours()
        {
            var dlcours = new dlcours();

            return dlcours.readall_cours();
        }
        public List<cours> serch(string seacrh)
        {
            var dlcours = new dlcours();
            return dlcours.serch(seacrh);
            
        }
        public cours serchbynid(int id)
        {
            var dlcours = new dlcours();
            return dlcours.serchbynid(id);
        }
        public void delet(int id)
        {
            var dlcours = new dlcours();
            dlcours.delet(id);
        }
        public void update( cours cours)
        {
            var dlcours = new dlcours();
            dlcours.update( cours);
        }
        public List<cours> get_skip(int c)
        {
            var dlcours = new dlcours();
           return  dlcours.get_skip(c);
        }
       public int gettotal()
           {
            var dlcours = new dlcours();
            return dlcours.gettotal();

           }
    

    }
    public class blorder
    {
        public Order create(Order order)
        {
            var dlo = new dlOrder();
           return dlo.create(order);


        }

        public List<Order> readall_cours()
        {
            var dlo = new dlOrder();
            return dlo.readall_Order();
        }
        public Order serchbyid(int id)
        {
            var dlo = new dlOrder();
            return dlo.serchbynid(id);

        }
       
        public void delet(int id)
        {
            var dlo = new dlOrder();
            dlo.delet(id); ;
        }
        public List<Order> get_skip(int c)
        {
            var dlo = new dlOrder();
            return dlo.get_skip(c); ;
        }
        public void update(Order order)
        {
            var dl = new dlOrder();
            dl.update(order);
        }
    }
    public class blblog
    {
        public void create(blog blog)
        {
            var dlb = new dlblog();
            dlb.create(blog);
        }
        public List<blog> readall_blog()
        {
            var dlb = new dlblog();
            return dlb.readall_blog();
        }
        public blog serchbynid(int id)
        {
            var dlb = new dlblog();
            return dlb.serchbynid(id);
        }
        public List<blog> serchbyname(string titel)
        {
            var dlb = new dlblog();
            return dlb.serchbyname(titel);
        }
        public void delet(int id)
        {
            var dlb = new dlblog();
            dlb.delet(id);
        }
        public void edit(int id, blog b)
        {
            var dlb = new dlblog();
           dlb.edit(id,b);
        }
        public List<blog> get_skip(int c)
        {
            var dlb = new dlblog();
            return  dlb.get_skip(c);
        }
        public int gettotal()
        {
            var dlb = new dlblog();
            return dlb.gettotal();

        }
    }
}
