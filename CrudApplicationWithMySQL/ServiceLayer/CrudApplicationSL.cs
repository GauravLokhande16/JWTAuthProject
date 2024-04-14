using CrudApplicationWithMySQL.RepositoryLayer;

namespace CrudApplicationWithMySQL.ServiceLayer
{
    public class CrudApplicationSL :ICRudApplicationsSL
    {
        public readonly ICrudApplicationRL _crudApplicationRL;

        public CrudApplicationSL(ICrudApplicationRL crudeApplicationRL)
        {
            _crudApplicationRL = crudeApplicationRL;
        }
    }
}
