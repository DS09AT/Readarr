using System.Collections.Generic;
using Shelvance.Core.Annotations;

namespace Shelvance.Core.Languages
{
    public class LanguageFieldConverter
    {
        public List<FieldSelectOption> GetSelectOptions()
        {
            return Language.All.ConvertAll(v => new FieldSelectOption { Value = v.Id, Name = v.Name });
        }
    }
}
