using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBExample
{
    public class PersonLiteDBService : LiteDBService<PersonModel>
    {
        public PersonLiteDBService()
        {
            var mapper = BsonMapper.Global;

            mapper.Entity<PersonModel>()
                .Id(x => x.Id);
        }
        public override PersonModel CreateItem(PersonModel item)
        {
            item.Id = Guid.NewGuid().ToString();
            return base.CreateItem(item);
        }

        public override PersonModel DeleteItemAsync(PersonModel item)
        {
            var c = _collection.Delete(i => i.Id == item.Id);
            return c == 0 ? null : item;
        }

        public override PersonModel UpdateItem(PersonModel item)
        {
            return base.UpdateItem(item);
        }

        public override IEnumerable<PersonModel> ReadAllItems()
        {
            return base.ReadAllItems();
        }
    }
}
