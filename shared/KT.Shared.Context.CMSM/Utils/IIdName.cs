using MongoDB.Bson;

namespace KT.Shared.Context
{
    public interface IIdName
    {
        ObjectId Id { get; set; }

        string Name { get; set; }
    }
}
