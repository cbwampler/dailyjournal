using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJournal.Data.Entities
{
    public enum MealName
    {
        Breakfast,
        Lunch,
        Dinner,
        Snack
    };
    public enum WeekDay
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    };

    public class Meal
    {
        [Key]
        public int MealId { get; set; }
        public  MealName MealName  { get; set; }
        public string Notes { get; set; }
        public Guid OwnerId { get; set; }
        public WeekDay WeekDay  { get; set; }
        public DateTime MealDate { get; set; }
        public DateTime MealTime { get; set; }
        public int? JournalId { get; set; }
        public virtual Journal Journal { get; set; }

        public virtual ICollection<Food> Foods { get; set; } = new HashSet<Food>();
    }
}