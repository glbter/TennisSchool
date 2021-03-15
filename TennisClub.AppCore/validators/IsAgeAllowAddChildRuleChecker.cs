using System;
using System.Configuration;
using TennisClub.AppCore.interfaces;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.AppCore.validators
{
    public class IsAgeAllowAddChildRuleChecker<TK> : IPairValidator<IChild<TK>, ICachedGroup<TK>>
    {
        private readonly int maxAgeInterval;
        public IsAgeAllowAddChildRuleChecker()
        {
            this.maxAgeInterval = Convert.ToInt32(
            ConfigurationManager.AppSettings.Get("maxChildrenAgeIntervalInGroup") ?? "3");
        }

        public bool Validate(IChild<TK> child, ICachedGroup<TK> group)
        {
            int age = child.Age;
            bool fitsInInterval = age >= group.MinAge && age <= group.MaxAge;
            bool willFitInInterval = (age - group.MinAge <= maxAgeInterval) && (group.MaxAge - age <= maxAgeInterval);
            return fitsInInterval || willFitInInterval;
        }
    }
}
