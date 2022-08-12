using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.Convertor
{
    public class TypesConverter<T, R>
    {
        public static R Convert(T target)
        {
            var convertable = target as IConvertable<R>;
            if (convertable == null)
            {
                Debug.LogError($"Target type {typeof(T).Name} has no convertation logic to {typeof(R).Name} type. \n Return default value.");
                return default(R);
            }
            else
            {
                return convertable.ConvertTo();
            }
        }
    }

    public interface IConvertable<R>
    {
        R ConvertTo();
    }
}
