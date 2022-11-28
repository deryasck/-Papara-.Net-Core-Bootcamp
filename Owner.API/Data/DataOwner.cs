using Owner.API.OwnerModel;
using System.Collections.Generic;

namespace Owner.API.Data
{
    public class DataOwner
    {
        //database
        public List<OwnerModel.Ownerr> GetOwnerrsList()
        {
            return new List<OwnerModel.Ownerr> 
            {
                new OwnerModel.Ownerr
                {
                    ID=1,
                    Name="savaş",
                    Type="bmw",
                    Explanation="hello savas",
                    Date=System.DateTime.Now
                },
                     new OwnerModel.Ownerr
                {
                    ID=2,
                    Name="gamze",
                    Type="mersedes",
                    Explanation="hello gamze",
                    Date=System.DateTime.Now
                },
                          new OwnerModel.Ownerr
                {
                    ID=3,
                    Name="hasret",
                    Type="Audi",
                    Explanation="Hello hasret",
                    Date=System.DateTime.Now
                }
            };
        }
    }
}
