using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.Utils
{
    public class EnumUtil
    {
        public static string DescricaoValoresEnum<T>() where T : Enum
        {
            var enumMsg = new StringBuilder();
            for (int i = 0; i < Enum.GetNames(typeof(T)).Length; i++)
            {
                if (i > 0)
                {
                    enumMsg.Append(";");
                }
                var enumText = (T)(object)i;
                enumMsg.Append($" {i} = {enumText}");
            }
            return enumMsg.ToString();
        }
    }
}
