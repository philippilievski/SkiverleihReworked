using Microsoft.EntityFrameworkCore;
using SkiverleihReworked.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiverleihReworked.Logic
{
    class DataLogic
    {
        Skiverleihcontext Skiverleihcontext = new Skiverleihcontext();
        public List<Customer> GetCustomers()
        {
            var customers = Skiverleihcontext.Customers
                .Include(c => c.Adress)
                .Include(c => c.CustomerItems)
                .ToList();
            return customers;
        }

        public List<Item> GetItems()
        {
            var items = Skiverleihcontext.Items
                .Include(i => i.Category)
                .Include(i => i.CustomerItems)
                .Include(i => i.Status)
                .ToList();
            return items;
        }

        public List<CustomerItem> GetCustomerItems()
        {
            var customeritems = Skiverleihcontext.CustomerItems
                .Include(ci => ci.Customer)
                .Include(ci => ci.Item)
                .ThenInclude(i => i.Status)
                .ToList();
            return customeritems;
        }

        public List<Category> GetCategories()
        {
            var categories = Skiverleihcontext.Categories
                .ToList();
            return categories;
        }

        public List<Status> GetStatuses()
        {
            var statuses = Skiverleihcontext.Statuses
                .ToList();
            return statuses;
        }

        public void AddCustomerItems(Customer customer, Item item)
        {
            var statusavaliable = Skiverleihcontext.Statuses
                .Where(s => s.StatusID == 2).First();

            item.Count += 1;
            item.Status = statusavaliable;
            Skiverleihcontext.Update(item);
            Skiverleihcontext.SaveChanges();

            CustomerItem customerItem = new CustomerItem();
            customerItem.Customer = customer;
            customerItem.Item = item;
            customerItem.LendDate = DateTime.Now;

            Skiverleihcontext.Add(customerItem);
            Skiverleihcontext.SaveChanges();
        }

        public void ReturnCustomerItem(CustomerItem customerItem)
        {
            var statusunavaliable = Skiverleihcontext.Statuses
                .Where(s => s.StatusID == 1).First();
            Item item = customerItem.Item;
            item.Status = statusunavaliable;
            Skiverleihcontext.Update(item);
            Skiverleihcontext.SaveChanges();

            Skiverleihcontext.Remove(customerItem);
            Skiverleihcontext.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            Skiverleihcontext.Update(customer);
            Skiverleihcontext.SaveChanges();
        }
        public void UpdateItem(Item item)
        {
            Skiverleihcontext.Update(item);
            Skiverleihcontext.SaveChanges();
        }
    }
}
