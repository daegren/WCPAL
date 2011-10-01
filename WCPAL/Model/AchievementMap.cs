using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCPAL
{
    /// <summary>
    /// A list of <see cref="AchievementMap"/>s in World of Warcraft
    /// </summary>
    public class AchievementMap
    {
        private List<int> _achievementsCompleted;
        private List<int> _achievementsCompletedTimestamp;
        private List<int> _criteria;
        private List<int> _criteriaQuantity;
        private List<int> _criteriaTimestamp;
        private List<int> _criteriaCreated;
    }
}
