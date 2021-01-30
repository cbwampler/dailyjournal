using DailyJournal.Data.Contexts;
using DailyJournal.Data.Entities;
using DailyJournal.Models.JournalModels;
using DailyJournal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DailyJournal.Services
{
    public class JournalService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        private readonly Guid _userId;
        public JournalService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateJournal(JournalData viewModel)
        {
            //Create journal entity (in DB)

            var journalEntity = new Journal
            {
                OwnerId = _userId,
                JournalId = viewModel.JournalId,
                JournalName = viewModel.JournalName,
                JournalDate = viewModel.JournalDate,
                Notes = viewModel.Notes,
                Meals = new List<Meal>()
            };
            _db.Journals.Add(journalEntity);
            _db.SaveChanges();

            //for each foodId, find the food and add it tot he icollection for the jounal

            foreach (int mealId in viewModel.SelectedMealIds)

            {
                var meal = _db.Meals.Find(mealId);
                if (meal != null)
                {
                    journalEntity.Meals.Add(meal);
                }
            }
            return _db.SaveChanges() == 1;
        }

        //helper class for meallist
        public IEnumerable<SelectListItem> MealMenuItems()
        {

            var meals = _db.Meals.Select(meal => new SelectListItem
            {
                Value = meal.MealId.ToString(),
                Text = meal.MealName.ToString()

            }).ToList();

            return meals.ToArray();
        }

        public IEnumerable<JournalListItem> GetJournals()
        {
            var query = _db
                .Journals
                .Where(e => e.OwnerId == _userId)
                .Select(
                e =>
                    new JournalListItem
                    {
                        JournalId = e.JournalId,
                        JournalName = e.JournalName,
                        JournalDate = e.JournalDate,
                        Notes = e.Notes,
                        Meals = e.Meals.ToList()
                    });
            return query.ToArray();
        }

        public JournalDetail GetJournalById(int id)
        {
            var entity = _db
                .Journals
                .Single(e => e.JournalId == id && e.OwnerId == _userId);
            return
                new JournalDetail
                {
                    JournalId = entity.JournalId,
                    JournalName = entity.JournalName,
                    JournalDate = entity.JournalDate,
                    Notes = entity.Notes,
                    Meals = entity.Meals.ToList()
                };
        }
        
        public bool UpdateJournal(JournalData viewModel)
        {
            var entity = _db
                .Journals
                .Single(e => e.JournalId == viewModel.JournalId  && e.OwnerId == _userId);
           
            
            entity.JournalId = viewModel.JournalId;
            entity.JournalName = viewModel.JournalName;
            entity.JournalDate = viewModel.JournalDate;
            entity.Notes = viewModel.Notes;
           
            _db.Journals.Add(entity);
            _db.SaveChanges();

            foreach (int mealId in viewModel.SelectedMealIds)

            {
                var meal = _db.Meals.Find(mealId);
                if (meal != null)
                {
                    entity.Meals.Add(meal);
                }
            }

            return _db.SaveChanges() == 1;
        }

        public bool DeleteJournal(int journalId)
        {
            var entity = _db
                .Journals
                .Single(e => e.JournalId == journalId && e.OwnerId == _userId);
            _db.Journals.Remove(entity);

            return _db.SaveChanges() == 1;
        }
    }
}
