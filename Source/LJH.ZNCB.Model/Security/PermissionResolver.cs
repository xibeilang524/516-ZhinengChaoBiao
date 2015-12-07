using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace LJH.ZNCB.Model.Security
{
    public class PermissionResolver
    {
        public static List<OperatorRightAttribute> Resolve()
        {
            List<OperatorRightAttribute> items = new List<OperatorRightAttribute>();
            Type operatorEnum = typeof(Permission);
            FieldInfo[] fields = operatorEnum.GetFields();
            List<string> categories = new List<string>();
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum)
                {
                    object[] attrs = field.GetCustomAttributes(false);
                    foreach (object attr in attrs)
                    {
                        if (attr is OperatorRightAttribute)
                        {
                            OperatorRightAttribute right = attr as OperatorRightAttribute;
                            right.Value = Convert.ToInt32(field.GetValue(null));
                            items.Add(right);
                        }
                    }
                }
            }
            return items;
        }
    }
}
