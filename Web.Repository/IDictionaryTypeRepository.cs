using System.Collections.Generic;
using Web.Model.Database;

namespace Web.Repository
{
    public interface IDictionaryTypeRepository
    {
        List<DictionaryType> GetDictionaryTypeList(DictionaryType dictionaryType);
        int Insert(DictionaryType dictionaryType);
        int Delete(long dictId);
        DictionaryType GetDictionaryType(DictionaryType dictionaryType);
        int Update(DictionaryType dictionaryType);
    }
}