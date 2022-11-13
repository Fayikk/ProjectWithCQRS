using Core.Persistence.Repositories;



namespace Core.Security.Entities
{
    public class OperationClaims : Entity
    {
        public string Name { get; set; }

        public OperationClaims()
        {
        }

        public OperationClaims(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}

