using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoxProblem.Data;
using Microsoft.EntityFrameworkCore;

namespace BoxProblem.Repositories
{
    public class BoxInventoryRepository
    {
        private ApplicationDbContext dbContext;

        public BoxInventoryRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public List<BoxInventory> GetAllBoxInventorys()
        {
            return dbContext.Boxes.ToList();
        }

        public void AddBoxInventory(BoxInventory toAdd)
        {
            dbContext.Boxes.Add(toAdd);
            dbContext.SaveChanges();
        }

        public BoxInventory GetBoxInventoryById(int id)
        {
            return dbContext.Boxes.Find(id);
        }

        public void SaveEdits(BoxInventory toSave)
        {
            dbContext.Entry(toSave).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void DeleteBoxInventory(BoxInventory toDelete)
        {
            dbContext.Boxes.Remove(toDelete);
            dbContext.SaveChanges();
        }

        public List<BoxInventory> FilterWeight(int weight)
        {
            return dbContext.Boxes.Where(b => b.Weight == weight).ToList();
        }

        public List<BoxInventory> FilterVolume(int volume)
        {
            return dbContext.Boxes.Where(b => b.Volume == volume).ToList();
        }

        public List<BoxInventory> FilterCanHoldLiquid(bool canHold)
        {
            return dbContext.Boxes.Where(b => b.CanHoldLiquid == canHold).ToList();
        }

        public List<BoxInventory> FilterCost(double cost)
        {
            return dbContext.Boxes.Where(b => b.Cost == cost).ToList();
        }

        public List<BoxInventory> FilterCount(int count)
        {
            return dbContext.Boxes.Where(b => b.InventoryCount == count).ToList();
        }

        public List<BoxInventory> FilterCreatedAt(DateTime date)
        {
            return dbContext.Boxes.Where(b => b.CreatedAt.Equals(date)).ToList();
        }

        public List<BoxInventory> SortId(bool increasing)
        {
            if(increasing == true)
            {
                return dbContext.Boxes.OrderBy(b => b.Id).ToList();
            }
            else
            {
                return dbContext.Boxes.OrderByDescending(b => b.Id).ToList();
            }
        }

        public List<BoxInventory> SortWeight(bool increasing)
        {
            if (increasing == true)
            {
                return dbContext.Boxes.OrderBy(b => b.Weight).ToList();
            }
            else
            {
                return dbContext.Boxes.OrderByDescending(b => b.Weight).ToList();
            }
        }

        public List<BoxInventory> SortVolume(bool increasing)
        {
            if (increasing == true)
            {
                return dbContext.Boxes.OrderBy(b => b.Volume).ToList();
            }
            else
            {
                return dbContext.Boxes.OrderByDescending(b => b.Volume).ToList();
            }
        }

        public List<BoxInventory> SortCost(bool increasing)
        {
            if (increasing == true)
            {
                return dbContext.Boxes.OrderBy(b => b.Cost).ToList();
            }
            else
            {
                return dbContext.Boxes.OrderByDescending(b => b.Cost).ToList();
            }
        }

        public List<BoxInventory> SortCount(bool increasing)
        {
            if (increasing == true)
            {
                return dbContext.Boxes.OrderBy(b => b.InventoryCount).ToList();
            }
            else
            {
                return dbContext.Boxes.OrderByDescending(b => b.InventoryCount).ToList();
            }
        }

        public List<BoxInventory> SortCreatedAt(bool increasing)
        {
            if (increasing == true)
            {
                return dbContext.Boxes.OrderBy(b => b.CreatedAt).ToList();
            }
            else
            {
                return dbContext.Boxes.OrderByDescending(b => b.CreatedAt).ToList();
            }
        }

    }
}
