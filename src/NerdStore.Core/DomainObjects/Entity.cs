namespace NerdStore.Core.DomainObjects
{
    //Classe base de toda entidade
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        //Retorna o valor bool para a comparação de classes
        //Neste caso, está sendo otimizado para a classe Entity
        //Aplicação de recursividade
        public override bool Equals( object? obj )
        {
            var compareTo = obj as Entity;

            if(ReferenceEquals(this, compareTo)) return true;
            if(ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        //Traz a mesma denotação inicial de operações de comparação do Equals,
        //Porém utiliza do operador ==
        public static bool operator == ( Entity a, Entity b )
        {
            if(ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;

            if(ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

            return a.Equals(b);
        }
        
        //Implementação do operator diferente, pois necessita de validação para este caso
        public static bool operator != ( Entity a, Entity b ) => !(a == b);
        
        //Implementação de obter HashCode único por meio de um multiplicador aleatório
        public override int GetHashCode() => GetType().GetHashCode() * 907 + Id.GetHashCode();
    
        public override string ToString() => $"{GetType().Name} [Id = {Id}]";

        public virtual bool EhValido() => throw new NotImplementedException();
    }
}
