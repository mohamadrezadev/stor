using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEE;
namespace DAL
{
  public  class dlOrder
    {
        public Order create(Order order)
        {

            try
            {
                var db1 = new db();
                var q = db1.Orders.Where(i => i.Id==order.Id);
                if (q.Count() == 0)
                {

                    db1.Orders.Add(order);
                    db1.SaveChanges();
                    return (db1.Orders.Find(order.Id));
                }
            }
            catch (Exception)
            {
                
            }
                return null;
        }
        
        public List<Order> readall_Order()
        {
            try
            {
                var db1 = new db();
                return db1.Orders.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<Order> get_skip(int c)
        {
            int n=c*10;
            var db1 = new db();
            var q = db1.Orders.Skip(n).Take(10);
            

            return q.ToList();
        }
        public Order serchbynid(int id)
        {
            var db1 = new db();
            var q = from i in db1.Orders where i.Id==id select i;

            return q.SingleOrDefault();
        }
        public void delet(int id)
        {
            var db1 = new db();
            var q = db1.Orders.Where(i => i.Id == id);
            if (q.Count() != 0)
            {
                db1.Remove(q.Single());
                db1.SaveChanges();

            }
        }
        public void update(Order order)
        {
            var db1 = new db();
            var q = db1.Orders.Find(order.Id);
            if (q!=null)
            {
                var order1 = new Order();
                order1.statustpayment = order.statustpayment;
                order1.totalpric = order.totalpric;
                
               

                db1.SaveChanges();

            }
        }

    }
}
