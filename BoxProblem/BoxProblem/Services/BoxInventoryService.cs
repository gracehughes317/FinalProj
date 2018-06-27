using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoxProblem.Data;
using BoxProblem.Repositories;

namespace BoxProblem.Services
{
    public class BoxInventoryService
    {
        private BoxInventoryRepository repository;

        public BoxInventoryService(ApplicationDbContext context)
        {
            repository = new BoxInventoryRepository(context);
        }

        public List<BoxInventory> GetAllBoxInventorys()
        {
            return repository.GetAllBoxInventorys();
        }

        public void AddBoxInventory(BoxInventory toAdd)
        {
            repository.AddBoxInventory(toAdd);
        }

        public BoxInventory GetBoxInventoryById(int id)
        {
            return repository.GetBoxInventoryById(id);
        }

        public void SaveEdits(BoxInventory toSave)
        {
            repository.SaveEdits(toSave);
        }

        public void DeleteBoxInventory(BoxInventory toDelete)
        {
            repository.DeleteBoxInventory(toDelete);
        }

        public List<BoxInventory> FilterWeight(int weight)
        {
            return repository.FilterWeight(weight);
        }

        public List<BoxInventory> FilterVolume(int volume)
        {
            return repository.FilterVolume(volume);
        }

        public List<BoxInventory> FilterCanHoldLiquid(bool canHold)
        {
            return repository.FilterCanHoldLiquid(canHold);
        }

        public List<BoxInventory> FilterCost(double cost)
        {
            return repository.FilterCost(cost);
        }

        public List<BoxInventory> FilterCount(int count)
        {
            return repository.FilterCount(count);
        }

        public List<BoxInventory> FilterCreatedAt(DateTime date)
        {
            return repository.FilterCreatedAt(date);
        }

        public List<BoxInventory> SortId(bool increasing)
        {
            return repository.SortId(increasing);
        }

        public List<BoxInventory> SortWeight(bool increasing)
        {
            return repository.SortWeight(increasing);
        }

        public List<BoxInventory> SortVolume(bool increasing)
        {
            return repository.SortVolume(increasing);
        }

        public List<BoxInventory> SortCost(bool increasing)
        {
            return repository.SortCost(increasing);
        }

        public List<BoxInventory> SortCount(bool increasing)
        {
            return repository.SortCount(increasing);
        }

        public List<BoxInventory> SortCreatedAt(bool increasing)
        {
            return repository.SortCreatedAt(increasing);
        }
    }
}
