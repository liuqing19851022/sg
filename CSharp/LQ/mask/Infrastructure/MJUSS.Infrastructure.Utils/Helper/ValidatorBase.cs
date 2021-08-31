namespace MJUSS.Infrastructure.Utils.Helper
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 验证基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValidatorBase<T>
    {
        /// <summary>
        /// 基本验证
        /// </summary>
        /// <param name="data"></param>
        public virtual void BasicValidate(T data)
        {
            this.ValidateObject(data);
        }

        /// <summary>
        /// 验证对象
        /// </summary>
        /// <param name="instance"></param>
        protected virtual void ValidateObject(T instance)
        {
            var context = new ValidationContext(instance, null, null);
            Validator.ValidateObject(instance, context, true);
        }

        /// <summary>
        /// 验证属性的规则
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="instance">验证对象实例</param>
        /// <param name="value"></param>
        /// <param name="express"></param>
        protected virtual void ValidateProperty<TProperty>(T instance, object value, System.Linq.Expressions.Expression<System.Func<T, TProperty>> express)
        {
            var memberName = ((System.Linq.Expressions.MemberExpression)express.Body).Member.Name;
            var context = new ValidationContext(instance, null, null) { MemberName = memberName };
            Validator.ValidateProperty(value, context);
        }
    }
}
