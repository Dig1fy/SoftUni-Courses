namespace BorderControl
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Validator
    {
        public static List<string> Validate(List<IIdentifiable> inhabitants, string idToCheck)
        {
            var fakeInhabitatnts = inhabitants
                .Where(x => x.Id.EndsWith(idToCheck))
                .Select(x=>x.Id)
                .ToList();

            return fakeInhabitatnts;
        }
    }
}
